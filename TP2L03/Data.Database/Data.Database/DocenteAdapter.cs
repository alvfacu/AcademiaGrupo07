using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.Database
{
    public class DocenteAdapter: Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<DocenteCurso> _Docente;

        private static List<DocenteCurso> Docente
        {
            get
            {
                if (_Docente == null)
                {
                    _Docente = new List<Business.Entities.DocenteCurso>();
                    Business.Entities.DocenteCurso doc;
                    doc = new Business.Entities.DocenteCurso();
                    doc.ID = 1;
                    doc.State = Business.Entities.BusinessEntity.States.Unmodified;
                    doc.Cargo = DocenteCurso.TiposCargos.A;
                    doc.IDCurso = 1;
                    doc.IDDocente = 20010;
                    _Docente.Add(doc);

                    doc = new Business.Entities.DocenteCurso();
                    doc.ID = 2;
                    doc.State = Business.Entities.BusinessEntity.States.Unmodified;
                    doc.Cargo = DocenteCurso.TiposCargos.B;
                    doc.IDCurso = 2;
                    doc.IDDocente = 23033;
                    _Docente.Add(doc);

                    doc = new Business.Entities.DocenteCurso();
                    doc.ID = 3;
                    doc.State = Business.Entities.BusinessEntity.States.Unmodified;
                    doc.Cargo = DocenteCurso.TiposCargos.C;
                    doc.IDCurso = 4;
                    doc.IDDocente = 112234;
                    _Docente.Add(doc);
                }
                return _Docente;
            }
        }
        #endregion

        public List<DocenteCurso> GetAll()
        {
            return new List<DocenteCurso>(Docente);
        }

        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            return Docente.Find(delegate(DocenteCurso doc) { return doc.ID == ID; });
        }

        public void Delete(int ID)
        {
            Docente.Remove(this.GetOne(ID));
        }

        public void Save(DocenteCurso docente)
        {
            if (docente.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (DocenteCurso doc in Docente)
                {
                    if (doc.ID > NextID)
                    {
                        NextID = doc.ID;
                    }
                }
                docente.ID = NextID + 1;
                Docente.Add(docente);
            }
            else if (docente.State == BusinessEntity.States.Deleted)
            {
                this.Delete(docente.ID);
            }
            else if (docente.State == BusinessEntity.States.Modified)
            {
                Docente[Docente.FindIndex(delegate(DocenteCurso u) { return u.ID == docente.ID; })] = docente;
            }
            docente.State = BusinessEntity.States.Unmodified;
        }
    }
}
