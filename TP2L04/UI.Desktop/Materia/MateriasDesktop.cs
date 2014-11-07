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
using Data.Database;

namespace UI.Desktop
{
    public partial class MateriasDesktop : ApplicationForm
    {
        #region Variables

        private Materia _materiaActual;

        #endregion

        #region Constructores

        public MateriasDesktop()
        {
            InitializeComponent();
        }

        public MateriasDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
        }

        public MateriasDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            MateriaActual = new MateriaLogic().GetOne(ID);
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

        public Materia MateriaActual
        {
            get { return _materiaActual; }
            set { _materiaActual = value; }
        }

        #endregion

        #region Metodos

        public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion.ToString();
            this.txtHSSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHSTotales.Text = this.MateriaActual.HSTotales.ToString();
            this.cmbIDPlan.Text = this.MateriaActual.IDPlan.ToString();
        }

        public virtual void GuardarCambios()
        {
            MapearADatos();
            new MateriaLogic().Save(MateriaActual);
        }

        public virtual void MapearADatos()
        {

            switch (this.Modo)
            {
                case (ModoForm.Alta):
                    {
                        MateriaActual = new Materia();
                        this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                        this.MateriaActual.HSSemanales = int.Parse(this.txtHSSemanales.Text);
                        this.MateriaActual.HSTotales = int.Parse(this.txtHSTotales.Text);
                        this.MateriaActual.IDPlan = int.Parse(this.cmbIDPlan.Text);
                        this.MateriaActual.State = BusinessEntity.States.New;
                        break;
                    }
                case (ModoForm.Modificacion):
                    {
                        this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                        this.MateriaActual.HSSemanales = int.Parse(this.txtHSSemanales.Text);
                        this.MateriaActual.HSTotales = int.Parse(this.txtHSTotales.Text);
                        this.MateriaActual.IDPlan = int.Parse(this.cmbIDPlan.Text);
                        this.MateriaActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case (ModoForm.Baja):
                    {
                        this.MateriaActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
                case (ModoForm.Consulta):
                    {
                        this.MateriaActual.State = BusinessEntity.States.Unmodified;
                        break;
                    }
            }
        }

        public virtual bool Validar()
        {
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
                    else if (int.Parse(this.txtHSSemanales.Text) > int.Parse(this.txtHSTotales.Text))
                    {
                        estado = false;
                        Notificar("Ingreso incorrecto de horas", "Verifique el ingreso del nro de horas:\nEl nro de horas semanales es mayor que el nro de horas totales.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                return estado;
            }
            catch (FormatException fe)
            {
                Notificar("ERROR", "Formato de hora incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                estado = false;
            }
            catch (Exception e)
            {
                Notificar("ERROR", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                estado = false;
            }
            return estado;
        }

        /*MapearDeDatos va a ser utilizado en cada formulario para copiar la información de las entidades a los controles del formulario (TextBox,
          ComboBox, etc) para mostrar la infromación de cada entidad 
         * MapearADatos se va a utilizar para pasar la información de los controles a una entidad para luego enviarla a las capas inferiores
         * GuardarCambios es el método que se encargará de invocar al método correspondiente de la capa de negocio según sea el ModoForm en que se
         encuentre el formulario
         * Validar será el método que devuelva si los datos son válidos para poder registrar los cambios realizados. */


        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        /*Notificar es el método que utilizaremos para unificar el mecanismo de avisos al usuario y en caso de tener que modificar la forma en que se
          realizan los avisos al usuario sólo se debe modificar este método, en lugar de tener que reemplazarlo en toda la aplicación.*/
                
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

        private void MateriasDesktop_Load(object sender, EventArgs e)
        {
            List<Plan> lista = new PlanLogic().GetAll();
            List<String> id = new List<String>();
            foreach (Plan pl in lista)
            {
                id.Add(pl.ID.ToString());
            }
            cmbIDPlan.DataSource = id;
        }
        
        #endregion

    }
}
