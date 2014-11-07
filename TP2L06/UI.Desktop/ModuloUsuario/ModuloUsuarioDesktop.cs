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
    public partial class ModuloUsuarioDesktop : ApplicationForm
    {
        #region Variables

        private ModuloUsuario _moduloUsrActual;

        #endregion

        #region Constructores

        public ModuloUsuarioDesktop()
        {
            InitializeComponent();
        }

        public ModuloUsuarioDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
        }

        public ModuloUsuarioDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            ModuloUsrActual = new ModuloUsuarioLogic().GetOne(ID);
            MapearDeDatos();
            switch (modo)
            {
                case (ModoForm.Alta): this.btnAceptar.Text = "Guardar";
                    break;
                case (ModoForm.Modificacion): this.btnAceptar.Text = "Guardar";
                    break;
                case (ModoForm.Baja): this.btnAceptar.Text = "Eliminar";
                    break;
                case (ModoForm.Consulta): this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        #endregion

        #region Propiedades

        public ModuloUsuario ModuloUsrActual
        {
            get { return _moduloUsrActual; }
            set { _moduloUsrActual = value; }
        }

        #endregion

        #region Metodos

        public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.ModuloUsrActual.ID.ToString();
            this.txtIDUsr.Text = this.ModuloUsrActual.IdUsuario.ToString();
            this.cmbIDMod.Text = this.ModuloUsrActual.IdModulo.ToString();
            this.chkAlta.Checked = this.ModuloUsrActual.PermiteAlta;
            this.chkBaja.Checked = this.ModuloUsrActual.PermiteBaja;
            this.chkConsulta.Checked = this.ModuloUsrActual.PermiteConsulta;
            this.chkMod.Checked = this.ModuloUsrActual.PermiteModificacion;
        }

        public virtual void GuardarCambios()
        {
            MapearADatos();
            new ModuloUsuarioLogic().Save(ModuloUsrActual);
        }

        public virtual void MapearADatos()
        {
            switch (this.Modo)
            {
                case (ModoForm.Alta):
                    {
                        ModuloUsrActual = new ModuloUsuario();
                        this.ModuloUsrActual.IdUsuario = int.Parse(this.txtIDUsr.Text);
                        this.ModuloUsrActual.IdModulo = DevolverIDModulo(this.cmbIDMod.Text);
                        this.ModuloUsrActual.PermiteAlta = this.chkAlta.Checked;
                        this.ModuloUsrActual.PermiteBaja = this.chkBaja.Checked;
                        this.ModuloUsrActual.PermiteConsulta = this.chkConsulta.Checked;
                        this.ModuloUsrActual.PermiteModificacion = this.chkMod.Checked;
                        this.ModuloUsrActual.State = BusinessEntity.States.New;
                        break;
                    }
                case (ModoForm.Modificacion):
                    {
                        this.ModuloUsrActual.IdUsuario = int.Parse(this.txtIDUsr.Text);
                        this.ModuloUsrActual.IdModulo = DevolverIDModulo(this.cmbIDMod.Text);
                        this.ModuloUsrActual.PermiteAlta = this.chkAlta.Checked;
                        this.ModuloUsrActual.PermiteBaja = this.chkBaja.Checked;
                        this.ModuloUsrActual.PermiteConsulta = this.chkConsulta.Checked;
                        this.ModuloUsrActual.PermiteModificacion = this.chkMod.Checked;
                        this.ModuloUsrActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case (ModoForm.Baja):
                    {
                        this.ModuloUsrActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
                case (ModoForm.Consulta):
                    {
                        this.ModuloUsrActual.State = BusinessEntity.States.Unmodified;
                        break;
                    }
            }
        }

        private int DevolverIDModulo(string p)
        {
            List<Modulo> modulos = new ModuloLogic().GetAll();
            int id = 0;

            foreach (Modulo mod in modulos)
            {
                if (String.Compare(p, mod.Descripcion, true) == 0)
                {
                    id = mod.ID;
                }
            }

            return id;
        }

        public virtual bool Validar()
        {
            int nro;
            Boolean estado = true;
            if (!(this.Modo == ModoForm.Baja))
            {
                foreach (Control control in this.tableLayoutPanel1.Controls)
                {
                    if (!(control == txtID))
                    {
                        if (control is TextBox && control.Text == String.Empty)
                        {
                            estado = false;
                        }
                    }

                }
                if (estado == false)
                {
                    Notificar("Campos vacíos", "Existen campos sin completar.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (int.TryParse(this.txtIDUsr.Text, out nro))
                {
                    List<Usuario> listaUsuarios = new UsuarioLogic().GetAll();
                    int id = int.Parse(this.txtIDUsr.Text);
                    bool est = false;
                    foreach (Usuario usr in listaUsuarios)
                    {
                        if (usr.ID == id)
                        {
                            est = true;
                            estado = true;
                        }
                        else if (est != true)
                        {
                            estado = false;
                        }
                    }
                    if (estado == false)
                    {
                        Notificar("ID Usuario inexistente", "El ID Usuario ingresado no corresponde a un Usuario registrado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return estado;
        }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        #endregion

        #region Eventos

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ModuloUsuarioDesktop_Load(object sender, EventArgs e)
        {
            List<Modulo> listaModulo = new ModuloLogic().GetAll();
            List<String> mods = new List<String>();
            foreach (Modulo mod in listaModulo)
            {
                mods.Add(mod.Descripcion);
            }
            
            cmbIDMod.DataSource = mods;

        }

        #endregion
    }
}
