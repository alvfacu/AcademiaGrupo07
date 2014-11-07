using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.Database
{
    public class MateriaAdapter: Adapter
    {
        private static List<Materia> _Materia;

        private static List<Materia> Materia
        {
            get
            {
                if (_Materia == null)
                {
                    _Materia = new List<Business.Entities.Materia>();
                    Materia mat = new Materia();
                    mat.ID = 1;
                    mat.State = Business.Entities.BusinessEntity.States.Unmodified;
                    mat.Descripcion = "NNNNNN";
                    mat.HSSemanales = 4;
                    mat.HSTotales = 80;
                    mat.IDPlan = 1;
                    _Materia.Add(mat);

                    mat = new Materia();
                    mat.ID = 2;
                    mat.State = Business.Entities.BusinessEntity.States.Unmodified;
                    mat.Descripcion = "PPPPPPP";
                    mat.HSSemanales = 3;
                    mat.HSTotales = 20;
                    mat.IDPlan = 3;
                    _Materia.Add(mat);

                    mat = new Materia();
                    mat.ID = 45;
                    mat.State = Business.Entities.BusinessEntity.States.Unmodified;
                    mat.Descripcion = "XXXXXX";
                    mat.HSSemanales = 5;
                    mat.HSTotales = 125;
                    mat.IDPlan = 2;
                    _Materia.Add(mat);

                }
                return _Materia;
            }
        }

        public List<Materia> GetAll()
        {
            return new List<Materia>(Materia);
        }

        public Materia GetOne(int ID)
        {
            return Materia.Find(delegate(Materia mat) { return mat.ID == ID; });
        }

        public void Delete(int ID)
        {
            Materia.Remove(this.GetOne(ID));
        }

        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Materia mat in Materia)
                {
                    if (mat.ID > NextID)
                    {
                        NextID = mat.ID;
                    }
                }
                materia.ID = NextID + 1;
                Materia.Add(materia);
            }
            else if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                Materia[Materia.FindIndex(delegate(Materia mat) { return mat.ID == materia.ID; })] = materia;
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
    }
}
