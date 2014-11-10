using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Base : System.Web.UI.Page
    {

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        protected int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        public void DeshabilitarOpciones()
        {
            var menu = (Menu)Page.Master.FindControl("menu");
            if (menu != null && (Session["logueo"] == null))
            {
                HabilitarOpciones(menu, false);
            }
            else if ((Session["logueo"] != null))
            {
                HabilitarOpciones(menu, true);
            }
        }

        public void HabilitarOpciones(Menu menu, bool enable)
        {
            menu.FindItem("Usuarios").Enabled = enable;
            menu.FindItem("Comisiones").Enabled = enable;
            menu.FindItem("Planes").Enabled = enable;
            menu.FindItem("Especialidades").Enabled = enable;
            menu.FindItem("Modulos").Enabled = enable;
            menu.FindItem("Cursos").Enabled = enable;
            menu.FindItem("Inscripciones").Enabled = enable;
            menu.FindItem("Docentes - Cursos").Enabled = enable;
            menu.FindItem("Materias").Enabled = enable;
            menu.FindItem("Modulos Usuario").Enabled = enable;
            menu.FindItem("Personas").Enabled = enable;            
        }

    }
}