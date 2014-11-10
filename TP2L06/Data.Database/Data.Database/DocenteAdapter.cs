using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace Data.Database
{
    public class DocenteAdapter: Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docCursos = new List<DocenteCurso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdDocentes = new SqlCommand("SELECT * FROM docentes_cursos", sqlConn);

                SqlDataReader drDocentes = cmdDocentes.ExecuteReader();

                while (drDocentes.Read())
                {
                    DocenteCurso docCur = new DocenteCurso();

                    docCur.ID = (int)drDocentes["id_dictado"];
                    DocenteCurso.TiposCargos cargo = (DocenteCurso.TiposCargos)Enum.Parse(typeof(DocenteCurso.TiposCargos), Convert.ToString((int)drDocentes["cargo"]));
                    docCur.Cargo = cargo;
                    docCur.IDCurso = (int)drDocentes["id_curso"];
                    docCur.IDDocente = (int)drDocentes["id_docente"];
                    docCursos.Add(docCur);
                }

                drDocentes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de dictados de clase", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return docCursos;
        }

        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso docCur = new DocenteCurso();

            try
            {
                this.OpenConnection();

                SqlCommand cmdDocente = new SqlCommand("SELECT * FROM docentes_cursos WHERE id_dictado=@id", sqlConn);
                cmdDocente.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drDocentes = cmdDocente.ExecuteReader();

                if (drDocentes.Read())
                {
                    docCur.ID = (int)drDocentes["id_dictado"];
                    DocenteCurso.TiposCargos cargo = (DocenteCurso.TiposCargos)Enum.Parse(typeof(DocenteCurso.TiposCargos), Convert.ToString((int)drDocentes["cargo"]));
                    docCur.Cargo = cargo;
                    docCur.IDCurso = (int)drDocentes["id_curso"];
                    docCur.IDDocente = (int)drDocentes["id_docente"];
                }

                drDocentes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos del dictado de clase", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return docCur;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE docentes_cursos WHERE id_dictado=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteReader();
            }
            catch (Exception Ex)
            {
                ErrorEliminar miExp = new ErrorEliminar("No se puede eliminar el docente y su curso.", Ex);
                throw miExp;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso dictado)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO docentes_cursos(id_curso,id_docente,cargo) " +
                    "VALUES(@id_curso,@id_docente,@cargo) " +
                    "SELECT @@identity", //esta linea es para recuperar el ID que asignó el SQL automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = dictado.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = dictado.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = dictado.Cargo;
                dictado.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); // asi se obtiene el ID que asigno al BD automaticamente
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Exception ExcepcionManejada = new Exception("Error al crear dictado de clases", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(DocenteCurso dictado)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos SET id_curso=@id_curso, id_docente=@id_docente, " +
                    "cargo=@cargo " + "WHERE id_dictado=@id_dictado", sqlConn);

                cmdSave.Parameters.Add("@id_dictado", SqlDbType.Int).Value = dictado.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = dictado.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = dictado.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = dictado.Cargo;
                cmdSave.ExecuteReader();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del dictado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso dictado)
        {
            if (dictado.State == BusinessEntity.States.Deleted)
            {
                this.Delete(dictado.ID);
            }
            else if (dictado.State == BusinessEntity.States.New)
            {
                this.Insert(dictado);
            }
            else if (dictado.State == BusinessEntity.States.Modified)
            {
                this.Update(dictado);
            }
            dictado.State = BusinessEntity.States.Unmodified;
        }
    }
}
