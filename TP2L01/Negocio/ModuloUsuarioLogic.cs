using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class ModuloUsuarioLogic: BusinessLogic
    {
        private ModuloUsuarioAdapter _ModUsuarioData;

        public ModuloUsuarioLogic()
        {
            ModUsuarioData = new ModuloUsuarioAdapter();
        }

        public ModuloUsuarioAdapter ModUsuarioData
        {
            get { return _ModUsuarioData; }
            set { _ModUsuarioData = value; }
        }

        public List<ModuloUsuario> GetAll()
        {
            return ModUsuarioData.GetAll();
        }

        public ModuloUsuario GetOne(int ID)
        {
            return ModUsuarioData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            ModUsuarioData.Delete(ID);
        }

        public void Save(ModuloUsuario mod)
        {
            ModUsuarioData.Save(mod);
        }
    }
}
