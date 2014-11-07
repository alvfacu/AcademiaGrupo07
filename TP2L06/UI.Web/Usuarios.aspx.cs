using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Negocio;

namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {

        UsuarioLogic _logic;


        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        
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
        
        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
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

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.claveTextBox.Text = this.Entity.Clave;
            this.repetirClaveTextBox.Text = this.Entity.Clave;
            this.emailTextBox.Text = this.Entity.EMail;
            this.habilitadoCheckBox.Checked = this.Entity.Habilitado;
            this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;
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

        private void LoadEntity(Usuario usuario)
        {
            Business.Entities.Personas personaActual = devolverPersona(this.personasList.SelectedIndex);
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

        private void EnableForm(bool enable)
        {
            this.emailTextBox.Enabled = enable;
            this.personasList.Enabled = enable;
            this.habilitadoCheckBox.Enabled = enable;
            this.nombreUsuarioTextBox.Enabled = enable;
            this.claveTextBox.Visible = enable;;
            this.repetirClaveTextBox.Visible = enable;
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

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
            CargarPersonas();
        }

        private void CargarPersonas()
        {
            this.personasList.DataSource = new PersonaLogic().DevolverPersonasPorApeNom();
            
            this.personasList.DataTextField = "nombre";

            this.personasList.DataBind();
        }

        private void ClearForm()
        {
            this.nombreUsuarioTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.habilitadoCheckBox.Checked = false;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }

        private Business.Entities.Personas devolverPersona(int indice)
        {
            return new PersonaLogic().GetAll()[indice];
        }
    }
}