using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class CursoLogic : BusinessLogic
    {
        private Data.Database.CursoAdapter _CursoData;

        public CursoLogic()
        {
            CursoData = new Data.Database.CursoAdapter();
        }

        public Data.Database.CursoAdapter CursoData
        {
            get { return _CursoData; }
            set { _CursoData = value; }
        }

        public List<Curso> GetAll()
        {
            return CursoData.GetAll();
        }

        public Business.Entities.Curso GetOne(int ID)
        {
            return CursoData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            CursoData.Delete(ID);
        }

        public void Save(Business.Entities.Curso cur)
        {
            CursoData.Save(cur);
        }
    }
}
