using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringLocal";
        
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");

        private SqlConnection _sqlConn;

        public SqlConnection sqlConn
        {
            get { return _sqlConn; }
            set { _sqlConn = value; }
        }

        protected void OpenConnection()
        {
            //throw new Exception("Metodo no implementado");
            string conn = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;

            sqlConn = new SqlConnection(conn);

            sqlConn.Open();

        }

        protected void CloseConnection()
        {
            //throw new Exception("Metodo no implementado");

            sqlConn.Close();

            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
