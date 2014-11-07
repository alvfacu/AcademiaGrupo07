using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class formPrincipal : Form
    {
        #region Constructores

        public formPrincipal()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formPrincipal_Shown(object sender, EventArgs e)
        {
            this.Show();
        }

        private void aBMUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios formUsuario = new Usuarios();
            formUsuario.ShowDialog();
        }

        private void aBMCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos formCurso = new Cursos();
            formCurso.ShowDialog();
        }

        private void aBMMateriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Materias formMateria = new Materias();
            formMateria.ShowDialog();
        }

        private void aBMPersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas formPersona = new Personas();
            formPersona.ShowDialog();
        }

        private void aBMEspecialidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especialidades formEspecialidad = new Especialidades();
            formEspecialidad.ShowDialog();
        }

        private void aBMAlumnoInscripciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnosInscripciones formAluInscripcion = new AlumnosInscripciones();
            formAluInscripcion.ShowDialog();
        }

        private void aBMModuloUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModulosUsuarios formModUsuarios = new ModulosUsuarios();
            formModUsuarios.ShowDialog();
        }

        private void aBMDocenteCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocentesCursos formDocCursos = new DocentesCursos();
            formDocCursos.ShowDialog();
        }

        private void aBMMóduloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modulos formModulos = new Modulos();
            formModulos.ShowDialog();
        }

        private void aBMPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planes formPlanes = new Planes();
            formPlanes.ShowDialog();
        }
        
        private void aBMComisiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comisiones formComisiones = new Comisiones();
            formComisiones.ShowDialog();
        }

        #endregion


    }
}
