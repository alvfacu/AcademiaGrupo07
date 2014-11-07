using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Usuario: BusinessEntity
    {
        public string _NombreUsuario;
        public string _Clave;
        public string _Nombre;
        public string _Apellido;
        public string _Email;
        public bool _Habilitado;
        private Personas _per;

        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }

        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        public string EMail
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }

        public Personas Per
        {
            get { return _per; }
            set { _per = value; }
        }
    }
}
