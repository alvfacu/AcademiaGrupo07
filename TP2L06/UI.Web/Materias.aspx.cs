using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Negocio;
using Util;

namespace UI.Web
{
    public partial class Materias : System.Web.UI.Page
    {
        #region Variables

        MateriaLogic _logic;

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        #endregion

        #region Propiedades

        private MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new MateriaLogic();
                }
                return _logic;
            }
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private Materia Entity
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
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            this.semanalesTextBox.Text = this.Entity.HSSemanales.ToString();
            this.totalesTextBox.Text = this.Entity.HSTotales.ToString();
            this.planesList.SelectedValue = this.Entity.IDPlan.ToString();
        }

        private void EnableForm(bool enable)
        {
            this.planesList.Enabled = enable;
            this.totalesTextBox.Enabled = enable;
            this.semanalesTextBox.Enabled = enable;
            this.descripcionTextBox.Enabled = enable;
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
                this.usuarioPanel.Visible = false;
                this.mensajeError.Text = ex.Message;
                this.aceptarLinkButton.Enabled = false;
            }

        }

        private void CargarListas()
        {
            this.planesList.DataSource = new PlanLogic().GetAll();
            this.planesList.DataTextField = "descripcion";
            this.planesList.DataValueField = "id";
            this.DataBind();
        }

        private Business.Entities.Plan ObtenerPlan(int indice)
        {
            return new PlanLogic().GetOne(indice);
        }

        private void LoadEntity(Materia mat)
        {
            Business.Entities.Plan planActual = ObtenerPlan(Convert.ToInt32(this.planesList.SelectedValue));
            mat.Descripcion = this.descripcionTextBox.Text;
            mat.HSSemanales = Convert.ToInt32(this.semanalesTextBox.Text);
            mat.HSTotales = Convert.ToInt32(this.totalesTextBox.Text);
            mat.IDPlan = planActual.ID;            
        }

        private void SaveEntity(Materia mat)
        {
            this.Logic.Save(mat);
        }

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (((Usuario)Session["logueo"]).Per.TipoPersona != Business.Entities.Personas.TiposPersonas.Administrador)
            {
                if (!Page.IsPostBack)
                {
                    this.adminPanel.Visible = false;
                    this.usuarioPanel.Visible = true;
                }
                else
                {
                    this.errorPanel.Visible = false;
                    this.aceptarLinkButton.Enabled = true;
                    this.usuarioPanel.Visible = true;
                }
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    LoadGrid();
                    CargarListas();
                }
                else
                {
                    LoadGrid();
                    this.errorPanel.Visible = false;
                    this.aceptarLinkButton.Enabled = true;
                }
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
            this.usuarioPanel.Visible = false;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.EnableForm(true);
                this.usuarioPanel.Visible = true;
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
                        this.Entity = new Materia();
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
                        this.Entity = new Materia();
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
                this.usuarioPanel.Visible = true;
                this.EnableForm(false);
                this.aceptarLinkButton.CausesValidation = false;
                this.LoadForm(this.SelectedID);
                this.FormMode = FormModes.Baja;
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.usuarioPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {
            this.totalesTextBox.Text = string.Empty;
            this.semanalesTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
            this.planesList.SelectedIndex = 0;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            if (((Usuario)Session["logueo"]).Per.TipoPersona == Business.Entities.Personas.TiposPersonas.Administrador)
            {
                this.usuarioPanel.Visible = false;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        #endregion
    }
}