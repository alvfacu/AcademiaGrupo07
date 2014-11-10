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
    public partial class DocentesCursos : System.Web.UI.Page
    {
        #region Variables

        DocenteLogic _logic;

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        #endregion

        #region Propiedades

        private DocenteLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new DocenteLogic();
                }
                return _logic;
            }
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private DocenteCurso Entity
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
            this.docentesList.SelectedValue = this.Entity.IDDocente.ToString();
            this.cargosList.SelectedValue = this.Entity.Cargo.ToString();
            this.cursoList.SelectedValue = this.Entity.IDCurso.ToString();
        }

        private void EnableForm(bool enable)
        {
            this.cursoList.Enabled = enable;
            this.docentesList.Enabled = enable;
            this.cargosList.Enabled = enable;
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
            this.docentesList.DataSource = new PersonaLogic().DevolverDocentes();
            this.cursoList.DataSource = new CursoLogic().GetAll();
            this.cargosList.DataSource = new DocenteLogic().DevolverTiposCargos();
            
            this.docentesList.DataTextField = "nombre";
            this.cursoList.DataTextField = "descripcion";

            this.docentesList.DataValueField = "id";
            this.cursoList.DataValueField = "id";

            this.docentesList.DataBind();
            this.cursoList.DataBind();
            this.cargosList.DataBind();
        }

        private Business.Entities.Personas ObtenerDocente(int indice)
        {
            return new PersonaLogic().GetOne(indice);
        }

        private void LoadEntity(DocenteCurso docurso)
        {
            Business.Entities.Personas personaActual = ObtenerDocente(Convert.ToInt32(this.docentesList.SelectedValue));
            Business.Entities.Curso cursoActual = ObtenerCurso(Convert.ToInt32(this.cursoList.SelectedValue));
            docurso.IDDocente = personaActual.ID;
            docurso.IDCurso = cursoActual.ID;
            docurso.Cargo = (DocenteCurso.TiposCargos)Enum.Parse(typeof(DocenteCurso.TiposCargos), this.cargosList.SelectedValue);
        }

        private Curso ObtenerCurso(int indice)
        {
            return new CursoLogic().GetOne(indice);
        }

        private void SaveEntity(DocenteCurso docurso)
        {
            this.Logic.Save(docurso);
        }

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (((Usuario)Session["logueo"]).Per.TipoPersona != Business.Entities.Personas.TiposPersonas.Administrador)
            {
                if (!Page.IsPostBack)
                {
                    CargarListas();
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
                        this.Entity = new DocenteCurso();
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
                        this.Entity = new DocenteCurso();
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
            this.cargosList.SelectedIndex = 0;
            this.cursoList.SelectedIndex = 0;
            this.docentesList.SelectedIndex = 0;
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