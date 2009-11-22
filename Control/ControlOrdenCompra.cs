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
        //OrdenCompraDAO miDAO = OrdenCompraDAO.Instancia();
        //DAO con SQL
        OrdenCompraDAOSQL miDAO = OrdenCompraDAOSQL.Instancia();
        
        private OrdenCompra _orden;

        public int GenerarOrden(Carrito carrito,User usuario)
        {
            //throw new Exception("The method or operation is not implemented.");
            _orden = new OrdenCompra(carrito,usuario);
            return miDAO.grabarCompra(_orden);
        }
        
        //public OrdenCompra GenerarOrden2(Carrito carrito, User usuario)////Borrar Luego - Solo sirve para hacer una carga inicial de una orden con estado CONFIRMADO 
        //{
        //    //throw new Exception("The method or operation is not implemented.");
        //    _orden = new OrdenCompra(carrito, usuario);
        //    return miDAO.grabarCompra2(_orden);
        //}
        
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
            Control.ControlProductos CP = new ControlProductos();
            CP.ModificarStocksdeProductosdeUnaOrden(OC);
        }
        public Double TotalUnaOrden(OrdenCompra OC)
        {
            Double Total=0;
            foreach (Item I in OC.Items)
            {
                Total = Total + (I.Cantidad * I.PrecioUnitario);
            }
            return Total;
        }
                
    }
}
