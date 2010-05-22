using System;
using System.Collections;//.Generic;
using System.Text;
using BO;
using System.Drawing;
using System.Data.SqlClient;
using System.Globalization;

namespace Control
{
    public class ControlProductos
    {
        //obtengo la cultura inglesa sin paisn ni region, cultura que no varia en ninguna makina ni sistema
        private CultureInfo cultura = CultureInfo.InvariantCulture;

        private Control.ControlCategorias ControlCategorias = new ControlCategorias();
        //DAO con ArrayList
        //private DAO.Productodao DaoProducto = DAO.Productodao.Instancia();
        //DAO con SQL
        private DAOSQL.ProductoDAOSQL DaoProducto = DAOSQL.ProductoDAOSQL.Instancia();
        
        public ControlProductos()
        {
            
        }

        public bool ImagenTieneTamañoCorrecto(Image Imagen)
        {
            bool Respuesta = false;
            if (Imagen.Height <= 160 && Imagen.Width <= 160)
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public bool AgregarProducto(Categoria categoria, string codigo,Image Foto, string nombre, string precio, string preciooferta, string stockactual, string stockcomprometido)
        {
            bool Exito = false;

            try
            {
                
                double Precio = double.Parse(precio,this.cultura);
                int Codigo = Convert.ToInt32(codigo);
                Categoria Categoria = categoria;
                int StockActual = Convert.ToInt32(stockactual);
                int StockComprometido = Convert.ToInt32(stockcomprometido);
                double PrecioOferta = double.Parse(preciooferta,this.cultura);
                Producto Producto = new Producto(Codigo, nombre, Precio, Categoria, PrecioOferta, Foto, StockActual, StockComprometido);
                //this.miDao.agregar_producto(Producto);
                this.DaoProducto.Agregar_producto(Producto);
                Exito = true;                
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error Agregando Producto",ex);
            }
            return Exito;
        }
        
        public bool ExistenProductosConEstaCategoria(int categoria)
        {
            Control.ControlProductos CP = new ControlProductos();
            bool r = false;
            foreach (Producto c in CP.CargarProductos(-1))
            {
                if (c.Cat.Codigo == categoria)
                {
                    r = true;
                    break;
                }
            }
            return r;
        }
        
        public bool ModificarProducto(Categoria categoria, string codigo, Image Foto, string nombre, string precio, string preciooferta, string stockactual, string stockcomprometido)
        {
            bool Exito = false;

            try
            {
                double Precio = double.Parse(precio,this.cultura);
                int Codigo = Convert.ToInt32(codigo);
                Categoria Categoria = categoria;
                int StockActual = Convert.ToInt32(stockactual);
                int StockComprometido = Convert.ToInt32(stockcomprometido);
                double PrecioOferta = double.Parse(preciooferta,this.cultura);

                Producto Producto1 = new Producto(Codigo, nombre, Precio, Categoria, PrecioOferta, Foto, StockActual, StockComprometido);
                //this.miDao.modificar_producto(Producto);
                this.DaoProducto.modificar_producto(Producto1);
                Exito = true;
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Error Modificando Producto",ex);
            }
            return Exito;
        }

        public ArrayList CargarProductos(int Categoria)
        {   
            ArrayList Lista;
            if (Categoria > 0)
            {
                Lista = DaoProducto.leer_productos(Categoria);
                //Lista = miDao.leer_productos(Categoria);
            }
            else
                //Lista = miDao.leer_productos();
                Lista = DaoProducto.leer_productos(-1);
                
            return Lista;
        }

        public BO.Producto DameProducto(int IdProducto)
        {
            //return this.miDao.leer_unproducto(IdProducto);
            return this.DaoProducto.leer_unproducto(IdProducto);

        }
        
        public void BorrarProducto(int id)
        {
            try
            {
                //Producto p = this.miDao.leer_unproducto(id);
                //this.miDao.EliminarProducto(p);
                Producto p = this.DaoProducto.leer_unproducto(id);
                this.DaoProducto.EliminarProducto(p);
            }
            catch(Exception ex)
            {

                throw new Exception("Error Borrando Producto. Producto no se ha boorado",ex);
            }
        }

        public void ModificarUnStock(Producto Prod, int Cant)
        {
            this.ModificarProducto(Prod.Cat, Prod.Codigo.ToString(), Prod.FotoPath, Prod.Nombre.ToString(), Prod.Precio.ToString(), Prod.PrecioOferta.ToString(), Convert.ToString((Prod.StockActual - Cant)), Prod.StockComprometido.ToString());
        }
        
        public void ModificarStocksdeProductosdeUnaOrden(OrdenCompra UnaOrden)
        {
            foreach (Item Item in UnaOrden.Items)
            {
                ModificarUnStock(Item._UnProducto, Item.Cantidad);
            }
        }

    }
}
