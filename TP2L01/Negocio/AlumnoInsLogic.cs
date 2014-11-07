using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class AlumnoInsLogic: BusinessLogic
    {
        private AlumnoInsAdapter _AlumnoData;

        public AlumnoInsLogic()
        {
            AlumnoData = new AlumnoInsAdapter();
        }

        public AlumnoInsAdapter AlumnoData
        {
            get { return _AlumnoData; }
            set { _AlumnoData = value; }
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return AlumnoData.GetAll();
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            return AlumnoData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            AlumnoData.Delete(ID);
        }

        public void Save(AlumnoInscripcion alu)
        {
            AlumnoData.Save(alu);
        }
    }
}
