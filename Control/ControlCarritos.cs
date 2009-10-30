using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using BO;
using DAO;
using System.Data.SqlClient;



namespace Control
{
    public class ControlCarritos
    {
        private Carrito unCarrito = new Carrito(DateTime.Now);
        private DAO.Productodao DAOProductos = DAO.Productodao.Instancia();
        private DAO.OrdenCompraDAO DAOOrdenCompra = DAO.OrdenCompraDAO.Instancia();
        public ControlCarritos()
        {
        }
        public void AgregarItem(int idProducto, int cant)
        {
            this.unCarrito.agregar_item(this.DAOProductos.leer_unproducto(idProducto), cant);
        }
        public ArrayList CargarCarrito()
        {
            
            return this.unCarrito.ver_lista();

        }
        
        
    }
    
}
