using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoInsAdapter: Adapter
    {
        
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdInscripciones = new SqlCommand("SELECT * FROM alumnos_inscripciones", sqlConn);

                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();

                while (drInscripciones.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();

                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.IDAlumno = (int)drInscripciones["id_alumno"];
                    ins.IDCurso = (int)drInscripciones["id_curso"];
                    ins.Condicion = (string)drInscripciones["condicion"];

                    if (drInscripciones.IsDBNull(drInscripciones.GetOrdinal("nota")))
                    {
                        ins.Nota = 0;
                    }
                    else
                    {
                        ins.Nota = (int)drInscripciones["nota"];
                    }
                    
                    inscripciones.Add(ins);
                }

                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return inscripciones;
        }

        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion ins = new AlumnoInscripcion();

            try
            {
                this.OpenConnection();

                SqlCommand cmdInscripciones = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_inscripcion=@id", sqlConn);
                cmdInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();

                if (drInscripciones.Read())
                {
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.IDAlumno = (int)drInscripciones["id_alumno"];
                    ins.IDCurso = (int)drInscripciones["id_curso"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    if (drInscripciones.IsDBNull(drInscripciones.GetOrdinal("nota")))
                    {
                        ins.Nota = 0;
                    }
                    else
                    {
                        ins.Nota = (int)drInscripciones["nota"];
                    }
                }

                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos de inscripción", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return ins;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE alumnos_inscripciones WHERE id_inscripcion=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteReader();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al eliminar inscripción", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET id_alumno=@id_alumno, id_curso=@id_curso, " +
                    "condicion=@condicion, nota=@nota " + "WHERE id_inscripcion=@id_inscripcion", sqlConn);

                cmdSave.Parameters.Add("@id_inscripcion", SqlDbType.Int).Value = inscripcion.ID;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdSave.ExecuteReader();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la inscripción", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO alumnos_inscripciones(id_alumno,id_curso,nota,condicion) " +
                    "VALUES(@id_alumno,@id_curso,@nota,@condicion) " +
                    "SELECT @@identity", //esta linea es para recuperar el ID que asignó el SQL automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                inscripcion.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); // asi se obtiene el ID que asigno al BD automaticamente
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Exception ExcepcionManejada = new Exception("Error al crear inscripción", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion inscripcion)
        {
            if (inscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(inscripcion.ID);
            }
            else if (inscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(inscripcion);
            }
            else if (inscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(inscripcion);
            }
            inscripcion.State = BusinessEntity.States.Unmodified;
        }


    }
}
