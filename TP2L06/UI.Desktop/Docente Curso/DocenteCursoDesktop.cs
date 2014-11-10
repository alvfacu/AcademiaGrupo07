using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Negocio;
using Util;

namespace UI.Desktop
{
    public partial class DocenteCursoDesktop : ApplicationForm
    {
        #region Variables

        private DocenteCurso _docCurActual;

        #endregion

        #region Constructores

        public DocenteCursoDesktop()
        {
            InitializeComponent();
        }

        public DocenteCursoDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
        }

        public DocenteCursoDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            DocCurActual = new DocenteLogic().GetOne(ID);
            MapearDeDatos();
            switch (modo)
            {
                case (ModoForm.Alta): this.btnAceptar.Text = "Guardar";
                    break;
                case (ModoForm.Modificacion): this.btnAceptar.Text = "Guardar";
                    break;
                case (ModoForm.Baja): this.btnAceptar.Text = "Eliminar";
                    break;
                case (ModoForm.Consulta): this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        #endregion

        #region Propiedades

        public DocenteCurso DocCurActual
        {
            get { return _docCurActual; }
            set { _docCurActual = value; }
        }

        #endregion

        #region Metodos

        public virtual void MapearDeDatos() 
        {
            this.txtID.Text = this.DocCurActual.ID.ToString();
            //no sale combobox
        }

        public virtual void GuardarCambios()
        {
            try
            {
                MapearADatos();
                new DocenteLogic().Save(DocCurActual);
            }
            catch (ErrorEliminar ex)
            {
                Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public virtual void MapearADatos() 
        {
            Business.Entities.Curso cursoActual = this.DevolverCurso();
            Business.Entities.Personas docenteActual = this.DevolverPersona();
            switch (this.Modo)
            {
                case (ModoForm.Alta):
                    {
                        DocCurActual = new DocenteCurso();
                        this.DocCurActual.IDCurso = cursoActual.ID;
                        this.DocCurActual.IDDocente = docenteActual.ID;
                        this.DocCurActual.Cargo = (DocenteCurso.TiposCargos)Enum.Parse(typeof(DocenteCurso.TiposCargos),this.cmbCargo.Text);
                        this.DocCurActual.State = BusinessEntity.States.New;
                        break; 
                    }
                case (ModoForm.Modificacion):
                    {
                        this.DocCurActual.IDCurso = cursoActual.ID;
                        this.DocCurActual.IDDocente = docenteActual.ID;
                        this.DocCurActual.Cargo = (DocenteCurso.TiposCargos)Enum.Parse(typeof(DocenteCurso.TiposCargos), this.cmbCargo.Text);
                        this.DocCurActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case (ModoForm.Baja):
                    {
                        this.DocCurActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
                case (ModoForm.Consulta):
                    {
                        this.DocCurActual.State = BusinessEntity.States.Unmodified;
                        break;
                    }
            }
        }

        private Business.Entities.Personas DevolverPersona()
        {
            return new PersonaLogic().GetOne(((Business.Entities.Personas)this.cmbDocente.SelectedValue).ID);
        }

        private Curso DevolverCurso()
        {
            return new CursoLogic().GetOne(((Business.Entities.Curso)this.cmbCurso.SelectedValue).ID);
        }
               
        private string DevolverDescripcion(int p)
        {
            List<Curso> cursos = new CursoLogic().GetAll();
            string desc = null;

            foreach (Curso cur in cursos)
            {
                if (cur.ID == p)
                {
                    desc = cur.Descripcion;
                }
            }

            return desc;
        }
       
        public virtual bool Validar() 
        {
            return true;
        }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        #endregion

        #region Eventos

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DocenteCursoDesktop_Load(object sender, EventArgs e)
        {
            List<String> listaCargos = new DocenteLogic().DevolverTiposCargos();
            cmbCargo.DataSource = listaCargos;
            cmbCurso.DataSource = new CursoLogic().GetAll();
            cmbDocente.DataSource = new PersonaLogic().DevolverDocentes();

            cmbCurso.DisplayMember = "descripcion";
            cmbDocente.DisplayMember = "nombre";

            cmbCurso.ValueMember = "id_curso";
            cmbDocente.ValueMember = "id_persona";
        }

        #endregion
    }
}
