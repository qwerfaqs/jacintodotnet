using System;
using System.Collections.Generic;
using System.Text;

namespace DAOSQL
{
    public sealed class OrdenCompraDAOSQL
    {
        private static readonly OrdenCompraDAOSQL _instancia = new OrdenCompraDAOSQL();
        private OrdenCompraDAOSQL()
        {
        }
        public static OrdenCompraDAOSQL Instancia()
        {
            return _instancia;
        }

    }
}
