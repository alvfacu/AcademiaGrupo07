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
            // no salen los comboboxs
        }

        public virtual void GuardarCambios()
        {
            try
            {
                MapearADatos();
                new CursoLogic().Save(CursoActual);
            }
            catch (ErrorEliminar ex)
            {
                Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public virtual void MapearADatos()
        {
            Business.Entities.Materia materiaActual = this.DevolverMateria();
            Business.Entities.Comision comisionActual = this.DevolverComision(); 

            switch (this.Modo)
            {
                case (ModoForm.Alta):
                    {
                        CursoActual = new Curso();
                        this.CursoActual.AnioCalendario = int.Parse(this.txtAnio.Text);
                        this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                        this.CursoActual.Descripcion =  this.txtDescripcion.Text;
                        this.CursoActual.IDComision = comisionActual.ID;
                        this.CursoActual.IDMateria = materiaActual.ID;
                        this.CursoActual.State = BusinessEntity.States.New;
                        break;
                    }
                case (ModoForm.Modificacion):
                    {
                        this.CursoActual.AnioCalendario = int.Parse(this.txtAnio.Text);
                        this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                        this.CursoActual.Descripcion = this.txtDescripcion.Text; 
                        this.CursoActual.IDComision = comisionActual.ID;
                        this.CursoActual.IDMateria = materiaActual.ID;
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

        private Comision DevolverComision()
        {
            return new ComisionLogic().GetOne(((Business.Entities.Comision)this.cmbIDCom.SelectedValue).ID);
        }

        private Materia DevolverMateria()
        {
            return new MateriaLogic().GetOne(((Business.Entities.Materia)this.cmbIDMat.SelectedValue).ID);
        }

        private int DevolverIDComision(string p)
        {
            List<Comision> comisiones = new ComisionLogic().GetAll();
            int id = 0;

            foreach (Comision com in comisiones)
            {
                if (String.Compare(p, com.Descripcion, true) == 0)
                {
                    id = com.ID;
                }
            }

            return id;
        }

        private int DevolverIDMateria(string p)
        {
            List<Materia> materias = new MateriaLogic().GetAll();
            int id = 0;

            foreach (Materia mat in materias)
            {
                if (String.Compare(p, mat.Descripcion, true) == 0)
                {
                    id = mat.ID;
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
            cmbIDCom.DataSource = new ComisionLogic().GetAll();
            cmbIDMat.DataSource = new MateriaLogic().GetAll();

            cmbIDCom.DisplayMember = "descripcion";
            cmbIDMat.DisplayMember = "descripcion";

            cmbIDCom.ValueMember = "id_comision";
            cmbIDMat.ValueMember = "id_materia";
            
        }

        #endregion
    }
}
