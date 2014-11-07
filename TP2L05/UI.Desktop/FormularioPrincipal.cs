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
            Login formLogin = new Login();
            if (formLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
            else
            {
                //HabilitarOpciones(formLogin.UsuarioLogueado.Per.TipoPersona);
            }
        }

        private void HabilitarOpciones()
        {
            throw new NotImplementedException();
        }
                
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Usuarios formUsuario = new Usuarios();
            formUsuario.ShowDialog();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos formCurso = new Cursos();
            formCurso.ShowDialog();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Materias formMateria = new Materias();
            formMateria.ShowDialog();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas formPersona = new Personas();
            formPersona.ShowDialog();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comisiones formComisiones = new Comisiones();
            formComisiones.ShowDialog();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planes formPlanes = new Planes();
            formPlanes.ShowDialog();
        }

        private void modulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modulos formModulos = new Modulos();
            formModulos.ShowDialog();
        }

        private void especialidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especialidades formEspecialidad = new Especialidades();
            formEspecialidad.ShowDialog();
        }

        private void alumnoInscripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnosInscripciones formAluInscripcion = new AlumnosInscripciones();
            formAluInscripcion.ShowDialog();
        }

        private void moduloUsuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ModulosUsuarios formModulosUsr = new ModulosUsuarios();
            formModulosUsr.ShowDialog();
        }

        private void docenteCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocentesCursos formDocCursos = new DocentesCursos();
            formDocCursos.ShowDialog();
        }

        #endregion
    }
}
