using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class MateriaLogic: BusinessLogic
    {
        private MateriaAdapter _MateriaData;

        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        public MateriaAdapter MateriaData
        {
            get { return _MateriaData; }
            set { _MateriaData = value; }
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public Materia GetOne(int ID)
        {
            return MateriaData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            MateriaData.Delete(ID);
        }

        public void Save(Materia mat)
        {
            MateriaData.Save(mat);
        }
    }
}
