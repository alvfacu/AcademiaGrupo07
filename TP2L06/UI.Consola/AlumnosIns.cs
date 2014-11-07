using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Negocio;


namespace UI.Consola
{
    public class AlumnosIns
    {
        private Negocio.AlumnoInsLogic _AlumnoNegocio;

       public Negocio.AlumnoInsLogic AlumnoNegocio
       {
           get { return _AlumnoNegocio; }
           set { _AlumnoNegocio = value; } 
       }

       public AlumnosIns()
       {
           AlumnoNegocio = new Negocio.AlumnoInsLogic();
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
           foreach (AlumnoInscripcion alu in AlumnoNegocio.GetAll())
           {
               MostrarDatos(alu);
           }
           Console.ReadKey();
       }

       public void MostrarDatos(AlumnoInscripcion alu)
       {
          Console.WriteLine("ID Inscripcion: {0}", alu.ID);
          Console.WriteLine("\t\tID Alumno: {0}", alu.IDAlumno);
          Console.WriteLine("\t\tID Curso: {0}", alu.IDCurso);
          Console.WriteLine("\t\tNota: {0}", alu.Nota);
          Console.WriteLine();
       }

       public void Consultar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID de la Inscripción a consultar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(AlumnoNegocio.GetOne(ID));
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
               Console.Write("Ingrese el ID de la Inscripcion a modificar: ");
               int ID = int.Parse(Console.ReadLine());
               AlumnoInscripcion alu = AlumnoNegocio.GetOne(ID);
               if (alu == null)
               {
                   Console.WriteLine("No existe Inscripcion.");
               }
               else
               {
                   new Cursos().ListadoGeneral();
                   Console.Write("Ingrese ID del Curso: ");
                   alu.IDCurso = int.Parse(Console.ReadLine());
                   Console.Write("Ingrese ID del Alumno: ");
                   alu.IDAlumno = int.Parse(Console.ReadLine());
                   Console.Write("Ingrese Nota: ");
                   alu.Nota = int.Parse(Console.ReadLine());
                   alu.State = BusinessEntity.States.Modified;
                   AlumnoNegocio.Save(alu);
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
           AlumnoInscripcion alu = new AlumnoInscripcion();

           new Cursos().ListadoGeneral();
           Console.Write("Ingrese ID del Curso: ");
           alu.IDCurso = int.Parse(Console.ReadLine());
           Console.Write("Ingrese el ID del Alumno a inscribir: ");
           alu.IDAlumno = int.Parse(Console.ReadLine());
           Console.Write("Ingrese Nota: ");
           alu.Nota = int.Parse(Console.ReadLine());
           AlumnoNegocio.Save(alu);
           Console.WriteLine();
           Console.WriteLine("ID inscripción: {0}", alu.ID);
           Console.ReadKey();
       }

       public void Eliminar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID de la Inscripción a eliminar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(AlumnoNegocio.GetOne(ID));
               AlumnoNegocio.Delete(ID);
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
