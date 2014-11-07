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
    public partial class ModulosUsuarios : Form
    {
        #region Constructores

        public ModulosUsuarios()
        {
            InitializeComponent();
            this.dgvModulosUsuarios.AutoGenerateColumns = false;
        }

        #endregion

        #region Metodos

        public void Listar()
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            this.dgvModulosUsuarios.DataSource = mul.GetAll();  //asignaremos el resultado a la propiedad DataSource de la grilla
        }

        #endregion

        #region Eventos

        private void Modulos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }


        private void tbsNuevo_Click(object sender, EventArgs e)
        {
            ModuloUsuarioDesktop formModUsuario = new ModuloUsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formModUsuario.ShowDialog();
            this.Listar();
        }

        private void tbsEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(this.dgvModulosUsuarios.SelectedRows == null))
                {
                    int ID = ((Business.Entities.ModuloUsuario)this.dgvModulosUsuarios.SelectedRows[0].DataBoundItem).ID;
                    ModuloUsuarioDesktop formModUsuario = new ModuloUsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    formModUsuario.ShowDialog();
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
                if (!(this.dgvModulosUsuarios.SelectedRows == null))
                {
                    int ID = ((Business.Entities.ModuloUsuario)this.dgvModulosUsuarios.SelectedRows[0].DataBoundItem).ID;
                    ModuloUsuarioDesktop formModUsuario = new ModuloUsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                    formModUsuario.ShowDialog();
                    this.Listar();
                }
            }
            catch (ArgumentOutOfRangeException ef)
            {
                MessageBox.Show("No existen registros a eliminar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
