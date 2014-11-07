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
    public partial class DocentesCursos : Form
    {
        #region Constructores

        public DocentesCursos()
        {
            InitializeComponent();
            this.dgvDocentesCursos.AutoGenerateColumns = false;
        }

        #endregion

        #region Metodos

        public void Listar()
        {
            DocenteLogic dl = new DocenteLogic();
            this.dgvDocentesCursos.DataSource = dl.GetAll();  //asignaremos el resultado a la propiedad DataSource de la grilla
        }

        #endregion

        #region Eventos

        private void DocentesCursos_Load(object sender, EventArgs e)
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
            DocenteCursoDesktop formDocCur = new DocenteCursoDesktop(ApplicationForm.ModoForm.Alta);
            formDocCur.ShowDialog();
            this.Listar();
        }

        private void tbsEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(this.dgvDocentesCursos.SelectedRows == null))
                {
                    int ID = ((Business.Entities.DocenteCurso)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem).ID;
                    DocenteCursoDesktop formDocCur = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    formDocCur.ShowDialog();
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
                if (!(this.dgvDocentesCursos.SelectedRows == null))
                {
                    int ID = ((Business.Entities.DocenteCurso)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem).ID;
                    DocenteCursoDesktop formDocCur = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Baja);
                    formDocCur.ShowDialog();
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
