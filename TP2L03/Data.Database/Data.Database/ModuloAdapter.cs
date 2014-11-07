using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.Database
{
    public class ModuloAdapter: Adapter
    {
        private static List<Modulo> _Modulo;

        private static List<Modulo> Modulo
        {
            get
            {
                if (_Modulo == null)
                {
                    _Modulo = new List<Business.Entities.Modulo>();
                    Business.Entities.Modulo modu;
                    modu = new Business.Entities.Modulo();
                    modu.ID = 1;
                    modu.State = Business.Entities.BusinessEntity.States.Unmodified;
                    modu.Descripcion = "Modulo A";
                    _Modulo.Add(modu);

                    modu = new Business.Entities.Modulo();
                    modu.ID = 2;
                    modu.State = Business.Entities.BusinessEntity.States.Unmodified;
                    modu.Descripcion = "Modulo B";
                    _Modulo.Add(modu);

                    modu = new Business.Entities.Modulo();
                    modu.ID = 3;
                    modu.State = Business.Entities.BusinessEntity.States.Unmodified;
                    modu.Descripcion = "Modulo C";
                    _Modulo.Add(modu);
                   
                }
                return _Modulo;
            }
        }
        
        public List<Modulo> GetAll()
        {
            return new List<Modulo>(Modulo);
        }

        public Business.Entities.Modulo GetOne(int ID)
        {
            return Modulo.Find(delegate(Modulo modu) { return modu.ID == ID; });
        }

        public void Delete(int ID)
        {
            Modulo.Remove(this.GetOne(ID));
        }

        public void Save(Modulo modulo)
        {
            if (modulo.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Modulo modu in Modulo)
                {
                    if (modu.ID > NextID)
                    {
                        NextID = modu.ID;
                    }
                }
                modulo.ID = NextID + 1;
                Modulo.Add(modulo);
            }
            else if (modulo.State == BusinessEntity.States.Deleted)
            {
                this.Delete(modulo.ID);
            }
            else if (modulo.State == BusinessEntity.States.Modified)
            {
                Modulo[Modulo.FindIndex(delegate(Business.Entities.Modulo mod) { return mod.ID == modulo.ID; })] = modulo;
            }
            modulo.State = BusinessEntity.States.Unmodified;
        }
    }
}
