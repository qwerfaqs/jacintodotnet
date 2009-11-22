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
        private DAOSQL.ProductoDAOSQL DAOproducto = DAOSQL.ProductoDAOSQL.Instancia();
        
        public ControlCarritos()
        {
        }
        public void AgregarItem(int idProducto, int cant)
        {
            this.unCarrito.agregar_item(this.DAOproducto.leer_unproducto(idProducto), cant);
        }
        public ArrayList CargarCarrito()
        {
            return this.unCarrito.ver_lista();
        }
        public void EliminarItem(int Codigo)
        {
            this.unCarrito.eliminar_item(this.DAOproducto.leer_unproducto(Codigo));
        }
        public void ModificarItem(int Codigo,int cant)
        {            
            this.unCarrito.modificar_item(this.DAOproducto.leer_unproducto(Codigo), cant);           
        }
        public void VaciarCarrito()
        {
            this.unCarrito.VaciarCarrito();
        }


        public string DameTotal()
        {
            return this.unCarrito.Subtotal.ToString();
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
