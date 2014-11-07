using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class EspecialidadLogic: BusinessLogic
    {
        private Data.Database.EspecialidadAdapter _EspecialidadData;

        public EspecialidadLogic()
        {
            EspecialidadData = new Data.Database.EspecialidadAdapter();
        }

        public Data.Database.EspecialidadAdapter EspecialidadData
        {
            get { return _EspecialidadData; }
            set { _EspecialidadData = value; }
        }

        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }

        public Business.Entities.Especialidad GetOne(int ID)
        {
            return EspecialidadData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            EspecialidadData.Delete(ID);
        }

        public void Save(Business.Entities.Especialidad esp)
        {
            EspecialidadData.Save(esp);
        }
    }
}
