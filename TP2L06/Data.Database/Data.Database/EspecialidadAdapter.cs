using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EspecialidadAdapter: Adapter
    {
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades", sqlConn);

                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                while (drEspecialidades.Read())
                {
                    Especialidad esp = new Especialidad();

                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];

                    especialidades.Add(esp);
                }

                drEspecialidades.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de especialidades", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return especialidades;
        }

        public Business.Entities.Especialidad GetOne(int ID)
        {
            Especialidad esp = new Especialidad();

            try
            {
                this.OpenConnection();

                SqlCommand cmdEspecialidad = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad=@id", sqlConn);
                cmdEspecialidad.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drEspecialidades = cmdEspecialidad.ExecuteReader();

                if (drEspecialidades.Read())
                {
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                }

                drEspecialidades.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos de la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return esp;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE especialidades WHERE id_especialidad=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteReader();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al eliminar especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Especialidad espe)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE especialidades SET desc_especialidad=@desc_especialidad WHERE id_especialidad=@id_especialidad", sqlConn);

                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = espe.ID;
                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = espe.Descripcion;
                cmdSave.ExecuteReader();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Especialidad espe)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO especialidades(desc_especialidad) VALUES(@desc_especialidad) " +
                    "SELECT @@identity", //esta linea es para recuperar el ID que asignó el SQL automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = espe.Descripcion;
                espe.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); // asi se obtiene el ID que asigno al BD automaticamente
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Exception ExcepcionManejada = new Exception("Error al crear especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Especialidad espec)
        {
            if (espec.State == BusinessEntity.States.Deleted)
            {
                this.Delete(espec.ID);
            }
            else if (espec.State == BusinessEntity.States.New)
            {
                this.Insert(espec);
            }
            else if (espec.State == BusinessEntity.States.Modified)
            {
                this.Update(espec);
            }
            espec.State = BusinessEntity.States.Unmodified;
        }
    }
}
