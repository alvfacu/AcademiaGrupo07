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
    public partial class Materias : Form
    {
        #region Constructores

        public Materias()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        }

        #endregion

        #region Metodos

        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            this.dgvMaterias.DataSource = ml.GetAll();
        }

        #endregion

        #region Eventos

        private void Materias_Load(object sender, EventArgs e)
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
            MateriasDesktop formMateria = new MateriasDesktop(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tbsEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(this.dgvMaterias.SelectedRows == null))
                {
                    int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                    MateriasDesktop formMateria = new MateriasDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    formMateria.ShowDialog();
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
                if (!(this.dgvMaterias.SelectedRows == null))
                {
                    int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                    MateriasDesktop formMateria = new MateriasDesktop(ID, ApplicationForm.ModoForm.Baja);
                    formMateria.ShowDialog();
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
