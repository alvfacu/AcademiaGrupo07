using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;

namespace UI.Web
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (((Session["logueo"] != null)))
                {
                    this.panelUsuario.Visible = true;
                    this.ingresar.Visible = false;
                    var usuarioLabel = (Label)this.panelUsuario.FindControl("nombreUsr");
                    usuarioLabel.Text = (((Usuario)Session["logueo"]).Per.Nombre)+" "+(((Usuario)Session["logueo"]).Per.Apellido);
                }
            }
        }

        protected void linkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");           
        }

        protected void ingresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void salir_Click(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("Default.aspx");

        }

    }
}
