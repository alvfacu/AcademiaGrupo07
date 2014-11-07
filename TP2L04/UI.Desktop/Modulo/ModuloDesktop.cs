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

namespace UI.Desktop
{
    public partial class ModuloDesktop : ApplicationForm
    {
        #region Variables

        private Modulo _moduloActual;

        #endregion

        #region Constructores

        public ModuloDesktop()
        {
            InitializeComponent();
        }

        public ModuloDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
        }

        public ModuloDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            ModuloActual = new ModuloLogic().GetOne(ID);
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

        public Modulo ModuloActual
        {
            get { return _moduloActual; }
            set { _moduloActual = value; }
        }

        #endregion

        #region Metodos

        public virtual void MapearDeDatos() 
        {
            this.txtID.Text = this.ModuloActual.ID.ToString();
            this.txtDescripcion.Text = this.ModuloActual.Descripcion;
        }

        public virtual void GuardarCambios()
        {
            MapearADatos();
            new ModuloLogic().Save(ModuloActual);
        }
        
        public virtual void MapearADatos() 
        {
            
            switch (this.Modo)
            {
                case (ModoForm.Alta):
                    { 
                        ModuloActual = new Modulo();
                        this.ModuloActual.Descripcion = this.txtDescripcion.Text;
                        this.ModuloActual.State = BusinessEntity.States.New;
                        break; 
                    }
                case (ModoForm.Modificacion):
                    {
                        this.ModuloActual.Descripcion = this.txtDescripcion.Text;
                        this.ModuloActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case (ModoForm.Baja):
                    {
                        this.ModuloActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
                case (ModoForm.Consulta):
                    {
                        this.ModuloActual.State = BusinessEntity.States.Unmodified;
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
                {
                    Notificar("Campos vacíos", "Existen campos sin completar.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #endregion

    }
}
