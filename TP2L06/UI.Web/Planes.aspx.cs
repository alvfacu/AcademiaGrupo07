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
    public partial class Planes : System.Web.UI.Page
    {
        #region Variables

        PlanLogic _logic;

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        #endregion

        #region Propiedades

        private PlanLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PlanLogic();
                }
                return _logic;
            }
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private Plan Entity
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
            this.especiliadadesList.SelectedValue = this.Entity.IDEspecialidad.ToString();
        }

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.especiliadadesList.Enabled = enable;
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

        private void CargarPlanes()
        {
            this.especiliadadesList.DataSource = new EspecialidadLogic().GetAll();

            this.especiliadadesList.DataTextField = "descripcion";
            this.especiliadadesList.DataValueField = "id";

            this.especiliadadesList.DataBind();
        }

        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;
            this.especiliadadesList.SelectedIndex = 0;
        }

        private Business.Entities.Especialidad ObtenerPlan(int indice)
        {
            return new EspecialidadLogic().GetOne(indice);
        }

        private void LoadEntity(Plan plan)
        {
            Business.Entities.Especialidad especialidadActual = ObtenerPlan(Convert.ToInt32(this.especiliadadesList.SelectedValue));
            plan.IDEspecialidad = especialidadActual.ID;
            plan.Descripcion = this.descripcionTextBox.Text;
        }

        private void SaveEntity(Plan plan)
        {
            this.Logic.Save(plan);
        }

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
                CargarPlanes();
            }
            else
            {
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
                        this.Entity = new Plan();
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
                        this.Entity = new Plan();
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
                this.aceptarLinkButton.CausesValidation = false;
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