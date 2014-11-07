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
    public partial class Planes : Form
    {
        #region Constructores

        public Planes()
        {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
        }

        #endregion

        #region Metodos

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            this.dgvPlanes.DataSource = pl.GetAll();  //asignaremos el resultado a la propiedad DataSource de la grilla
        }

        #endregion

        #region Eventos

        private void Planes_Load(object sender, EventArgs e)
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
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tbsEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(this.dgvPlanes.SelectedRows == null))
                {
                    int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                    PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    formPlan.ShowDialog();
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
                if (!(this.dgvPlanes.SelectedRows == null))
                {
                    int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                    PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Baja);
                    formPlan.ShowDialog();
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
