using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class DocenteCurso: BusinessEntity
    {
        public enum TiposCargos
        {
            A = 0,
            B = 1,
            C = 2,
            D = 3
        }
        
        private TiposCargos _Cargo;
        private int _IDCurso;
        private int _IDDocente;

        public static void MostrarTiposCargos()
        {
            Console.WriteLine("Tipos de Cargos:");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(" {0}",(((TiposCargos)i).ToString()));
            }
        }

        public TiposCargos Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }
        
        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }

        public int IDDocente
        {
            get { return _IDDocente; }
            set { _IDDocente = value; }
        }

        public static List<String> DevolverTiposCargos()
        {
            int tam = Enum.GetNames(typeof(TiposCargos)).Length;
            
            List<String> array = new List<String>();

            for (int i = 0; i < tam; i++)
            {
                array.Add(((TiposCargos)i).ToString());
            }
            return array;
        }
    }
}
