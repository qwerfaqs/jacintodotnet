using System;
using System.Collections.Generic;
using System.Text;

namespace DAOSQL
{
    class DAOSQLProductos
    {
        private static ArrayList ListaProductos;
        private static readonly DAOSQLProductos _instancia = new DAOSQLProductos();
        public static DAOSQLProductos Instancia()
        {
            return _instancia;
        }

        
    }
}
