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
    public partial class AluInscripcionDesktop : ApplicationForm
    {
        #region Variables

        private AlumnoInscripcion _aluInscripcionActual;

        #endregion

        #region Constructores

        public AluInscripcionDesktop()
        {
            InitializeComponent();
        }

        public AluInscripcionDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
        }

        public AluInscripcionDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            AluInscripcionActual = new AlumnoInsLogic().GetOne(ID);
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

        public AlumnoInscripcion AluInscripcionActual
        {
            get { return _aluInscripcionActual; }
            set { _aluInscripcionActual = value; }
        }

        #endregion

        #region Metodos

        public virtual void MapearDeDatos() 
        {
            this.txtID.Text = this.AluInscripcionActual.ID.ToString();
            this.txtIDAlu.Text = this.AluInscripcionActual.IDAlumno.ToString();
            this.cmbIDCurso.Text = this.AluInscripcionActual.IDCurso.ToString();
            this.txtCondicion.Text = this.AluInscripcionActual.Condicion;
            this.txtNota.Text = this.AluInscripcionActual.Nota.ToString();
        }

        public virtual void GuardarCambios()
        {
            MapearADatos();
            new AlumnoInsLogic().Save(AluInscripcionActual);
        }
        
        public virtual void MapearADatos() 
        {            
            switch (this.Modo)
            {
                case (ModoForm.Alta):
                    {
                        AluInscripcionActual = new AlumnoInscripcion();
                        this.AluInscripcionActual.IDAlumno = int.Parse(this.txtIDAlu.Text);
                        this.AluInscripcionActual.IDCurso = int.Parse(this.cmbIDCurso.Text);
                        this.AluInscripcionActual.Condicion = this.txtCondicion.Text;
                        this.AluInscripcionActual.Nota = int.Parse(this.txtNota.Text);
                        this.AluInscripcionActual.State = BusinessEntity.States.New;
                        break; 
                    }
                case (ModoForm.Modificacion):
                    {
                        this.AluInscripcionActual.IDAlumno = int.Parse(this.txtIDAlu.Text);
                        this.AluInscripcionActual.IDCurso = int.Parse(this.cmbIDCurso.Text);
                        this.AluInscripcionActual.Condicion = this.txtCondicion.Text;
                        this.AluInscripcionActual.Nota = int.Parse(this.txtNota.Text);
                        this.AluInscripcionActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case (ModoForm.Baja):
                    {
                        this.AluInscripcionActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
                case (ModoForm.Consulta):
                    {
                        this.AluInscripcionActual.State = BusinessEntity.States.Unmodified;
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
                else if (!(int.TryParse(this.txtNota.Text, out nro)))
                {
                    estado = false;
                    Notificar("Tipo incorrecto", "La nota debe ser un número entero.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!((0 <= int.Parse(this.txtNota.Text)) && (int.Parse(this.txtNota.Text)<=10)))
                {
                    estado = false;
                    Notificar("Número de nota incorrecta", "La nota debe ser un número entero positivo (entre 0 y 10).", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!(int.TryParse(this.txtIDAlu.Text, out nro)))
                {
                    estado = false;
                    Notificar("ID Alumno incorrecto", "Recuerde que el ID del Alumno debe ser un número entero positivo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void AluInscripcionDesktop_Load(object sender, EventArgs e)
        {
            List<Curso> listaCurso = new CursoLogic().GetAll();
            List<String> idCurso = new List<String>();
            foreach (Curso cur in listaCurso)
            {
                idCurso.Add(cur.ID.ToString());
            }
            
            cmbIDCurso.DataSource = idCurso;
        }

        #endregion
    }
}
