using System;
using System.Collections.Generic;
using System.Text;
using BO;
using DAO;
using System.Data.SqlClient;


namespace Control
{
    class ControlCarritos
    {
        private Carrito unCarrito;
        private DAO.Productodao DAOProductos = DAO.Productodao.Instancia();
        private DAO.OrdenCompraDAO DAOOrdenCompra = DAO.OrdenCompraDAO.Instancia();
        public ControlCarritos()
        {
            this.unCarrito = new Carrito(DateTime.Now);
        }
        public void AgregarItem(int idProducto, int cant)
        {
            this.unCarrito.agregar_item(this.DAOProductos.leer_unproducto(idProducto), cant);
        }
        
    }
}
