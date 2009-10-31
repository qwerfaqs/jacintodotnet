using System;
using System.Collections;//.Generic;
using System.Text;

namespace DAOSQL
{
    class ProductoDAOSQL
    {
        private static ArrayList ListaProductos;
        private static readonly ProductoDAOSQL _instancia = new ProductoDAOSQL();
        public static ProductoDAOSQL Instancia()
        {
            return _instancia;
        }

        
    }
}
