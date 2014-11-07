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
    public partial class AlumnosInscripciones : Form
    {
        #region Constructores

        public AlumnosInscripciones()
        {
            InitializeComponent();
            this.dgvInscripciones.AutoGenerateColumns = false;
        }

        #endregion

        #region Metodos

        public void Listar()
        {
            AlumnoInsLogic ail = new AlumnoInsLogic();
            this.dgvInscripciones.DataSource = ail.GetAll();  //asignaremos el resultado a la propiedad DataSource de la grilla
        }

        #endregion

        #region Eventos

        private void AlumnosInscripciones_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbsNuevo_Click(object sender, EventArgs e)
        {
            AluInscripcionDesktop formAluInscrip = new AluInscripcionDesktop(ApplicationForm.ModoForm.Alta);
            formAluInscrip.ShowDialog();
            this.Listar();
        }

        private void tbsEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(this.dgvInscripciones.SelectedRows == null))
                {
                    int ID = ((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
                    AluInscripcionDesktop formAluInscrip = new AluInscripcionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    formAluInscrip.ShowDialog();
                    this.Listar();
                }
            }
            catch (ArgumentOutOfRangeException ef)
            {
                MessageBox.Show("No existen registros a editar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbsEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(this.dgvInscripciones.SelectedRows == null))
                {
                    int ID = ((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
                    AluInscripcionDesktop formAluInscrip = new AluInscripcionDesktop(ID, ApplicationForm.ModoForm.Baja);
                    formAluInscrip.ShowDialog();
                    this.Listar();
                }
            }
            catch (ArgumentOutOfRangeException ef)
            {
                MessageBox.Show("No existen registros a eliminar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
