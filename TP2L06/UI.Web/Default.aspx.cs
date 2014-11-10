using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Negocio;

namespace UI.Web
{
    public partial class Default : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeshabilitarOpciones();
            if ((Session["logueo"] != null))
            {
                this.anonimoPrincpal.Visible = false;
                this.usuarioPrincipal.Visible = true;
                this.usuarioBienvenido.Text = (((Usuario)Session["logueo"]).Per.Nombre)+" "+(((Usuario)Session["logueo"]).Per.Apellido) ;
            }
        }
    }
}