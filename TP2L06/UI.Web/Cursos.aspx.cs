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
    public partial class Cursos : System.Web.UI.Page
    {
        #region Variables

        CursoLogic _logic;

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        #endregion

        #region Propiedades

        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new CursoLogic();
                }
                return _logic;
            }
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private Curso Entity
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
            this.comisionesList.SelectedValue = this.Entity.IDComision.ToString();
            this.materiasList.SelectedValue = this.Entity.IDMateria.ToString();
            this.anioTextBox.Text = this.Entity.AnioCalendario.ToString();
            this.cupoTextBox.Text = this.Entity.Cupo.ToString();
        }

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.comisionesList.Enabled = enable;
            this.materiasList.Enabled = enable;
            this.anioTextBox.Enabled = enable;
            this.cupoTextBox.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void CargarListas()
        {
            this.comisionesList.DataSource = new ComisionLogic().GetAll();
            this.materiasList.DataSource = new MateriaLogic().GetAll();

            this.comisionesList.DataTextField = "descripcion";
            this.materiasList.DataTextField = "descripcion";

            this.comisionesList.DataValueField = "id";
            this.materiasList.DataValueField = "id";

            this.comisionesList.DataBind();
            this.materiasList.DataBind();
        }

        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;
            this.anioTextBox.Text = string.Empty;
            this.cupoTextBox.Text = string.Empty;
            this.comisionesList.SelectedIndex = 0;
            this.materiasList.SelectedIndex = 0;
        }


        private Business.Entities.Materia ObternerMateria(int indice)
        {
            return new MateriaLogic().GetOne(indice);
        }

        private void LoadEntity(Curso curso)
        {
            Business.Entities.Materia materiaActual = ObternerMateria(Convert.ToInt32(this.materiasList.SelectedValue));
            Business.Entities.Comision comisionActual = ObtenerComision(Convert.ToInt32(this.comisionesList.SelectedValue));
            curso.Descripcion = this.descripcionTextBox.Text;
            curso.AnioCalendario = Convert.ToInt32(this.anioTextBox.Text);
            curso.IDComision = comisionActual.ID;
            curso.IDMateria = materiaActual.ID;
            curso.Cupo = Convert.ToInt32(this.cupoTextBox.Text);
        }

        private Comision ObtenerComision(int indice)
        {
            return new ComisionLogic().GetOne(indice);
        }

        private void SaveEntity(Curso curso)
        {
            this.Logic.Save(curso);
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
                        this.Entity = new Curso();
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
                        this.Entity = new Curso();
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