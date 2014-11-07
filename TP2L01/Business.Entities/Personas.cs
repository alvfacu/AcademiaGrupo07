using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Personas: BusinessEntity
    {
        public enum TiposPersonas
        {
            Administrador,
            Docente,
            Alumno,
        }

        private string _Apellido;
        private string _Nombre;
        private string _Email;
        private DateTime _FechaNacimiento;
        private int _IDPlan;
        private int _Legajo;
        private string _Direccion;
        private string _Telefono;
        private TiposPersonas _TipoPersona;

        public static void MostrarTiposPersonas()
        {
            Console.WriteLine("Tipos de Personas:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(" {0}",(((TiposPersonas)i).ToString()));
            }
        }

        public static List<String> DevolverTiposPersonas()
        {
            List<String> array = new List<String>();
            for (int i = 0; i < 3; i++)
            {
                array.Add(((TiposPersonas)i).ToString());
            }
            return array;
        }


        public Personas()
        {
            TipoPersona = TiposPersonas.Administrador;
        }

        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set { _FechaNacimiento = value; }
        }

        public int IDPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }

        public int Legajo
        {
            get { return _Legajo; }
            set { _Legajo = value; }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        public TiposPersonas TipoPersona
        {
            get { return _TipoPersona; }
            set { _TipoPersona = value; }
        }



    }
}
