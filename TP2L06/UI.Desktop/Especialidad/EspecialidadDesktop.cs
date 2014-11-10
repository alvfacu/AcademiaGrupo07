using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Business.Entities;
using Util;

namespace UI.Desktop
{
    public partial class EspecialidadDesktop : ApplicationForm
    {
        #region Variables

        private Especialidad _especialidadActual;

        #endregion

        #region Constructores 

        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
        }

        public EspecialidadDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            EspecialidadActual = new EspecialidadLogic().GetOne(ID);
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

        public Especialidad EspecialidadActual
        {
            get { return _especialidadActual; }
            set { _especialidadActual = value; }
        }

        #endregion

        #region Metodos

        public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion.ToString();
        }

        public virtual void GuardarCambios()
        {
            try
            {
                MapearADatos();
                new EspecialidadLogic().Save(EspecialidadActual);
            }
            catch (ErrorEliminar ex)
            {
                Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public virtual void MapearADatos()
        {

            switch (this.Modo)
            {
                case (ModoForm.Alta):
                    {
                        EspecialidadActual = new Especialidad();
                        this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
                        this.EspecialidadActual.State = BusinessEntity.States.New;
                        break;
                    }
                case (ModoForm.Modificacion):
                    {
                        this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
                        this.EspecialidadActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case (ModoForm.Baja):
                    {
                        this.EspecialidadActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
                case (ModoForm.Consulta):
                    {
                        this.EspecialidadActual.State = BusinessEntity.States.Unmodified;
                        break;
                    }
            }
        }

        public virtual bool Validar()
        {
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
                    Notificar("Campos vacíos", "Existen campos sin completar.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #endregion
    }
}
