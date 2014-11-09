using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Business.Entities;

namespace UI.Web
{
    public partial class ModulosUsuarios : System.Web.UI.Page
    {
        #region Variables

        ModuloUsuarioLogic _logic;

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        #endregion

        #region Propiedades

        private ModuloUsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new ModuloUsuarioLogic();
                }
                return _logic;
            }
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private ModuloUsuario Entity
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
            this.modulosList.SelectedValue = this.Entity.IdModulo.ToString();
            this.usuariosList.SelectedValue = this.Entity.IdUsuario.ToString();
            this.altaCheck.Checked = this.Entity.PermiteAlta;
            this.bajaCheck.Checked = this.Entity.PermiteBaja;
            this.modificacionCheck.Checked = this.Entity.PermiteModificacion;
            this.consultaCheck.Checked = this.Entity.PermiteConsulta;
        }

        private void EnableForm(bool enable)
        {
            this.modulosList.Enabled = enable;
            this.usuariosList.Enabled = enable;
            this.altaCheck.Enabled = enable;
            this.bajaCheck.Enabled = enable;
            this.modificacionCheck.Enabled = enable;
            this.consultaCheck.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void CargarListas()
        {
            this.modulosList.DataSource = new ModuloLogic().GetAll();
            this.usuariosList.DataSource = new UsuarioLogic().GetAll();

            this.modulosList.DataTextField = "descripcion";
            this.usuariosList.DataTextField = "nombreusuario";

            this.modulosList.DataValueField = "id";
            this.usuariosList.DataValueField = "id";

            this.modulosList.DataBind();
            this.usuariosList.DataBind();
        }

        private Business.Entities.Usuario ObtenerUsuario(int indice)
        {
            return new UsuarioLogic().GetOne(indice);
        }

        private void LoadEntity(ModuloUsuario modusr)
        {
            Business.Entities.Usuario usuarioActual = ObtenerUsuario(Convert.ToInt32(this.usuariosList.SelectedValue));
            Business.Entities.Modulo moduloActual = ObtenerModulo(Convert.ToInt32(this.modulosList.SelectedValue));
            modusr.IdModulo = moduloActual.ID;
            modusr.IdUsuario = usuarioActual.ID;
            modusr.PermiteAlta = this.altaCheck.Checked;
            modusr.PermiteBaja = this.bajaCheck.Checked;
            modusr.PermiteModificacion = this.modificacionCheck.Checked;
            modusr.PermiteConsulta = this.consultaCheck.Checked;
        }

        private Modulo ObtenerModulo(int indice)
        {
            return new ModuloLogic().GetOne(indice);
        }

        private void SaveEntity(ModuloUsuario modusr)
        {
            this.Logic.Save(modusr);
        }

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
                CargarListas();
            }
            else
            {
                LoadGrid();
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
                        this.Entity = new ModuloUsuario();
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
                        this.Entity = new ModuloUsuario();
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

        private void ClearForm()
        {
            this.modulosList.SelectedIndex = 0;
            this.usuariosList.SelectedIndex = 0;
            this.consultaCheck.Checked = false;
            this.altaCheck.Checked = false;
            this.bajaCheck.Checked = false;
            this.modificacionCheck.Checked = false;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }

        #endregion
    }
}