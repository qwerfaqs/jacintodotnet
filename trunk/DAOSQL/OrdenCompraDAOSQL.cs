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
        
        public int grabarCompra(BO.OrdenCompra _orden)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public BO.OrdenCompra grabarCompra2(BO.OrdenCompra _orden)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Collections.ArrayList LeerOrdenes()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public BO.OrdenCompra LeerUnaOrden(int IdOrden)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Collections.ArrayList LeerOrdenes(string Estado)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void ModificarOrden(BO.OrdenCompra OC)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
