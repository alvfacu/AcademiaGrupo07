using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.Database
{
    public class ModuloUsuarioAdapter: Adapter
    {
        private static List<ModuloUsuario> _ModUsuario;

        private static List<ModuloUsuario> ModUsuario
        {
            get
            {
                if (_ModUsuario == null)
                {
                    _ModUsuario = new List<Business.Entities.ModuloUsuario>();
                    ModuloUsuario mod = new ModuloUsuario();
                    mod.ID = 888888;
                    mod.State = Business.Entities.BusinessEntity.States.Unmodified;
                    mod.IdModulo = 1;
                    mod.IdUsuario = 1;
                    mod.PermiteAlta = true;
                    mod.PermiteBaja = true;
                    mod.PermiteConsulta = true;
                    mod.PermiteModificacion = true;
                    _ModUsuario.Add(mod);

                    mod = new ModuloUsuario();
                    mod.ID = 2;
                    mod.State = Business.Entities.BusinessEntity.States.Unmodified;
                    mod.IdModulo = 2;
                    mod.IdUsuario = 1;
                    mod.PermiteAlta = false;
                    mod.PermiteBaja = false;
                    mod.PermiteConsulta = true;
                    mod.PermiteModificacion = false;
                    _ModUsuario.Add(mod);

                    mod = new ModuloUsuario();
                    mod.ID = 3;
                    mod.State = Business.Entities.BusinessEntity.States.Unmodified;
                    mod.IdModulo = 3;
                    mod.IdUsuario = 3;
                    mod.PermiteAlta = false;
                    mod.PermiteBaja = false;
                    mod.PermiteConsulta = false;
                    mod.PermiteModificacion = false;
                    _ModUsuario.Add(mod);

                }
                return _ModUsuario;
            }
        }

        public List<ModuloUsuario> GetAll()
        {
            return new List<ModuloUsuario>(ModUsuario);
        }

        public Business.Entities.ModuloUsuario GetOne(int ID)
        {
            return ModUsuario.Find(delegate(ModuloUsuario mod) { return mod.ID == ID; });
        }

        public void Delete(int ID)
        {
            ModUsuario.Remove(this.GetOne(ID));
        }

        public void Save(ModuloUsuario modulo)
        {
            if (modulo.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (ModuloUsuario mod in ModUsuario)
                {
                    if (mod.ID > NextID)
                    {
                        NextID = mod.ID;
                    }
                }
                modulo.ID = NextID + 1;
                ModUsuario.Add(modulo);
            }
            else if (modulo.State == BusinessEntity.States.Deleted)
            {
                this.Delete(modulo.ID);
            }
            else if (modulo.State == BusinessEntity.States.Modified)
            {
                ModUsuario[ModUsuario.FindIndex(delegate(ModuloUsuario mod) { return mod.ID == modulo.ID; })] = modulo;
            }
            modulo.State = BusinessEntity.States.Unmodified;
        }
    }
}
