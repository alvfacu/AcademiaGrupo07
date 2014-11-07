using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.Database
{
    public class ComisionAdapter: Adapter
    {
        private static List<Comision> _Comision;

        private static List<Comision> Comision
        {
            get
            {
                if (_Comision == null)
                {
                    _Comision = new List<Business.Entities.Comision>();
                    Comision com = new Comision();
                    com.ID = 1;
                    com.State = Business.Entities.BusinessEntity.States.Unmodified;
                    com.AnioEspecialidad = 3;
                    com.IDPlan = 2;
                    com.Descripcion = "NNNN";
                    _Comision.Add(com);

                    com = new Comision();
                    com.ID = 2;
                    com.State = Business.Entities.BusinessEntity.States.Unmodified;
                    com.AnioEspecialidad = 4;
                    com.IDPlan = 1112;
                    com.Descripcion = "MMMM";
                    _Comision.Add(com);

                    com = new Comision();
                    com.ID = 4;
                    com.State = Business.Entities.BusinessEntity.States.Unmodified;
                    com.AnioEspecialidad = 2;
                    com.IDPlan = 3;
                    com.Descripcion = "BBBBB";
                    _Comision.Add(com);

                }
                return _Comision;
            }
        }

        public List<Comision> GetAll()
        {
            return new List<Comision>(Comision);
        }

        public Business.Entities.Comision GetOne(int ID)
        {
            return Comision.Find(delegate(Comision c) { return c.ID == ID; });
        }

        public void Delete(int ID)
        {
            Comision.Remove(this.GetOne(ID));
        }

        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Comision com in Comision)
                {
                    if (com.ID > NextID)
                    {
                        NextID = com.ID;
                    }
                }
                comision.ID = NextID + 1;
                Comision.Add(comision);
            }
            else if (comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comision.ID);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                Comision[Comision.FindIndex(delegate(Comision c) { return c.ID == comision.ID; })] = comision;
            }
            comision.State = BusinessEntity.States.Unmodified;
        }
    }
}
