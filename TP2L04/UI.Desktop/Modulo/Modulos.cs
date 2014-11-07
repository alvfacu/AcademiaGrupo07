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
    public partial class Modulos : Form
    {
        #region Constructores

        public Modulos()
        {
            InitializeComponent();
            this.dgvModulos.AutoGenerateColumns = false;
        }

        #endregion

        #region Metodos

        public void Listar()
        {
            ModuloLogic ml = new ModuloLogic();
            this.dgvModulos.DataSource = ml.GetAll();
        }

        #endregion

        #region Eventos

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Modulos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tbsNuevo_Click(object sender, EventArgs e)
        {
            ModuloDesktop formModulo = new ModuloDesktop(ApplicationForm.ModoForm.Alta);
            formModulo.ShowDialog();
            this.Listar();
        }

        private void tbsEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(this.dgvModulos.SelectedRows == null))
                {
                    int ID = ((Business.Entities.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).ID;
                    ModuloDesktop formModulo = new ModuloDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    formModulo.ShowDialog();
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
                if (!(this.dgvModulos.SelectedRows == null))
                {
                    int ID = ((Business.Entities.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).ID;
                    ModuloDesktop formModulo = new ModuloDesktop(ID, ApplicationForm.ModoForm.Baja);
                    formModulo.ShowDialog();
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
