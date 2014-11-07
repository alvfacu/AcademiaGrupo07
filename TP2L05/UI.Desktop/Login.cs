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
    public partial class Login : Form
    {
        public Usuario usuarioLogueado;

        public Usuario UsuarioLogueado
        {
            get { return usuarioLogueado; }
            set { usuarioLogueado = value; }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!(txtUsuario == null || txtUsuario.Text == String.Empty) || !(txtPass == null || txtPass.Text == String.Empty))
            {
                usuarioLogueado = new UsuarioLogic().GetOneByUsuario(txtUsuario.Text);

                if (usuarioLogueado == null)
                {
                    MessageBox.Show("Se ha ingresado un nombre de usuario inexistente en la Academia.", "Usuario incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!(txtPass.Text.CompareTo(usuarioLogueado.Clave) == 0))
                    {
                        MessageBox.Show("La contraseña es incorrecta.", "Contraseña incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Bienvenido/a: " + usuarioLogueado.Nombre + " " + usuarioLogueado.Apellido, "Login correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            else
            {
                MessageBox.Show("Existen campos sin completar.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria o contáctese con el Administrador", "Olvidé mi contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }
                
    }
}
