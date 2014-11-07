using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Personas> _Personas;

        private static List<Personas> Personas
        {
            get
            {
                if (_Personas == null)
                {
                    _Personas = new List<Business.Entities.Personas>();
                    Business.Entities.Personas per;
                    per = new Business.Entities.Personas();
                    per.ID = 1;
                    per.State = Business.Entities.BusinessEntity.States.Unmodified;
                    per.Nombre = "Facundo";
                    per.Apellido = "Alvarez";
                    per.Direccion = "Corrientes 2179";
                    per.Legajo = 40149;
                    per.Telefono = "156353157";
                    per.IDPlan = 01;
                    per.Email = "alvfacu@gmail.com";
                      string fecha = "1993,12,17";
                      DateTime fechaNacimiento = new DateTime();
                      fechaNacimiento = DateTime.Parse(fecha);
                      per.FechaNacimiento = fechaNacimiento;
                    _Personas.Add(per);

                    per = new Business.Entities.Personas();
                    per.ID = 2;
                    per.State = Business.Entities.BusinessEntity.States.Unmodified;
                    per.Nombre = "Matias";
                    per.Apellido = "Gentiletti";
                    per.Direccion = "Moreno 1879";
                    per.Legajo = 39881;
                    per.Telefono = "152343454";
                    per.IDPlan = 05;
                    per.Email = "matias.gentiletti@gmail.com";
                    per.FechaNacimiento = DateTime.Parse("1992,06,26");
                    _Personas.Add(per);

                    per = new Business.Entities.Personas();
                    per.ID = 3;
                    per.State = Business.Entities.BusinessEntity.States.Unmodified;
                    per.Nombre = "Martin";
                    per.Apellido = "Guereta";
                    per.Direccion = "Buenos Aires 1614";
                    per.Legajo = 40243;
                    per.Telefono = "155770650";
                    per.IDPlan = 01;
                    per.Email = "martin.guereta@outlook.com";
                    per.FechaNacimiento = DateTime.Parse("1994,02,24");
                    _Personas.Add(per);

                }
                return _Personas;
            }
        }
        #endregion

        public List<Personas> GetAll()
        {
            return new List<Personas>(Personas);
        }

        public Business.Entities.Personas GetOne(int ID)
        {
            return Personas.Find(delegate(Personas pe) { return pe.ID == ID; });
        }

        public void Delete(int ID)
        {
            Personas.Remove(this.GetOne(ID));
        }

        public void Save(Personas persona)
        {
            if (persona.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Personas pe in Personas)
                {
                    if (pe.ID > NextID)
                    {
                        NextID = pe.ID;
                    }
                }
                persona.ID = NextID + 1;
                Personas.Add(persona);
            }
            else if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                Personas[Personas.FindIndex(delegate(Personas pe) { return pe.ID == persona.ID; })] = persona;
            }
            persona.State = BusinessEntity.States.Unmodified;
        }
    }
}
