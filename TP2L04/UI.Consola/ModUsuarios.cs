using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Negocio;

namespace UI.Consola
{
    public class ModUsuarios
    {
       private Negocio.ModuloUsuarioLogic _ModuloUsuarioNegocio;

       public Negocio.ModuloUsuarioLogic ModuloUsuarioNegocio
       {
           get { return _ModuloUsuarioNegocio; }
           set { _ModuloUsuarioNegocio = value; } 
       }

       public ModUsuarios()
       {
           ModuloUsuarioNegocio = new Negocio.ModuloUsuarioLogic();
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
                       case 1: this.ListadoGeneral(); break;
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
           foreach (ModuloUsuario mu in ModuloUsuarioNegocio.GetAll())
           {
               MostrarDatos(mu);
           }
           Console.ReadKey();
       }

       public void MostrarDatos(ModuloUsuario mu)
       {
          Console.WriteLine("Modulo Usuario: {0}",mu.ID );
          Console.WriteLine("\t\tID Modulo: {0}", mu.IdModulo);
          Console.WriteLine("\t\tID Usuario: {0}", mu.IdUsuario);
          Console.WriteLine("\t\t\tPermite Alta: {0}", mu.PermiteAlta);
          Console.WriteLine("\t\t\tPermite Baja: {0}", mu.PermiteBaja);
          Console.WriteLine("\t\t\tPermite Modificacion: {0}", mu.PermiteModificacion);
          Console.WriteLine("\t\t\tPermite Consulta: {0}", mu.PermiteConsulta);
          Console.WriteLine();
       }

       public void Consultar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID de Modulo-Usuario a consultar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(ModuloUsuarioNegocio.GetOne(ID));
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
               Console.Write("Ingrese el ID del Modulo-Usuario a modificar: ");
               int ID = int.Parse(Console.ReadLine());
               ModuloUsuario mod = ModuloUsuarioNegocio.GetOne(ID);
               if (mod == null)
               {
                   Console.WriteLine("No existe Modulo-Usuario con ID ingresado.");
               }
               else
               {
                   new Modulos().ListadoGeneral();
                   Console.Write("Ingrese ID del Modulo: ");
                   mod.IdModulo = int.Parse(Console.ReadLine());
                   new Usuarios().ListadoGeneral();
                   Console.Write("Ingrese ID del Usuario: ");
                   mod.IdUsuario = int.Parse(Console.ReadLine());
                   this.PermitirABMC(mod);
                   mod.State = BusinessEntity.States.Modified;
                   ModuloUsuarioNegocio.Save(mod);
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
           ModuloUsuario mod = new ModuloUsuario();

           Console.Clear();
           Console.Write("Ingrese ID del Modulo: ");
           mod.IdModulo = int.Parse(Console.ReadLine());
           Console.Write("Ingrese ID del Usuario: ");
           mod.IdUsuario = int.Parse(Console.ReadLine());
           this.PermitirABMC(mod);
           ModuloUsuarioNegocio.Save(mod);
           Console.WriteLine();
           Console.WriteLine("ID Modulo-Usuario: {0}", mod.ID);
           Console.ReadKey();
       }

       public void Eliminar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID del Modulo-Usuario a eliminar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(ModuloUsuarioNegocio.GetOne(ID));
               ModuloUsuarioNegocio.Delete(ID);
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

       public void PermitirABMC(ModuloUsuario mod)
       {
           Console.Write("Permite Alta 1-Si/Otro-No: ");
           if (Console.ReadLine() == "1")
               mod.PermiteAlta = true;
           Console.Write("Permite Baja 1-Si/Otro-No: ");
           if (Console.ReadLine() == "1")
               mod.PermiteBaja = true;
           Console.Write("Permite Modificacion 1-Si/Otro-No: ");
           if (Console.ReadLine() == "1")
               mod.PermiteModificacion = true;
           Console.Write("Permite Consulta 1-Si/Otro-No: ");
           if (Console.ReadLine() == "1")
               mod.PermiteConsulta = true;
       }

    }
}
