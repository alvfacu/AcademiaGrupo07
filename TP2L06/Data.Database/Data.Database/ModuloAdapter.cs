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
    public class ModuloAdapter : Adapter
    {
        public List<Modulo> GetAll()
        {
            List<Modulo> modulos = new List<Modulo>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdModulos = new SqlCommand("SELECT * FROM modulos", sqlConn);

                SqlDataReader drModulos = cmdModulos.ExecuteReader();

                while (drModulos.Read())
                {
                    Modulo mod = new Modulo();

                    mod.ID = (int)drModulos["id_modulo"];
                    mod.Descripcion = (string)drModulos["desc_modulo"];
                    modulos.Add(mod);
                }

                drModulos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de modulos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return modulos;
        }

        public Modulo GetOne(int ID)
        {
            Modulo mod = new Modulo();

            try
            {
                this.OpenConnection();

                SqlCommand cmdModulo = new SqlCommand("SELECT * FROM modulos WHERE id_modulo=@id", sqlConn);
                cmdModulo.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drModulos = cmdModulo.ExecuteReader();

                if (drModulos.Read())
                {
                    mod.ID = (int)drModulos["id_modulo"];
                    mod.Descripcion = (string)drModulos["desc_modulo"];
                }

                drModulos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos del modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return mod;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE modulos WHERE id_modulo=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteReader();
            }
            catch (Exception Ex)
            {
                ErrorEliminar miExp = new ErrorEliminar("No se puede eliminar el módulo.", Ex);
                throw miExp;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Modulo modu)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO modulos(desc_modulo) VALUES(@desc_modulo) SELECT @@identity", sqlConn);

                cmdSave.Parameters.Add("@desc_modulo", SqlDbType.VarChar, 50).Value = modu.Descripcion;
                modu.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); // asi se obtiene el ID que asigno al BD automaticamente
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Exception ExcepcionManejada = new Exception("Error al crear modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Modulo modu)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE modulos SET desc_modulo=@desc_modulo WHERE id_modulo=@id_modulo", sqlConn);

                cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = modu.ID;
                cmdSave.Parameters.Add("@desc_modulo", SqlDbType.VarChar, 50).Value = modu.Descripcion;
                cmdSave.ExecuteReader();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Modulo modu)
        {
            if (modu.State == BusinessEntity.States.Deleted)
            {
                this.Delete(modu.ID);
            }
            else if (modu.State == BusinessEntity.States.New)
            {
                this.Insert(modu);
            }
            else if (modu.State == BusinessEntity.States.Modified)
            {
                this.Update(modu);
            }
            modu.State = BusinessEntity.States.Unmodified;
        }


    }
}
