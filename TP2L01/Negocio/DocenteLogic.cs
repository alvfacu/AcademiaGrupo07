using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class DocenteLogic: BusinessLogic
    {
        private Data.Database.DocenteAdapter _DocenteData;

        public DocenteLogic()
        {
            DocenteData = new Data.Database.DocenteAdapter();
        }

        public Data.Database.DocenteAdapter DocenteData
        {
            get { return _DocenteData; }
            set { _DocenteData = value; }
        }

        public List<DocenteCurso> GetAll()
        {
            return DocenteData.GetAll();
        }

        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            return DocenteData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            DocenteData.Delete(ID);
        }

        public void Save(Business.Entities.DocenteCurso doc)
        {
            DocenteData.Save(doc);
        }
    }
}
