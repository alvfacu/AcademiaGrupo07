using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Negocio;

namespace UI.Consola
{
    public class Materias
    {
        private MateriaLogic _MateriaNegocio;

       public MateriaLogic MateriaNegocio
       {
           get { return _MateriaNegocio; }
           set { _MateriaNegocio = value; } 
       }

       public Materias()
       {
           MateriaNegocio = new MateriaLogic();
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
           foreach (Materia mat in MateriaNegocio.GetAll())
           {
               MostrarDatos(mat);
           }
           Console.ReadKey();
       }

       public void MostrarDatos(Materia mat)
       {
          Console.WriteLine("ID Materia: {0}",mat.ID );
          Console.WriteLine("\t\tDescripción: {0}", mat.Descripcion);
          Console.WriteLine("\t\tHoras Semanales: {0}", mat.HSSemanales);
          Console.WriteLine("\t\tHoras Totales: {0}", mat.HSTotales);
          Console.WriteLine("\t\tID Plan: {0}", mat.IDPlan);
          Console.WriteLine();
       }

       public void Consultar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID de la Materia a consultar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(MateriaNegocio.GetOne(ID));
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
               Console.Write("Ingrese el ID de la Materia a modificar: ");
               int ID = int.Parse(Console.ReadLine());
               Materia mat = MateriaNegocio.GetOne(ID);
               if (mat == null)
               {
                   Console.WriteLine("No existe Materia con ID ingresado.");
               }
               else
               {
                   new Planes().ListadoGeneral();
                   Console.Write("Ingrese ID Plan: ");
                   mat.IDPlan = int.Parse(Console.ReadLine());
                   Console.Write("Ingrese Descripción: ");
                   mat.Descripcion = Console.ReadLine();
                   Console.Write("Ingrese Horas Semanales: ");
                   mat.HSSemanales = int.Parse(Console.ReadLine());
                   Console.Write("Ingrese Horas Totales: ");
                   mat.HSTotales = int.Parse(Console.ReadLine());
                   mat.State = BusinessEntity.States.Modified;
                   MateriaNegocio.Save(mat);
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
           Materia mat = new Materia();

           new Planes().ListadoGeneral();
           Console.Write("Ingrese ID Plan: ");
           mat.IDPlan = int.Parse(Console.ReadLine());
           Console.Write("Ingrese Descripción: ");
           mat.Descripcion = Console.ReadLine();
           Console.Write("Ingrese Horas Semanales: ");
           mat.HSSemanales = int.Parse(Console.ReadLine());
           Console.Write("Ingrese Horas Semanales: ");
           mat.HSSemanales = int.Parse(Console.ReadLine());;
           MateriaNegocio.Save(mat);
           Console.WriteLine();
           Console.WriteLine("ID Materia: {0}", mat.ID);
           Console.ReadKey();
       }

       public void Eliminar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID de la Materia a eliminar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(MateriaNegocio.GetOne(ID));
               MateriaNegocio.Delete(ID);
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
