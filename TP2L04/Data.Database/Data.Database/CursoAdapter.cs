using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.Database
{
    public class CursoAdapter: Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Curso> _Cursos;

        private static List<Curso> Cursos
        {
            get
            {
                if (_Cursos == null)
                {
                    _Cursos = new List<Business.Entities.Curso>();
                    Business.Entities.Curso cur;
                    cur = new Business.Entities.Curso();
                    cur.ID = 1;
                    cur.State = Business.Entities.BusinessEntity.States.Unmodified;
                    cur.IDMateria = 200;
                    cur.IDComision = 304;
                    cur.Descripcion = "Tecnologías de Desarrollo de Software IDE";
                    cur.Cupo = 30;
                    cur.AnioCalendario = 2014;
                    _Cursos.Add(cur);

                    cur = new Business.Entities.Curso();
                    cur.ID = 2;
                    cur.State = Business.Entities.BusinessEntity.States.Unmodified;
                    cur.IDMateria = 201;
                    cur.IDComision = 304;
                    cur.Descripcion = "JAVA";
                    cur.Cupo = 30;
                    cur.AnioCalendario = 2014;
                    _Cursos.Add(cur);

                    cur = new Business.Entities.Curso();
                    cur.ID = 3;
                    cur.State = Business.Entities.BusinessEntity.States.Unmodified;
                    cur.IDMateria = 203;
                    cur.IDComision = 304;
                    cur.Descripcion = "Gestión De Datos";
                    cur.Cupo = 40;
                    cur.AnioCalendario = 2014;
                    _Cursos.Add(cur);

                }
                return _Cursos;
            }
        }
        #endregion

        public List<Curso> GetAll()
        {
            return new List<Curso>(Cursos);
        }

        public Business.Entities.Curso GetOne(int ID)
        {
            return Cursos.Find(delegate(Curso u) { return u.ID == ID; });
        }

        public void Delete(int ID)
        {
            Cursos.Remove(this.GetOne(ID));
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Curso cur in Cursos)
                {
                    if (cur.ID > NextID)
                    {
                        NextID = cur.ID;
                    }
                }
                curso.ID = NextID + 1;
                Cursos.Add(curso);
            }
            else if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                Cursos[Cursos.FindIndex(delegate(Curso u) { return u.ID == curso.ID; })] = curso;
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
    }
}
