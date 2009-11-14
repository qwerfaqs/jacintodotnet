using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using BO;
using DAOSQL;
using DAO;

namespace Control
{
    public class ControlOrdenCompra
    {
        //DAO con ArrayList
        OrdenCompraDAO miDAO = OrdenCompraDAO.Instancia();
        //DAO con SQL
        
        private OrdenCompra _orden;

        public int GenerarOrden(Carrito carrito,User usuario)
        {
            //throw new Exception("The method or operation is not implemented.");
            _orden = new OrdenCompra(carrito,usuario);
            return miDAO.grabarCompra(_orden);
        }
        public ArrayList LeerOdenesdeCompra()
        {
            return miDAO.LeerOrdenes();
        }
        public ArrayList LeerOdenesdeCompra(string Estado)
        {
            return miDAO.LeerOrdenes(Estado);
        }
        public OrdenCompra LeerUnaOrden(int IdOrden)
        {
            return miDAO.LeerUnaOrden(IdOrden);
        }
        public void ModificarUnaOrden(OrdenCompra OC)
        {
            miDAO.ModificarOrden(OC);
        }
        
    }
}
