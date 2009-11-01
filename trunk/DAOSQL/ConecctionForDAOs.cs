using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DAOSQL
{
    public sealed class ConecctionServer
    {
        private static readonly ConecctionServer _instancia = new ConecctionServer();
        public static ConecctionServer Instancia()
        {
            return _instancia;
        }
        private SqlConnection _conn;
        private string _connectioString;
        public void Conexion()
        {
            //tengo que debolver el objeto coneccion
        }
        }
}
