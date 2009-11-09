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
        private User _cliente;
        private OrdenCompra _orden;
        public ControlOrdenCompra(User client)
        {
            ///TODO: Aca puede ir una validacion para ver si el cliente existe, si la identidad no es falseada
            this._cliente = client;
        }
        internal void GenerarOrden(Carrito carrito)
        {
            //throw new Exception("The method or operation is not implemented.");
            _orden = new OrdenCompra(carrito,this._cliente);
        }
    }
}
