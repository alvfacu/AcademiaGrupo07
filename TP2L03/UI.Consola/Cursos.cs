using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Negocio;

namespace UI.Consola
{
    public class Cursos
    {
       private Negocio.CursoLogic _CursoNegocio;

       public Negocio.CursoLogic CursoNegocio
       {
           get { return _CursoNegocio; }
           set { _CursoNegocio = value; } 
       }

       public Cursos()
       {
           CursoNegocio = new Negocio.CursoLogic();
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
           foreach (Curso cur in CursoNegocio.GetAll())
           {
               MostrarDatos(cur);
           }
       }

       public void MostrarDatos(Curso cur)
       {
          Console.WriteLine("ID Curso: {0}",cur.ID );
          Console.WriteLine("\t\tID Materia: {0}", cur.IDMateria);
          Console.WriteLine("\t\tID Comisión: {0}", cur.IDComision);
          Console.WriteLine("\t\tDescripcion: {0}", cur.Descripcion);
          Console.WriteLine("\t\tCupo: {0}", cur.Cupo);
          Console.WriteLine("\t\tAño Calendario: {0}", cur.AnioCalendario);
          Console.WriteLine();
       }

       public void Consultar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID del Curso a consultar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(CursoNegocio.GetOne(ID));
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
               Console.Write("Ingrese el ID del Curso a modificar: ");
               int ID = int.Parse(Console.ReadLine());
               Curso cur = CursoNegocio.GetOne(ID);
               if (cur == null)
               {
                   Console.WriteLine("No existe Curso con ID ingresado.");
               }
               else
               {
                   new Materias().ListadoGeneral();
                   Console.Write("Ingrese ID de Materia");
                   cur.IDMateria = int.Parse(Console.ReadLine());
                   new Comisiones().Menu();
                   Console.Write("Ingrese ID de la Comisión: ");
                   cur.IDComision = int.Parse(Console.ReadLine());
                   Console.Write("Ingrese Descripción: ");
                   cur.Descripcion = Console.ReadLine();
                   Console.Write("Ingrese Cupo: ");
                   cur.Cupo = int.Parse(Console.ReadLine());
                   Console.Write("Ingrese Año Calendario: ");
                   cur.AnioCalendario = int.Parse(Console.ReadLine());
                   cur.State = BusinessEntity.States.Modified;
                   CursoNegocio.Save(cur);
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
           Curso cur = new Curso();

           new Materias().ListadoGeneral();
           Console.Write("Ingrese ID de Materia");
           cur.IDMateria = int.Parse(Console.ReadLine());
           new Comisiones().Menu();
           Console.Write("Ingrese ID de la Comisión: ");
           cur.IDComision = int.Parse(Console.ReadLine());
           Console.Write("Ingrese Descripción: ");
           cur.Descripcion = Console.ReadLine();
           Console.Write("Ingrese Cupo: ");
           cur.Cupo = int.Parse(Console.ReadLine());
           Console.Write("Ingrese Año Calendario: ");
           cur.AnioCalendario = int.Parse(Console.ReadLine());
           CursoNegocio.Save(cur);
           Console.WriteLine();
           Console.WriteLine("ID Curso: {0}", cur.ID);
           Console.ReadKey();
       }

       public void Eliminar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID del Curso a eliminar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(CursoNegocio.GetOne(ID));
               CursoNegocio.Delete(ID);
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
