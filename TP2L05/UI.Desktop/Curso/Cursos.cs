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
    public partial class Cursos : Form
    {
        #region Constructores

        public Cursos()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }

        #endregion

        #region Metodos

        public void Listar()
        {
            CursoLogic cl = new CursoLogic();
            this.dgvCursos.DataSource = cl.GetAll();
        }

        #endregion

        #region Eventos

        private void Cursos_Load(object sender, EventArgs e)
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
            CursoDesktop formCurso = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formCurso.ShowDialog();
            this.Listar();
        }

        private void tbsEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(this.dgvCursos.SelectedRows == null))
                {
                    int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                    CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    formCurso.ShowDialog();
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
                if (!(this.dgvCursos.SelectedRows == null))
                {
                    int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                    CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja);
                    formCurso.ShowDialog();
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
