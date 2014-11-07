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
    public partial class Comisiones : Form
    {
        #region Constructores

        public Comisiones()
        {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
        }

        #endregion

        #region Metodos

        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            this.dgvComisiones.DataSource = cl.GetAll();
        }

        #endregion

        #region Eventos

        private void Comisiones_Load(object sender, EventArgs e)
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
            ComisionDesktop formComision = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formComision.ShowDialog();
            this.Listar();
        }

        private void tbsEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(this.dgvComisiones.SelectedRows == null))
                {
                    int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                    ComisionDesktop formComision = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    formComision.ShowDialog();
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
                if (!(this.dgvComisiones.SelectedRows == null))
                {
                    int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                    ComisionDesktop formComision = new ComisionDesktop(ID, ApplicationForm.ModoForm.Baja);
                    formComision.ShowDialog();
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
