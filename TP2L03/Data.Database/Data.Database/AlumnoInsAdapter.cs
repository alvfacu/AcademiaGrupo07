using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.Database
{
    public class AlumnoInsAdapter: Adapter
    {

        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<AlumnoInscripcion> _Alumno;

        private static List<AlumnoInscripcion> Alumno
        {
            get
            {
                if (_Alumno == null)
                {
                    _Alumno = new List<Business.Entities.AlumnoInscripcion>();
                    Business.Entities.AlumnoInscripcion alu;
                    alu = new Business.Entities.AlumnoInscripcion();
                    alu.ID = 1;
                    alu.State = Business.Entities.BusinessEntity.States.Unmodified;
                    alu.IDAlumno = 40149;
                    alu.IDCurso = 01;
                    alu.Nota = 8;
                    alu.Condicion = "Regular";
                    _Alumno.Add(alu);

                    alu = new Business.Entities.AlumnoInscripcion();
                    alu.ID = 5;
                    alu.State = Business.Entities.BusinessEntity.States.Unmodified;
                    alu.IDAlumno = 39801;
                    alu.IDCurso = 23;
                    alu.Nota = 2;
                    alu.Condicion = "Recursa";
                    _Alumno.Add(alu);

                    alu = new Business.Entities.AlumnoInscripcion();
                    alu.ID = 4;
                    alu.State = Business.Entities.BusinessEntity.States.Unmodified;
                    alu.IDAlumno = 40404;
                    alu.IDCurso = 03;
                    alu.Nota = 10;
                    alu.Condicion = "Aprobado";
                    _Alumno.Add(alu);
                }
                return _Alumno;
            }
        }
        #endregion

        public List<AlumnoInscripcion> GetAll()
        {
            return new List<AlumnoInscripcion>(Alumno);
        }

        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            return Alumno.Find(delegate(AlumnoInscripcion alu) { return alu.ID == ID; });
        }

        public void Delete(int ID)
        {
            Alumno.Remove(this.GetOne(ID));
        }

        public void Save(AlumnoInscripcion alumno)
        {
            if (alumno.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (AlumnoInscripcion alu in Alumno)
                {
                    if (alu.ID > NextID)
                    {
                        NextID = alu.ID;
                    }
                }
                alumno.ID = NextID + 1;
                Alumno.Add(alumno);
            }
            else if (alumno.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alumno.ID);
            }
            else if (alumno.State == BusinessEntity.States.Modified)
            {
                Alumno[Alumno.FindIndex(delegate(AlumnoInscripcion alu) { return alu.ID == alumno.ID; })] = alumno;
            }
            alumno.State = BusinessEntity.States.Unmodified;
        }
    }
}
