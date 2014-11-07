using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class ModuloLogic : BusinessLogic
    {
        private ModuloAdapter _ModuloData;

        public ModuloLogic()
        {
            ModuloData = new ModuloAdapter();
        }

        public ModuloAdapter ModuloData
        {
            get { return _ModuloData; }
            set { _ModuloData = value; }
        }

        public List<Modulo> GetAll()
        {
            return ModuloData.GetAll();
        }

        public Modulo GetOne(int ID)
        {
            return ModuloData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            ModuloData.Delete(ID);
        }

        public void Save(Modulo modu)
        {
            ModuloData.Save(modu);
        }
    }
}
