using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class UsuarioLogic: BusinessLogic
    {
        private Data.Database.UsuarioAdapter _UsuarioData;

        public UsuarioLogic()
        {
            UsuarioData = new Data.Database.UsuarioAdapter();
        }

        public Data.Database.UsuarioAdapter UsuarioData
        {
            get { return _UsuarioData; }
            set { _UsuarioData = value; } 
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            return UsuarioData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
        }

        public void Save(Business.Entities.Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }

        //Prueba para sin IDPersona
        public void SaveDos(Business.Entities.Usuario usuario)
        {
            UsuarioData.UpdateDos(usuario);
        }

        public Usuario GetOneByUsuario(string p)
        {
            return UsuarioData.GetOneByUsuario(p);
        }
    }
}
