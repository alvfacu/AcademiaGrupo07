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
            this.txtIDDocente.Text = this.DocCurActual.IDDocente.ToString();
            this.cmbCargo.Text = this.DocCurActual.Cargo.ToString();
            this.cmbCurso.Text = this.DocCurActual.IDCurso.ToString();
        }

        public virtual void GuardarCambios()
        {
            MapearADatos();
            new DocenteLogic().Save(DocCurActual);
        }
        
        public virtual void MapearADatos() 
        {
            
            switch (this.Modo)
            {
                case (ModoForm.Alta):
                    {
                        DocCurActual = new DocenteCurso();
                        this.DocCurActual.IDDocente = int.Parse(this.txtIDDocente.Text);
                        this.DocCurActual.Cargo = (DocenteCurso.TiposCargos)Enum.Parse(typeof(DocenteCurso.TiposCargos),this.cmbCargo.Text);
                        this.DocCurActual.IDCurso = int.Parse(this.cmbCurso.Text);
                        this.DocCurActual.State = BusinessEntity.States.New;
                        break; 
                    }
                case (ModoForm.Modificacion):
                    {
                        this.DocCurActual.IDDocente = int.Parse(this.txtIDDocente.Text);
                        this.DocCurActual.Cargo = (DocenteCurso.TiposCargos)Enum.Parse(typeof(DocenteCurso.TiposCargos), this.cmbCargo.Text);
                        this.DocCurActual.IDCurso = int.Parse(this.cmbCurso.Text);
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
       
        public virtual bool Validar() 
        { 
            int nro;
            Boolean estado = true;
            if (!(this.Modo == ModoForm.Baja))
            {
                foreach (Control control in this.tableLayoutPanel1.Controls)
                {
                    if (!(control == txtID))
                    {
                        if (control is TextBox && control.Text == String.Empty)
                        {
                            estado = false;
                        }
                    }
                    
                }
                if (estado == false)
                {
                    Notificar("Campos vacíos", "Existen campos sin completar.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!(int.TryParse(this.txtIDDocente.Text, out nro)))
                {
                    estado = false;
                    Notificar("Tipo de dato ingresado incorrecto", "El ID del Docente contiene solo números.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return estado;
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
            List<Curso> listaCursos = new CursoLogic().GetAll();
            List<String> idCurso = new List<String>();
            foreach (Curso cur in listaCursos)
            {
                idCurso.Add(cur.ID.ToString());
            }

            cmbCurso.DataSource = idCurso;

            List<String> listaCargos = DocenteCurso.DevolverTiposCargos();
            cmbCargo.DataSource = listaCargos;
        }

        #endregion
    }
}
