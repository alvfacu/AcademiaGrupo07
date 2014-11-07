using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Negocio;

namespace UI.Consola
{
    public class Comisiones
    {
       private Negocio.ComisionLogic _ComisionNegocio;

       public Negocio.ComisionLogic ComisionNegocio
       {
           get { return _ComisionNegocio; }
           set { _ComisionNegocio = value; } 
       }

       public Comisiones()
       {
           ComisionNegocio = new Negocio.ComisionLogic();
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
           foreach (Comision com in ComisionNegocio.GetAll())
           {
               MostrarDatos(com);
           }
           Console.ReadKey();
       }

       public void MostrarDatos(Comision com)
       {
          Console.WriteLine("ID Comision: {0}",com.ID );
          Console.WriteLine("\t\tDescripción: {0}", com.Descripcion);
          Console.WriteLine("\t\tAño Especialidad: {0}", com.AnioEspecialidad);
          Console.WriteLine("\t\tID Plan: {0}", com.IDPlan);
          Console.WriteLine();
       }

       public void Consultar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID de la Comisión a consultar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(ComisionNegocio.GetOne(ID));
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
               Console.Write("Ingrese el ID de la Comision a modificar: ");
               int ID = int.Parse(Console.ReadLine());
               Comision com = ComisionNegocio.GetOne(ID);
               if (com == null)
               {
                   Console.WriteLine("No existe Comision con ID ingresado.");
               }
               else
               {
                   new Planes().ListadoGeneral();
                   Console.Write("Ingrese ID Plan: ");
                   com.IDPlan = int.Parse(Console.ReadLine());
                   Console.Write("Ingrese Descripción: ");
                   com.Descripcion = Console.ReadLine();
                   Console.Write("Ingrese Año Especialidad: ");
                   com.AnioEspecialidad = int.Parse(Console.ReadLine());
                   com.State = BusinessEntity.States.Modified;
                   ComisionNegocio.Save(com);
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
           Comision com = new Comision();

           new Planes().ListadoGeneral();
           Console.Write("Ingrese ID Plan: ");
           com.IDPlan = int.Parse(Console.ReadLine());
           Console.Write("Ingrese Descripción: ");
           com.Descripcion = Console.ReadLine();
           Console.Write("Ingrese Año Especialidad: ");
           com.AnioEspecialidad = int.Parse(Console.ReadLine());
           ComisionNegocio.Save(com);
           Console.WriteLine();
           Console.WriteLine("ID Comisión: {0}", com.ID);
           Console.ReadKey();
       }

       public void Eliminar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID de la Comision a eliminar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(ComisionNegocio.GetOne(ID));
               ComisionNegocio.Delete(ID);
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
