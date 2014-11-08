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
    public partial class PlanDesktop : ApplicationForm
    {
        #region Variables

        private Plan _planActual;

        #endregion

        #region Constructores

        public PlanDesktop()
        {
            InitializeComponent();
        }

        public PlanDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
        }

        public PlanDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            PlanActual = new PlanLogic().GetOne(ID);
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

        public Plan PlanActual
        {
            get { return _planActual; }
            set { _planActual = value; }
        }

        #endregion

        #region Metodos

        public virtual void MapearDeDatos() 
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            //no sale combobox
        }

        public virtual void GuardarCambios()
        {
            MapearADatos();
            new PlanLogic().Save(PlanActual);
        }
        
        public virtual void MapearADatos() 
        {
            Business.Entities.Especialidad especialidadActual = DevolverEspecialidad();
            switch (this.Modo)
            {
                case (ModoForm.Alta):
                    {
                        PlanActual = new Plan();
                        this.PlanActual.Descripcion = this.txtDescripcion.Text;
                        this.PlanActual.IDEspecialidad = especialidadActual.ID;
                        this.PlanActual.State = BusinessEntity.States.New;
                        break; 
                    }
                case (ModoForm.Modificacion):
                    {
                        this.PlanActual.Descripcion = this.txtDescripcion.Text;
                        this.PlanActual.IDEspecialidad = especialidadActual.ID;
                        this.PlanActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case (ModoForm.Baja):
                    {
                        this.PlanActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
                case (ModoForm.Consulta):
                    {
                        this.PlanActual.State = BusinessEntity.States.Unmodified;
                        break;
                    }
            }
        }

        private Especialidad DevolverEspecialidad()
        {
            return new EspecialidadLogic().GetOne(((Business.Entities.Especialidad)this.cmbIDEsp.SelectedValue).ID); ;
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

        private void PlanDesktop_Load(object sender, EventArgs e)
        {
            cmbIDEsp.DataSource = new EspecialidadLogic().GetAll();

            cmbIDEsp.DisplayMember = "descripcion";
            cmbIDEsp.ValueMember = "id_especialidad";
        }

        #endregion
    }
}
