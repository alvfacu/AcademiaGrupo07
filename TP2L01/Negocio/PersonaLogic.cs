using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class PersonaLogic: BusinessLogic
    {
        private Data.Database.PersonaAdapter _PersonaData;

        public PersonaLogic()
        {
            PersonaData = new Data.Database.PersonaAdapter();
        }

        public Data.Database.PersonaAdapter PersonaData
        {
            get { return _PersonaData; }
            set { _PersonaData = value; }
        }

        public List<Personas> GetAll()
        {
            return PersonaData.GetAll();
        }

        public Business.Entities.Personas GetOne(int ID)
        {
            return PersonaData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            PersonaData.Delete(ID);
        }

        public void Save(Business.Entities.Personas per)
        {
            PersonaData.Save(per);
        }

        public List<Personas> DevolverPersonasPorApeNom()
        {
            return PersonaData.GetAllPorApeNom();
        }
    }
}
