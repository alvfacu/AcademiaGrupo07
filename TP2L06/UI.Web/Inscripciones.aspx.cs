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
    public partial class Inscripciones : System.Web.UI.Page
    {
        #region Variables

        AlumnoInsLogic _logic;

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        #endregion

        #region Propiedades

        private AlumnoInsLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new AlumnoInsLogic();
                }
                return _logic;
            }
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private AlumnoInscripcion Entity
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
            this.condicionTextBox.Text = this.Entity.Condicion;
            this.notaTextBox.Text = this.Entity.Nota.ToString();
            this.alumnosList.SelectedValue = this.Entity.IDAlumno.ToString();
            this.cursoList.SelectedValue = this.Entity.IDCurso.ToString();
        }

        private void EnableForm(bool enable)
        {
            this.condicionTextBox.Enabled = enable;
            this.notaTextBox.Enabled = enable;
            this.alumnosList.Enabled = enable;
            this.cursoList.Enabled = enable;
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
            this.alumnosList.DataSource = new PersonaLogic().DevolverAlumnos();
            this.cursoList.DataSource = new CursoLogic().GetAll();

            this.alumnosList.DataTextField = "nombre";
            this.cursoList.DataTextField = "descripcion";

            this.alumnosList.DataValueField = "id";
            this.cursoList.DataValueField = "id";

            this.alumnosList.DataBind();
            this.cursoList.DataBind();
        }

        private void ClearForm()
        {
            this.condicionTextBox.Text = string.Empty;
            this.notaTextBox.Text = string.Empty;
            this.alumnosList.SelectedIndex = 0;
            this.cursoList.SelectedIndex = 0;
        }


        private Business.Entities.Personas ObtenerAlumno(int indice)
        {
            return new PersonaLogic().GetOne(indice);
        }

        private void LoadEntity(AlumnoInscripcion inscripcion)
        {
            Business.Entities.Personas personaActual = ObtenerAlumno(Convert.ToInt32(this.alumnosList.SelectedValue));
            Business.Entities.Curso cursoActual = ObtenerCurso(Convert.ToInt32(this.cursoList.SelectedValue));
            inscripcion.IDAlumno = personaActual.ID;
            inscripcion.IDCurso = cursoActual.ID;
            inscripcion.Nota = Convert.ToInt32(this.notaTextBox.Text);
            inscripcion.Condicion = this.condicionTextBox.Text;
        }

        private Curso ObtenerCurso(int indice)
        {
            return new CursoLogic().GetOne(indice);
        }

        private void SaveEntity(AlumnoInscripcion curso)
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
            if (this.noCupoPanel.Visible != true)
            {
                switch (this.FormMode)
                {
                    case (FormModes.Modificacion):
                        {
                            this.Entity = new AlumnoInscripcion();
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
                            if (new AlumnoInsLogic().HayCupo(Convert.ToInt32(this.cursoList.SelectedValue)))
                            {
                                this.Entity = new AlumnoInscripcion();
                                this.LoadEntity(this.Entity);
                                this.SaveEntity(this.Entity);
                                this.LoadGrid();
                            }
                            else
                            {
                                this.noCupoPanel.Visible = true;
                                this.noCupoLabel.Text = "No hay posibilidad de inscrpción: No hay cupo.";
                            }
                            break;
                        }
                    default:
                        break;
                }

                this.formPanel.Visible = false;
            }
            else
            {
                this.noCupoPanel.Visible = false;
            }
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