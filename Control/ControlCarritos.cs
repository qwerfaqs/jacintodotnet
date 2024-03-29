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
        //DAOS CON ARRAYLIST
        //private DAO.Productodao DAOproducto = DAO.Productodao.Instancia();
        
      
        //DAOS CON SQL
        //private DAOSQL.ProductoDAOSQL DAOproducto = DAOSQL.ProductoDAOSQL.Instancia();

        private ControlProductos ctrl_prod = new ControlProductos();

        public ControlCarritos()
        {
        }
        public void AgregarItem(int idProducto, int cant)
        {
            this.unCarrito.agregar_item(this.ctrl_prod.DameProducto(idProducto), cant);
        }
        public ArrayList CargarCarrito()
        {
            return this.unCarrito.ver_lista();
            
        }
        public void EliminarItem(int Codigo)
        {
            this.unCarrito.eliminar_item(this.ctrl_prod.DameProducto(Codigo));
        }
        public void ModificarItem(int Codigo,int cant)
        {
            this.unCarrito.modificar_item(this.ctrl_prod.DameProducto(Codigo), cant);           
        }
        public void VaciarCarrito()
        {
            this.unCarrito.VaciarCarrito();
        }
        
        public string DameTotal()
        {
            //return this.unCarrito.Subtotal.ToString();
            return String.Format("{0:#,##0.00;($#,##0.00);0.00}", this.unCarrito.Subtotal);
        }

        public int GenerarOrden(Session session)
        {
            //throw new Exception("The method or operation is not implemented.");
            ControlOrdenCompra crtlOrden = new ControlOrdenCompra();
            return crtlOrden.GenerarOrden(this.unCarrito,session.dameUser());            
        }
        //public OrdenCompra GenerarOrden2(Session session)//Borrar Luego - Solo sirve para hacer una carga inicial de una orden con estado CONFIRMADO 
        //{
        //    //throw new Exception("The method or operation is not implemented.");
        //    ControlOrdenCompra crtlOrden = new ControlOrdenCompra();
        //    return crtlOrden.GenerarOrden2(this.unCarrito, session.dameUser());

        //}

       
    }
    
}
