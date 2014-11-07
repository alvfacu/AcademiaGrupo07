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
    public partial class CursoDesktop : ApplicationForm
    {
        #region Variables

        private Curso _cursoActual;

        #endregion

        #region Constructores

        public CursoDesktop()
        {
            InitializeComponent();
        }

        public CursoDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
        }

        public CursoDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            CursoActual = new CursoLogic().GetOne(ID);
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

        public Curso CursoActual
        {
            get { return _cursoActual; }
            set { _cursoActual = value; }
        }

        #endregion

        #region Metodos

        public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.txtAnio.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            this.txtDescripcion.Text = this.CursoActual.Descripcion;
            this.cmbIDCom.Text = this.CursoActual.IDComision.ToString();
            this.cmbIDMat.Text = this.CursoActual.IDMateria.ToString();
        }

        public virtual void GuardarCambios()
        {
            MapearADatos();
            new CursoLogic().Save(CursoActual);
        }

        public virtual void MapearADatos()
        {

            switch (this.Modo)
            {
                case (ModoForm.Alta):
                    {
                        CursoActual = new Curso();
                        this.CursoActual.AnioCalendario = int.Parse(this.txtAnio.Text);
                        this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                        this.CursoActual.Descripcion =  this.txtDescripcion.Text;
                        this.CursoActual.IDComision = int.Parse(this.cmbIDCom.Text);
                        this.CursoActual.IDMateria = int.Parse(this.cmbIDMat.Text);
                        this.CursoActual.State = BusinessEntity.States.New;
                        break;
                    }
                case (ModoForm.Modificacion):
                    {
                        this.CursoActual.AnioCalendario = int.Parse(this.txtAnio.Text);
                        this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                        this.CursoActual.Descripcion = this.txtDescripcion.Text;
                        this.CursoActual.IDComision = int.Parse(this.cmbIDCom.Text);
                        this.CursoActual.IDMateria = int.Parse(this.cmbIDMat.Text);
                        this.CursoActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case (ModoForm.Baja):
                    {
                        this.CursoActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
                case (ModoForm.Consulta):
                    {
                        this.CursoActual.State = BusinessEntity.States.Unmodified;
                        break;
                    }
            }
        }

        public virtual bool Validar()
        {
            int nro;
            Boolean estado = true;
            try
            {
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
                    else if (!(int.TryParse(this.txtAnio.Text, out nro)))
                    {
                        estado = false;
                        Notificar("Error en el ingreso del Año", "Verifique que el Año del Calendario sea un numero entero positivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (!(int.TryParse(this.txtCupo.Text, out nro)))
                    {
                        estado = false;
                        Notificar("Error en el ingreso del Cupo", "Verifique que el Cupo sea un numero entero positivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return estado;
            }
            catch (Exception e)
            {
                Notificar("ERROR", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                estado = false;
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

        private void CursoDesktop_Load(object sender, EventArgs e)
        {
            List<Materia> listaMaterias = new MateriaLogic().GetAll();
            List<String> idMat = new List<String>();
            foreach (Materia mat in listaMaterias)
            {
                idMat.Add(mat.ID.ToString());
            }
            
            cmbIDMat.DataSource = idMat;

            List<Comision> listaComisiones = new ComisionLogic().GetAll();
            List<String> idCom = new List<String>();
            foreach (Comision com in listaComisiones)
            {
                idCom.Add(com.ID.ToString());
            }
            
            cmbIDCom.DataSource = idCom;
        }

        #endregion
    }
}
