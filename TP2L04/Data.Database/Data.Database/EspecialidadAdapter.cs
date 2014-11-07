using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.Database
{
    public class EspecialidadAdapter: Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Especialidad> _Especialidad;

        private static List<Especialidad> Especialidad
        {
            get
            {
                if (_Especialidad == null)
                {
                    _Especialidad = new List<Business.Entities.Especialidad>();
                    Business.Entities.Especialidad esp;
                    esp = new Business.Entities.Especialidad();
                    esp.ID = 1;
                    esp.State = Business.Entities.BusinessEntity.States.Unmodified;
                    esp.Descripcion = "A";
                    _Especialidad.Add(esp);

                    esp = new Business.Entities.Especialidad();
                    esp.ID = 3;
                    esp.State = Business.Entities.BusinessEntity.States.Unmodified;
                    esp.Descripcion = "B";
                    _Especialidad.Add(esp);

                    esp = new Business.Entities.Especialidad();
                    esp.ID = 1112;
                    esp.State = Business.Entities.BusinessEntity.States.Unmodified;
                    esp.Descripcion = "C";
                    _Especialidad.Add(esp);
                }
                return _Especialidad;
            }
        }
        #endregion

        public List<Especialidad> GetAll()
        {
            return new List<Especialidad>(Especialidad);
        }

        public Business.Entities.Especialidad GetOne(int ID)
        {
            return Especialidad.Find(delegate(Business.Entities.Especialidad esp) { return esp.ID == ID; });
        }

        public void Delete(int ID)
        {
            Especialidad.Remove(this.GetOne(ID));
        }

        public void Save(Business.Entities.Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Business.Entities.Especialidad esp in Especialidad)
                {
                    if (esp.ID > NextID)
                    {
                        NextID = esp.ID;
                    }
                }
                especialidad.ID = NextID + 1;
                Especialidad.Add(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                Especialidad[Especialidad.FindIndex(delegate(Business.Entities.Especialidad esp) { return esp.ID == especialidad.ID; })] = especialidad;
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }
    }
}
