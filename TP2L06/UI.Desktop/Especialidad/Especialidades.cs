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
    public partial class Especialidades : Form
    {
        #region Constructores

        public Especialidades()
        {
            InitializeComponent();
            this.dgvEspecialidades.AutoGenerateColumns = false;
        }

        #endregion

        #region Metodos

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
        }

        #endregion

        #region Eventos

        private void Especialidades_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbsNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void tbsEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(this.dgvEspecialidades.SelectedRows == null))
                {
                    int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                    EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    formEspecialidad.ShowDialog();
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
                if (!(this.dgvEspecialidades.SelectedRows == null))
                {
                    int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                    EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Baja);
                    formEspecialidad.ShowDialog();
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
