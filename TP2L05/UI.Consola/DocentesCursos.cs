using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Negocio;

namespace UI.Consola
{
    public class DocentesCursos
    {
       private Negocio.DocenteLogic _DocenteNegocio;

       public Negocio.DocenteLogic DocenteNegocio
       {
           get { return _DocenteNegocio; }
           set { _DocenteNegocio = value; } 
       }

       public DocentesCursos()
       {
           DocenteNegocio = new Negocio.DocenteLogic();
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
           foreach (DocenteCurso doc in DocenteNegocio.GetAll())
           {
               MostrarDatos(doc);
           }
           Console.ReadKey();
       }

       public void MostrarDatos(DocenteCurso doc)
       {
          Console.WriteLine("ID Docente-Curso: {0}",doc.ID );
          Console.WriteLine("\t\tCargo: {0}", doc.Cargo);
          Console.WriteLine("\t\tID Docente: {0}", doc.IDDocente);
          Console.WriteLine("\t\tID Curso: {0}", doc.IDCurso);
          Console.WriteLine();
       }

       public void Consultar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID del Docente-Curso a consultar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(DocenteNegocio.GetOne(ID));
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
               Console.Write("Ingrese el ID del Docente-Curso a modificar: ");
               int ID = int.Parse(Console.ReadLine());
               DocenteCurso doc = DocenteNegocio.GetOne(ID);
               if (doc == null)
               {
                   Console.WriteLine("No existe Docente con ese ID.");
               }
               else
               {
                   new Cursos().ListadoGeneral();
                   Console.Write("Ingrese ID Curso: ");
                   doc.IDCurso = int.Parse(Console.ReadLine()); 
                   Console.Write("Ingrese ID Docente: ");
                   doc.IDDocente = int.Parse(Console.ReadLine());
                   this.DefinirCargo(doc);
                   doc.State = BusinessEntity.States.Modified;
                   DocenteNegocio.Save(doc);
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
           DocenteCurso doc = new DocenteCurso();

           new Cursos().ListadoGeneral();
           Console.Write("Ingrese ID Curso: ");
           doc.IDCurso = int.Parse(Console.ReadLine());
           Console.Write("Ingrese ID del Docente: ");
           doc.IDDocente = int.Parse(Console.ReadLine());
           this.DefinirCargo(doc);
           DocenteNegocio.Save(doc);
           Console.WriteLine();
           Console.WriteLine("ID Docente-Curso: {0}", doc.ID);
           Console.ReadKey();
       }

       public void Eliminar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID del Docente-Curso a eliminar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(DocenteNegocio.GetOne(ID));
               DocenteNegocio.Delete(ID);
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

       public void DefinirCargo(DocenteCurso doc)
       {
           DocenteCurso.MostrarTiposCargos();
           Console.Write("Ingrese Cargo: ");
           switch (Console.ReadLine())
           {
               case "A": doc.Cargo = DocenteCurso.TiposCargos.A; break;
               case "B": doc.Cargo = DocenteCurso.TiposCargos.B; break;
               case "C": doc.Cargo = DocenteCurso.TiposCargos.C; break;
               case "D": doc.Cargo = DocenteCurso.TiposCargos.D; break;
           }
           
       }
    }
}
