using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int aux;
                Console.WriteLine("Ingrese sección a la que desea ingresar: ");
                Console.WriteLine("1– ABMC AlumnoInscripción\n2– ABMC Comisiones\n3– ABMC Cursos\n4- ABMC Usuarios\n5- ABMC Docentes-Cursos\n6- ABMC Especialidades\n7- ABMC Materias\n8- ABMC Modulos\n9- ABMC Modulos Usuarios\n10- ABMC Personas\n11- ABMC Planes\n12- Salir\n");
                do
                {
                    aux = int.Parse(Console.ReadLine());
                    switch (aux)
                    {
                        case 1: Console.Clear(); new AlumnosIns().Menu(); break;
                        case 2: Console.Clear();  new Comisiones().Menu(); break;
                        case 3: Console.Clear(); new Cursos().Menu(); break;
                        case 4: Console.Clear(); new Usuarios().Menu(); break;
                        case 5: Console.Clear(); new DocentesCursos().Menu(); break;
                        case 6: Console.Clear(); new Especialidades().Menu(); break;
                        case 7: Console.Clear(); new Materias().Menu(); break;
                        case 8: Console.Clear(); new Modulos().Menu(); break;
                        case 9: Console.Clear(); new ModUsuarios().Menu(); break;
                        case 10: Console.Clear(); new Personas().Menu(); break;
                        case 11: Console.Clear(); new Planes().Menu(); break;
                    }
                    Console.Clear();
                    Console.WriteLine("Ingrese sección a la que desea ingresar: ");
                    Console.WriteLine("1– ABMC AlumnoInscripción\n2– ABMC Comisiones\n3– ABMC Cursos\n4- ABMC Usuarios\n5- ABMC Docentes-Cursos\n6- ABMC Especialidades\n7- ABMC Materias\n8- ABMC Modulos\n9- ABMC Modulos Usuarios\n10- ABMC Personas\n11- ABMC Planes\n12- Salir\n");
                } while (aux < 12);
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
