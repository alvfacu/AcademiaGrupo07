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
    public partial class Usuarios : System.Web.UI.Page
    {
        #region Variables
        
        UsuarioLogic _logic;

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        #endregion

        #region Propiedades
        
        private UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private Usuario Entity
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
            this.emailTextBox.Text = this.Entity.EMail;
            this.personasList.SelectedValue = this.Entity.Per.ID.ToString();
            this.habilitadoCheckBox.Checked = this.Entity.Habilitado;
            this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;
            this.claveTextBox.Text = this.Entity.Clave;
            this.repetirClaveTextBox.Text = this.Entity.Clave;
        }
        
        private void EnableForm(bool enable)
        {
            this.emailTextBox.Enabled = enable;
            this.personasList.Enabled = enable;
            this.habilitadoCheckBox.Enabled = enable;
            this.nombreUsuarioTextBox.Enabled = enable;
            this.claveLabel.Visible = enable;
            this.claveTextBox.Visible = enable;
            this.repetirClaveLabel.Visible = enable;
            this.repetirClaveTextBox.Visible = enable;
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
        
        private void CargarPersonas()
        {
            this.personasList.DataSource = new PersonaLogic().DevolverPersonasPorApeNom();

            this.personasList.DataTextField = "nombre";
            this.personasList.DataValueField = "id";

            this.personasList.DataBind();
        }

        private void ClearForm()
        {
            this.nombreUsuarioTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.habilitadoCheckBox.Checked = false;
            this.claveTextBox.Text = string.Empty;
            this.repetirClaveTextBox.Text = string.Empty;
            this.personasList.SelectedIndex = 0;
        }
        
        private Business.Entities.Personas ObtenerPersona(int indice)
        {
            return new PersonaLogic().GetOne(indice);
        }

        private void LoadEntity(Usuario usuario)
        {
            Business.Entities.Personas personaActual = ObtenerPersona(Convert.ToInt32(this.personasList.SelectedValue));
            usuario.Nombre = personaActual.Nombre;
            usuario.Apellido = personaActual.Apellido;
            usuario.EMail = this.emailTextBox.Text;
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Habilitado = this.habilitadoCheckBox.Checked;
            usuario.Per = personaActual;
        }

        private void SaveEntity(Usuario usuario)
        {
            this.Logic.Save(usuario);
        }

        #endregion

        #region Eventos
             
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarPersonas();
            //if (((Usuario)Session["logueo"]).Per.TipoPersona == Business.Entities.Personas.TiposPersonas.Alumno)
            //{
            //    this.EnableForm(true);
            //    this.formPanel.Visible = true;
            //    this.FormMode = FormModes.Modificacion;
            //    this.LoadForm(((Usuario)Session["logueo"]).ID);
            //}
            //else
            //{
                if (!Page.IsPostBack)
                {
                    LoadGrid();
                }
                else
                {
                    LoadGrid();
                    this.errorPanel.Visible = false;
                    this.aceptarLinkButton.Enabled = true;
                }
            //}
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
                        this.Entity = new Usuario();
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
                        this.Entity = new Usuario();
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