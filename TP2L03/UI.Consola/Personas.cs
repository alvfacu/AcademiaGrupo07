using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Negocio; 

namespace UI.Consola
{
    public class Personas 
    {
       private Negocio.PersonaLogic _PersonaNegocio;

       public Negocio.PersonaLogic PersonaNegocio
       {
           get { return _PersonaNegocio; }
           set { _PersonaNegocio = value; } 
       }

       public Personas()
       {
           PersonaNegocio = new Negocio.PersonaLogic();
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
           foreach (Business.Entities.Personas per in PersonaNegocio.GetAll())
           {
               MostrarDatos(per);
           }
           Console.ReadKey();
       }

       public void MostrarDatos(Business.Entities.Personas per)
       {
          Console.WriteLine("ID Persona: {0}",per.ID );
          Console.WriteLine("\t\tNombre: {0}", per.Nombre);
          Console.WriteLine("\t\tApellido: {0}", per.Apellido);
          Console.WriteLine("\t\tLegajo: {0}", per.Legajo);
          Console.WriteLine("\t\tID Plan: {0}", per.IDPlan);
          Console.WriteLine("\t\tDirección: {0}", per.Direccion);
          Console.WriteLine("\t\tEmail: {0}", per.Email);
          Console.WriteLine("\t\tTelefono: {0}", per.Telefono);
          Console.WriteLine("\t\tFecha de Nacimiento: {0}/{1}/{2}", per.FechaNacimiento.Day,per.FechaNacimiento.Month,per.FechaNacimiento.Year);
          Console.WriteLine("\t\tTipo de Persona: {0}", per.TipoPersona);
          Console.WriteLine();
       }

       public void Consultar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID de la Persona a consultar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(PersonaNegocio.GetOne(ID));
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
               Console.Write("Ingrese el ID de la Persona a modificar: ");
               int ID = int.Parse(Console.ReadLine());
               Business.Entities.Personas per = PersonaNegocio.GetOne(ID);
               if (per == null)
               {
                   Console.WriteLine("No existe Persona con ID ingresado.");
               }
               else
               {
                   new Planes().ListadoGeneral();
                   Console.Write("Ingrese ID Plan: ");
                   per.IDPlan = int.Parse(Console.ReadLine());
                   Console.Write("Ingrese Nombre: ");
                   per.Nombre = Console.ReadLine();
                   Console.Write("Ingrese Apellido: ");
                   per.Apellido = Console.ReadLine();
                   Console.Write("Ingrese Legajo: ");
                   per.Legajo = int.Parse(Console.ReadLine());
                   Console.Write("Ingrese Dirección: ");
                   per.Direccion = Console.ReadLine();
                   Console.Write("Ingrese Email: ");
                   per.Email = Console.ReadLine();
                   Console.Write("Ingrese Telefono: ");
                   per.Telefono = Console.ReadLine();
                   Console.Write("Ingrese Fecha de Nacimiento: (AÑO,MES,DIA) ");
                   string fechaNac = Console.ReadLine();
                   per.FechaNacimiento = DateTime.Parse(fechaNac);
                   this.DefinirTipoPersona(per);
                   per.State = BusinessEntity.States.Modified;
                   PersonaNegocio.Save(per);
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
           Business.Entities.Personas per = new Business.Entities.Personas();
           new Planes().ListadoGeneral();
           Console.Write("Ingrese ID Plan: ");
           per.IDPlan = int.Parse(Console.ReadLine());
           Console.Write("Ingrese Nombre: ");
           per.Nombre = Console.ReadLine();
           Console.Write("Ingrese Apellido: ");
           per.Apellido = Console.ReadLine();
           Console.Write("Ingrese Legajo: ");
           per.Legajo = int.Parse(Console.ReadLine());
           Console.Write("Ingrese Dirección: ");
           per.Direccion = Console.ReadLine();
           Console.Write("Ingrese Email: ");
           per.Email = Console.ReadLine();
           Console.Write("Ingrese Telefono: ");
           per.Telefono = Console.ReadLine();
           Console.Write("Ingrese Fecha de Nacimiento: (AÑO,MES,DIA) ");
           string fechaNac = Console.ReadLine();
           per.FechaNacimiento = DateTime.Parse(fechaNac);
           this.DefinirTipoPersona(per);
           PersonaNegocio.Save(per);
           Console.WriteLine();
           Console.WriteLine("ID Persona: {0}", per.ID);
           Console.ReadKey();
       }

       public void Eliminar()
       {
           try
           {
               Console.Clear();
               Console.Write("Ingrese el ID de la Persona a eliminar: ");
               int ID = int.Parse(Console.ReadLine());
               this.MostrarDatos(PersonaNegocio.GetOne(ID));
               PersonaNegocio.Delete(ID);
           }
           catch (FormatException fe)
           {
               Console.WriteLine();
               Console.WriteLine("La ID ingresada deber un número entero.");
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

       public void DefinirTipoPersona(Business.Entities.Personas per)
       {
           Business.Entities.Personas.MostrarTiposPersonas();
           Console.Write("Ingrese Tipo de Persona: ");
           switch (Console.ReadLine())
           {
               case "A": per.TipoPersona = Business.Entities.Personas.TiposPersonas.A; break;
               case "B": per.TipoPersona = Business.Entities.Personas.TiposPersonas.B; break;
               case "C": per.TipoPersona = Business.Entities.Personas.TiposPersonas.C; break;
               case "D": per.TipoPersona = Business.Entities.Personas.TiposPersonas.D; break;
           }
       }
    }
}
