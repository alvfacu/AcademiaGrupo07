using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Negocio;

namespace UI.Consola
{
    public class Especialidades
    {
       private Negocio.EspecialidadLogic _EspecialidadNegocio;

       public Negocio.EspecialidadLogic EspecialidadNegocio
       {
           get { return _EspecialidadNegocio; }
           set { _EspecialidadNegocio = value; } 
       }

       public Especialidades()
       {
           EspecialidadNegocio = new Negocio.EspecialidadLogic();
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
           foreach (Especialidad esp in EspecialidadNegocio.GetAll())
           {
               MostrarDatos(esp);
           };
       }

       public void MostrarDatos(Especialidad esp)
       {
          Console.WriteLine("ID Especialidad: {0}", esp.ID);
          Console.WriteLine("\t\tDescripción: {0}", esp.Descripcion);
          Console.WriteLine();
       }

       public void Consultar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID de la Especialidad a consultar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(EspecialidadNegocio.GetOne(ID));
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
               Console.Write("Ingrese el ID de la Especialidad a modificar: ");
               int ID = int.Parse(Console.ReadLine());
               Especialidad esp = EspecialidadNegocio.GetOne(ID);
               if (esp == null)
               {
                   Console.WriteLine("No existe Especialidad con ese ID.");
               }
               else
               {
                   Console.Write("Ingrese Descripción: ");
                   esp.Descripcion = Console.ReadLine();
                   esp.State = BusinessEntity.States.Modified;
                   EspecialidadNegocio.Save(esp);
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
           Especialidad esp = new Especialidad();

           Console.Clear();
           Console.Write("Ingrese Descripción de la Especialidad: ");
           esp.Descripcion = Console.ReadLine();
           EspecialidadNegocio.Save(esp);
           Console.WriteLine();
           Console.WriteLine("ID: {0}", esp.ID);
           Console.ReadKey();
       }

       public void Eliminar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID de la Especialidad a eliminar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(EspecialidadNegocio.GetOne(ID));
               EspecialidadNegocio.Delete(ID);
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
