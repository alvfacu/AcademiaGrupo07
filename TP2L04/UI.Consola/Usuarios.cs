using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Negocio;

namespace UI.Consola
{
   public class Usuarios
   {
       private Negocio.UsuarioLogic _UsuarioNegocio;

       public Negocio.UsuarioLogic UsuarioNegocio
       {
           get { return _UsuarioNegocio; }
           set { _UsuarioNegocio = value; } 
       }

       public Usuarios()
       {
           UsuarioNegocio = new Negocio.UsuarioLogic();
       }
       
       public void Menu()
       {
           try
           {
               int aux;
               Console.WriteLine("Ingrese opción que desea ejecutar: ");
               Console.WriteLine("1– Listado General\n2– Consulta\n3– Modificar\n4- Agregar\n5- Eliminar\n6- Salir\n");
               do
               {
                   aux = int.Parse(Console.ReadLine());
                   switch (aux)
                   {
                       case 1: this.ListadoGeneral(); Console.ReadKey(); break;
                       case 2: this.Consultar(); break;
                       case 3: this.Modificar(); break;
                       case 4: this.Agregar(); break;
                       case 5: this.Eliminar(); break;
                   }
                   Console.Clear();
                   Console.WriteLine("Ingrese opción que desea ejecutar: ");
                   Console.WriteLine("1– Listado General\n2– Consulta\n3– Modificar\n4- Agregar\n5- Eliminar\n6- Salir\n");
               } while (aux < 6);
           }
           catch (Exception e)
           {
               Console.WriteLine();
               Console.WriteLine(e.Message);
               Console.ReadKey();
           }
       }

       public void ListadoGeneral()
       {
           Console.Clear();
           foreach (Usuario usr in UsuarioNegocio.GetAll())
           {
               MostrarDatos(usr);
           }
       }

       public void MostrarDatos(Usuario usr)
       {
          Console.WriteLine("ID Usuario: {0}",usr.ID );
          Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
          Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
          Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
          Console.WriteLine("\t\tClave: {0}", usr.Clave);
          Console.WriteLine("\t\tEmail: {0}", usr.EMail);
          Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
          Console.WriteLine();
       }

       public void Consultar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID del Usuario a consultar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(UsuarioNegocio.GetOne(ID));
           }
           catch (FormatException fe)
           {
               Console.WriteLine();
               Console.WriteLine("La ID ingresada debe ser un número entero.");
           }
           catch (Exception e)
           {
               Console.WriteLine();
               Console.WriteLine(e.Message);
           }
           finally
           {
               Console.WriteLine();
               Console.WriteLine("Presione una tecla para continuar...");
               Console.ReadKey();
           }
       }

       public void Modificar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID del Usuario a modificar: ");
               int ID = int.Parse(Console.ReadLine());
               Usuario usuario = UsuarioNegocio.GetOne(ID);
               if (usuario == null)
               {
                   Console.WriteLine("No existe Alumno con ID ingresado.");
               }
               else
               {
                   Console.Write("Ingrese Nombre: ");
                   usuario.Nombre = Console.ReadLine();
                   Console.Write("Ingerse Apellido: ");
                   usuario.Apellido = Console.ReadLine();
                   Console.Write("Ingrese Nombre de Usuario: ");
                   usuario.NombreUsuario = Console.ReadLine();
                   Console.Write("Ingrese Clave: ");
                   usuario.Clave = Console.ReadLine();
                   Console.Write("Ingrese Email: ");
                   usuario.EMail = Console.ReadLine();
                   Console.Write("Ingrese Habilitación de Usuario (1-Si/Otro-No): ");
                   usuario.Habilitado = (Console.ReadLine() == "1");
                   usuario.State = BusinessEntity.States.Modified;
                   UsuarioNegocio.Save(usuario);
               }
           }
           catch (FormatException fe)
           {
               Console.WriteLine();
               Console.WriteLine("La ID ingresada debe ser un número entero.");
           }
           catch (Exception e)
           {
               Console.WriteLine();
               Console.WriteLine(e.Message);
           }
           finally
           {
               Console.WriteLine("Presione una tecla para continuar...");
               Console.ReadKey();
           }
       }

       public void Agregar()
       {
           Usuario usuario = new Usuario();

           Console.Clear();
           Console.Write("Ingrese Nombre: ");
           usuario.Nombre = Console.ReadLine();
           Console.Write("Ingrese Apellido: ");
           usuario.Apellido = Console.ReadLine();
           Console.Write("Ingrese Nombre de Usuario: ");
           usuario.NombreUsuario = Console.ReadLine();
           Console.Write("Ingrese Clave: ");
           usuario.Clave = Console.ReadLine();
           Console.Write("Ingrese Email: ");
           usuario.EMail = Console.ReadLine();
           Console.Write("Ingrese Habilitación de Usuario (1-Si/Otro-No): ");
           usuario.Habilitado = (Console.ReadLine() == "1");
           UsuarioNegocio.Save(usuario);
           Console.WriteLine();
           Console.WriteLine("ID: {0}", usuario.ID);
           Console.ReadKey();
       }

       public void Eliminar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID del Usuario a eliminar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(UsuarioNegocio.GetOne(ID));
               UsuarioNegocio.Delete(ID);
           }
           catch (FormatException fe)
           {
               Console.WriteLine();
               Console.WriteLine("La ID ingresada debser un número entero.");
           }
           catch (Exception e)
           {
               Console.WriteLine();
               Console.WriteLine(e.Message);
           }
           finally
           {
               Console.WriteLine();
               Console.WriteLine("Presione una tecla para continuar...");
               Console.ReadKey();
           }
       }

    }
}
