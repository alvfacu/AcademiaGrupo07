using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Business.Entities;

namespace UI.Web
{
    public partial class Login : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeshabilitarOpciones();
        }

        protected void ingresarButton_Click(object sender, EventArgs e)
        {
            Usuario usuarioActual = new UsuarioLogic().ValidarUsuario(this.usuarioTextBox.Text, this.claveTextBox.Text);

            if (usuarioActual == null)
            {
                this.Label1.Text = "Ingreso incorrecto. Verifique haber ingresado correctamente los datos del loguin.";
            }
            else
            {
                Session["logueo"] = usuarioActual;  //crea una variable de sesion (visible en todas las webs)
                Response.Redirect("Default.aspx");
            }
        }
    }
}
