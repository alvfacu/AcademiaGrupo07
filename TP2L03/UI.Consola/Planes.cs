using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Negocio;

namespace UI.Consola
{
    public class Planes
    {
       private Negocio.PlanLogic _PlanNegocio;

       public Negocio.PlanLogic PlanNegocio
       {
           get { return _PlanNegocio; }
           set { _PlanNegocio = value; } 
       }

       public Planes()
       {
           PlanNegocio = new Negocio.PlanLogic();
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
           foreach (Plan plan in PlanNegocio.GetAll())
           {
               MostrarDatos(plan);
           }
       }

       public void MostrarDatos(Plan plan)
       {
          Console.WriteLine("ID Plan: {0}", plan.ID);
          Console.WriteLine("\t\tDescripción:: {0}", plan.Descripcion);
          Console.WriteLine("\t\tID Especialidad: {0}", plan.IDEspecialidad);
          Console.WriteLine();
       }

       public void Consultar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID del Plan a consultar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(PlanNegocio.GetOne(ID));
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
               Console.Write("Ingrese el ID del Plan a modificar: ");
               int ID = int.Parse(Console.ReadLine());
               Plan plan = PlanNegocio.GetOne(ID);
               if (plan == null)
               {
                   Console.WriteLine("No existe Inscripcion.");
               }
               else
               {
                   Especialidades esp = new Especialidades();
                   esp.ListadoGeneral();
                   Console.Write("Ingrese ID de la Especialidad: ");
                   plan.IDEspecialidad = int.Parse(Console.ReadLine());
                   Console.Write("Ingrese Descripción: ");
                   plan.Descripcion = Console.ReadLine();
                   plan.State = BusinessEntity.States.Modified;
                   PlanNegocio.Save(plan);
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
           Plan plan = new Plan();

           Especialidades esp = new Especialidades();
           esp.ListadoGeneral();
           Console.Write("Ingrese el ID de la Especilidad: ");
           plan.IDEspecialidad = int.Parse(Console.ReadLine());
           Console.Write("Ingrese Descripción: ");
           plan.Descripcion = Console.ReadLine();
           PlanNegocio.Save(plan);
           Console.WriteLine();
           Console.WriteLine("ID Plan: {0}", plan.ID);
           Console.ReadKey();
       }

       public void Eliminar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID del Plan a eliminar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(PlanNegocio.GetOne(ID));
               PlanNegocio.Delete(ID);
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
