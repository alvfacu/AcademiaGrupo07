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
    public class MateriaAdapter: Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias", sqlConn);

                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();

                    mat.ID = (int)drMaterias["id_materia"];
                    mat.IDPlan = (int)drMaterias["id_plan"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];

                    materias.Add(mat);
                }

                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return materias;
        }

        public Materia GetOne(int ID)
        {
            Materia mat = new Materia();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMateria = new SqlCommand("SELECT * FROM materias WHERE id_materia=@id", sqlConn);
                cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drMaterias = cmdMateria.ExecuteReader();

                if (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.IDPlan = (int)drMaterias["id_plan"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                }

                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return mat;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE materias WHERE id_materia=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteReader();
            }
            catch (Exception Ex)
            {
                ErrorEliminar miExp = new ErrorEliminar("No se puede eliminar la materia.", Ex);
                throw miExp;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Materia mat)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET desc_materia=@desc_materia, hs_semanales=@hs_semanales, hs_totales=@hs_totales, id_plan=@id_plan WHERE id_materia=@id_materia", sqlConn);

                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = mat.ID;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = mat.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = mat.HSTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.IDPlan;
                cmdSave.ExecuteReader();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Materia mat)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO materias(desc_materia,hs_semanales,hs_totales,id_plan) VALUES(@desc_materia,@hs_semanales,@hs_totales,@id_plan) " +
                    "SELECT @@identity", //esta linea es para recuperar el ID que asignó el SQL automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = mat.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = mat.HSTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.IDPlan;
                mat.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); // asi se obtiene el ID que asigno al BD automaticamente
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Exception ExcepcionManejada = new Exception("Error al crear materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.New)
            {
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
    }
}
