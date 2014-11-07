using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Negocio;

namespace UI.Consola
{
    public class Modulos
    {
        private ModuloLogic _ModuloNegocio;

       public ModuloLogic ModuloNegocio
       {
           get { return _ModuloNegocio; }
           set { _ModuloNegocio = value; } 
       }

       public Modulos()
       {
           ModuloNegocio = new ModuloLogic();
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
           foreach (Modulo mod in ModuloNegocio.GetAll())
           {
               MostrarDatos(mod);
           }
       }

       public void MostrarDatos(Modulo mod)
       {
          Console.WriteLine("ID Modulo: {0}",mod.ID );
          Console.WriteLine("\t\tDescripcion: {0}", mod.Descripcion);
          Console.WriteLine();
       }

       public void Consultar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID del Módulo a consultar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(ModuloNegocio.GetOne(ID));
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
               Console.Write("Ingrese el ID del Módulo a modificar: ");
               int ID = int.Parse(Console.ReadLine());
               Modulo modulo = ModuloNegocio.GetOne(ID);
               if (modulo == null)
               { 
                   Console.WriteLine("No existe Especialidad"); 
               }
               else
               {
                   Console.Write("Ingrese nueva descripción: ");
                   modulo.Descripcion = Console.ReadLine();
                   modulo.State = BusinessEntity.States.Modified;
                   ModuloNegocio.Save(modulo);
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
           Modulo modulo = new Modulo();

           Console.Clear();
           Console.Write("Ingrese Descripción del nuevo Modulo: ");
           modulo.Descripcion = Console.ReadLine();
           ModuloNegocio.Save(modulo);
           Console.WriteLine();
           Console.WriteLine("ID: {0}", modulo.ID);
           Console.ReadKey();
       }

       public void Eliminar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID del Módulo a eliminar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(ModuloNegocio.GetOne(ID));
               ModuloNegocio.Delete(ID);
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
