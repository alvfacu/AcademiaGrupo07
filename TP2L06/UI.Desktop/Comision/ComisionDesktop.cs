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
    public partial class ComisionDesktop : ApplicationForm
    {
        #region Variables

        private Comision _comisionActual;

        #endregion

        #region Constructores

        public ComisionDesktop()
        {
            InitializeComponent();
        }

        public ComisionDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
        }

        public ComisionDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            ComisionActual = new ComisionLogic().GetOne(ID);
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

        public Comision ComisionActual
        {
            get { return _comisionActual; }
            set { _comisionActual = value; }
        }

        #endregion

        #region Metodos

        public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtAño.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.cmbIDPlan.Text = this.ComisionActual.IDPlan.ToString();
        }

        public virtual void GuardarCambios()
        {
            MapearADatos();
            new ComisionLogic().Save(ComisionActual);
        }

        public virtual void MapearADatos()
        {

            switch (this.Modo)
            {
                case (ModoForm.Alta):
                    {
                        ComisionActual = new Comision();
                        this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                        this.ComisionActual.IDPlan = DevolverIDPlan(this.cmbIDPlan.Text);
                        this.ComisionActual.AnioEspecialidad = int.Parse(this.txtAño.Text);
                        this.ComisionActual.State = BusinessEntity.States.New;
                        break;
                    }
                case (ModoForm.Modificacion):
                    {
                        this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                        this.ComisionActual.IDPlan = DevolverIDPlan(this.cmbIDPlan.Text);
                        this.ComisionActual.AnioEspecialidad = int.Parse(this.txtAño.Text);
                        this.ComisionActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case (ModoForm.Baja):
                    {
                        this.ComisionActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
                case (ModoForm.Consulta):
                    {
                        this.ComisionActual.State = BusinessEntity.States.Unmodified;
                        break;
                    }
            }
        }

        private int DevolverIDPlan(String p)
        {
            List<Plan> listaPlanes = new PlanLogic().GetAll();
            int id = 0;

            foreach (Plan pl in listaPlanes)
            {
                if (String.Compare(pl.Descripcion, p, true) == 0)
                {
                    id = pl.ID;
                }
            }

            return id;
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
                    else if (!(int.TryParse(this.txtAño.Text, out nro)))
                    {
                        estado = false;
                        Notificar("Error en el año ingresado", "Año de especialidad incorrecto. Verifique haber ingresado un año válido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (!(int.Parse(this.txtAño.Text) > 0))
                    {
                        estado = false;
                        Notificar("Error en el año ingresado", "Año de especialidad incorrecto. Verifique haber ingresado un número positivo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {
            List<Plan> listaPlanes = new PlanLogic().GetAll();
            List<String> plan = new List<String>();

            foreach (Plan pl in listaPlanes)
            {
                plan.Add(pl.Descripcion);
            }

            this.cmbIDPlan.DataSource = plan;
        }

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
