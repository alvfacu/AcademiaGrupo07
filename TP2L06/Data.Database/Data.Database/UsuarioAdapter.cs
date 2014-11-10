using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios", sqlConn);

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];
                    Personas persona = new PersonaAdapter().GetOne((int)drUsuarios["id_persona"]);
                    usr.Per = persona;

                    usuarios.Add(usr);
                }

                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return usuarios;
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();

            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuario = new SqlCommand("SELECT * FROM usuarios WHERE id_usuario=@id", sqlConn);
                cmdUsuario.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drUsuarios = cmdUsuario.ExecuteReader();

                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];
                    Personas persona = new PersonaAdapter().GetOne((int)drUsuarios["id_persona"]);
                    usr.Per = persona;
                }

                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return usr;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE usuarios WHERE id_usuario=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteReader();
            }
            catch (Exception Ex)
            {
                ErrorEliminar miExcep = new ErrorEliminar("No se puede eliminar el usuario.");
                throw miExcep;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario=@nombre_usuario, clave=@clave, " +
                    "habilitado=@habilitado, nombre=@nombre, apellido=@apellido, email=@email, id_persona=@id_persona " +
                    "WHERE id_usuario=@id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar,50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.Per.ID;
                cmdSave.ExecuteReader();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO usuarios(nombre_usuario,clave,habilitado,nombre,apellido,email,id_persona) " +
                    "VALUES(@nombre_usuario,@clave,@habilitado,@nombre,@apellido,@email,@id_persona) " +
                    "SELECT @@identity", //esta linea es para recuperar el ID que asignó el SQL automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.Per.ID;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); // asi se obtiene el ID que asigno al BD automaticamente
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
       
        public Usuario GetOneByUsuario(string nombreUsr)
        {
            Usuario usr = null;

            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuario = new SqlCommand("SELECT * FROM usuarios WHERE nombre_usuario=@usuario", sqlConn);
                cmdUsuario.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = nombreUsr;

                SqlDataReader drUsuarios = cmdUsuario.ExecuteReader();

                if (drUsuarios.Read())
                {
                    usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];
                    Personas persona = new PersonaAdapter().GetOne((int)drUsuarios["id_persona"]);
                    usr.Per = persona;
                }

                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return usr;
        }

       
    }
}
