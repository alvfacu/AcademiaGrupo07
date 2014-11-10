using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Business.Entities;
using Util;

namespace UI.Web
{
    public partial class Personas : System.Web.UI.Page
    {
        #region Variables

        PersonaLogic _logic;

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        #endregion

        #region Propiedades

        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonaLogic();
                }
                return _logic;
            }
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private Business.Entities.Personas Entity
        {
            get;
            set;
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        private int Day
        {
            get
            {
                if (Request.Form[this.diasList.UniqueID] != null)
                {
                    return int.Parse(Request.Form[this.diasList.UniqueID]);
                }
                else
                {
                    return int.Parse(this.diasList.SelectedItem.Value);
                }
            }
            set
            {
                this.PopulateDay();
                this.diasList.ClearSelection();
                this.diasList.Items.FindByValue(value.ToString()).Selected = true;
            }
        }

        private int Month
        {
            get
            {
                return int.Parse(this.mesesList.SelectedItem.Value);
            }
            set
            {
                this.PopulateMonth();
                this.mesesList.ClearSelection();
                this.mesesList.Items.FindByValue(value.ToString()).Selected = true;
            }
        }

        private int Year
        {
            get
            {
                return int.Parse(this.aniosList.SelectedItem.Value);
            }
            set
            {
                this.PopulateYear();
                this.aniosList.ClearSelection();
                this.aniosList.Items.FindByValue(value.ToString()).Selected = true;
            }
        }

        public DateTime SelectedDate
        {
            get
            {
                try
                {
                    return DateTime.Parse(this.Month + "/" + this.Day + "/" + this.Year);
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
            set
            {
                if (!value.Equals(DateTime.MinValue))
                {
                    this.Year = value.Year;
                    this.Month = value.Month;
                    this.Day = value.Day;
                }
            }
        }


        #endregion

        #region Metodos

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.planesList.SelectedValue = this.Entity.IDPlan.ToString();
            this.tiposList.SelectedValue = this.Entity.TipoPersona.ToString();
            this.apellidoTextBox.Text = this.Entity.Apellido;
            this.nombreTextBox.Text = this.Entity.Nombre;
            this.direccionTextBox.Text = this.Entity.Direccion;
            this.emailTextBox.Text = this.Entity.Email;
            this.legajoTextBox.Text = this.Entity.Legajo.ToString();
            this.telefonoTextBox.Text = this.Entity.Telefono;
        }

        private void EnableForm(bool enable)
        {
            this.planesList.Enabled = enable;
            this.tiposList.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.nombreTextBox.Enabled = enable;
            this.direccionTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.legajoTextBox.Enabled = enable;
            this.telefonoTextBox.Enabled = enable;
            this.diasList.Enabled = enable;
            this.mesesList.Enabled = enable;
            this.aniosList.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.Logic.Delete(id);
            }
            catch (ErrorEliminar ex)
            {
                this.errorPanel.Visible = true;
                this.formPanel.Visible = false;
                this.mensajeError.Text = ex.Message;
                this.aceptarLinkButton.Enabled = false;
            }
        }

        private void CargarListas()
        {
            this.tiposList.DataSource = new PersonaLogic().DevolverTiposPersonas();
            this.planesList.DataSource = new PlanLogic().GetAll();

            this.planesList.DataTextField = "descripcion";
            this.planesList.DataValueField = "id";

            this.tiposList.DataBind();
            this.planesList.DataBind();
        }

        private Business.Entities.Plan ObtenerPlan(int indice)
        {
            return new PlanLogic().GetOne(indice);
        }

        private void LoadEntity(Business.Entities.Personas per)
        {
            Business.Entities.Plan planActual = ObtenerPlan(Convert.ToInt32(this.planesList.SelectedValue));
            per.IDPlan = planActual.ID;
            per.Apellido = this.apellidoTextBox.Text;
            per.Nombre = this.nombreTextBox.Text;
            DateTime fechaNac = new DateTime(Convert.ToInt32(this.aniosList.SelectedValue.ToString()), Convert.ToInt32(this.mesesList.SelectedValue.ToString()), Convert.ToInt32(this.diasList.SelectedValue.ToString()), 0, 0, 0);
            per.FechaNacimiento = fechaNac;
            per.Email = this.emailTextBox.Text;
            per.Direccion = this.direccionTextBox.Text;
            per.Legajo = Convert.ToInt32(this.legajoTextBox.Text);
            per.Telefono = this.telefonoTextBox.Text;
            per.TipoPersona = (Business.Entities.Personas.TiposPersonas)Enum.Parse(typeof(Business.Entities.Personas.TiposPersonas), this.tiposList.SelectedValue);
        }
        
        private void SaveEntity(Business.Entities.Personas per)
        {
            this.Logic.Save(per);
        }

        private void PopulateDay()
        {
            this.diasList.Items.Clear();
            ListItem lt = new ListItem();
            lt.Text = "DD";
            lt.Value = "0";
            this.diasList.Items.Add(lt);
            int days = DateTime.DaysInMonth(this.Year, this.Month);
            for (int i = 1; i <= days; i++)
            {
                lt = new ListItem();
                lt.Text = i.ToString();
                lt.Value = i.ToString();
                this.diasList.Items.Add(lt);
            }
            this.diasList.Items.FindByValue(DateTime.Now.Day.ToString()).Selected = true;
        }

        private void PopulateMonth()
        {
            this.mesesList.Items.Clear();
            ListItem lt = new ListItem();
            lt.Text = "MM";
            lt.Value = "0";
            this.mesesList.Items.Add(lt);
            for (int i = 1; i <= 12; i++)
            {
                lt = new ListItem();
                lt.Text = Convert.ToDateTime("1/" + i.ToString() + "/1900").ToString("MMMM");
                lt.Value = i.ToString();
                this.mesesList.Items.Add(lt);
            }
            this.mesesList.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
        }

        private void PopulateYear()
        {
            this.aniosList.Items.Clear();
            ListItem lt = new ListItem();
            lt.Text = "YYYY";
            lt.Value = "0";
            this.aniosList.Items.Add(lt);
            for (int i = DateTime.Now.Year; i >= 1950; i--)
            {
                lt = new ListItem();
                lt.Text = i.ToString();
                lt.Value = i.ToString();
                this.aniosList.Items.Add(lt);
            }
            this.aniosList.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
        }

        private void ClearForm()
        {
            this.apellidoTextBox.Text = string.Empty;
            this.nombreTextBox.Text = string.Empty;
            this.direccionTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.legajoTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.diasList.SelectedIndex = 0;
            this.aniosList.SelectedIndex = 0;
            this.mesesList.SelectedIndex = 0;
            this.planesList.SelectedIndex = 0;
            this.tiposList.SelectedIndex = 0;
        }

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
            {
                LoadGrid();
                CargarListas();
                if (this.SelectedDate == DateTime.MinValue)
                {
                    this.PopulateYear();
                    this.PopulateMonth();
                    this.PopulateDay();
                }
            }
            else
            {
                if (Request.Form[this.diasList.UniqueID] != null)
                {
                    this.PopulateDay();
                    this.diasList.ClearSelection();
                    this.diasList.Items.FindByValue(Request.Form[this.diasList.UniqueID]).Selected = true;
                }
                LoadGrid();
                this.errorPanel.Visible = false;
                this.aceptarLinkButton.Enabled = true;
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
            this.formPanel.Visible = false;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case (FormModes.Modificacion):
                    {
                        this.Entity = new Business.Entities.Personas();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                    }
                case (FormModes.Baja):
                    {
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        break;
                    }
                case (FormModes.Alta):
                    {
                        this.Entity = new Business.Entities.Personas();
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                    }
                default:
                    break;
            }

            this.formPanel.Visible = false;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
                this.FormMode = FormModes.Baja;
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }

        #endregion

        
    }
}