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
        //DAO con SQL
        
        private OrdenCompra _orden;
        
        internal void GenerarOrden(Carrito carrito,User usuario)
        {
            //throw new Exception("The method or operation is not implemented.");
            _orden = new OrdenCompra(carrito,usuario);

        }
    }
}
