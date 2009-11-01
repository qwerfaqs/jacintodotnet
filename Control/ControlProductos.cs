using System;
using System.Collections;//.Generic;
using System.Text;
using BO;
using System.Drawing;
using System.Data.SqlClient;

namespace Control
{
    public class ControlProductos
    {
        public ControlProductos()
        {
            this.miDao = DAO.Productodao.Instancia();
            this.CatDao = DAO.CategoriaDAO.Instancia();
            this.CatDaoSQL = DAOSQL.DAOSQLCategorias.Instancia();
            this.ProductoDaoSQL = DAOSQL.ProductoDAOSQL.Instancia();
        }
        private DAO.Productodao miDao;
        private DAO.CategoriaDAO CatDao;
        private DAOSQL.DAOSQLCategorias CatDaoSQL;
        private DAOSQL.ProductoDAOSQL ProductoDaoSQL;
        Control.ControlCategorias ControlCategorias = new ControlCategorias();

        public bool AgregarProducto(Categoria categoria, string codigo,Image Foto, string nombre, string precio, string preciooferta, string stockactual, string stockcomprometido)
        {
            bool Exito = false;
            
            //try
            //{
                float Precio = Convert.ToInt64(precio);
                int Codigo = Convert.ToInt32(codigo);
                Categoria Categoria = categoria;
                int StockActual = Convert.ToInt32(stockactual);
                int StockComprometido = Convert.ToInt32(stockcomprometido);
                float PrecioOferta = Convert.ToInt64(preciooferta);
                Producto Producto = new Producto(Codigo, nombre, Precio, Categoria, PrecioOferta, Foto, StockActual, StockComprometido);
                this.miDao.agregar_producto(Producto);
                this.ProductoDaoSQL.Agregar_producto(Producto);
                Exito = true;                
            //}
            //catch
            //{
            //    throw new ArgumentException("Error Cargando Producto");
            //}
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
                float Precio = Convert.ToInt64(precio);
                int Codigo = Convert.ToInt32(codigo);
                Categoria Categoria = categoria;
                int StockActual = Convert.ToInt32(stockactual);
                int StockComprometido = Convert.ToInt32(stockcomprometido);
                float PrecioOferta = Convert.ToInt64(preciooferta);

                Producto Producto = new Producto(Codigo, nombre, Precio, Categoria, PrecioOferta, Foto, StockActual, StockComprometido);
                this.miDao.modificar_producto(Producto);
                Exito = true;
            }
            catch
            {
                throw new ArgumentException("Error Cargando Producto");
            }
            return Exito;
        }

        public ArrayList CargarProductos(int Categoria)
        {   
            ArrayList Lista;
            if (Categoria > 0)
            {
                Lista = miDao.leer_productos(Categoria);
            }
            else
                Lista = miDao.leer_productos();
                
            return Lista;
        }
        //public ArrayList CargarProductos(int indice)
        //{
        //    ArrayList Lista;
        //    try
        //    {
        //        if ((indice == -1) || (indice+1 > ControlCategorias.CargarCategorias().Count))
        //        {
        //            Lista = this.miDao.leer_productos();
        //        }
        //        else
        //        {
        //            Lista = this.miDao.leer_productos(Convert.ToInt32(ControlCategorias.IdCategoria(indice)));
        //        }
        //        return Lista;
        //    }
        //    catch 
        //    {
        //        throw new Exception("Error Cargando Productos");
        //    }
        //}
        public BO.Producto DameProducto(int IdProducto)
        {
            return this.miDao.leer_unproducto(IdProducto);

        }
        
        public void BorrarProducto(int id)
        {
            try
            {
                Producto p = this.miDao.leer_unproducto(id);
                this.miDao.EliminarProducto(p);
            }
            catch
            {
                
                throw new Exception("Error Borrando Producto. Producto no se ha boorado");
            }
        }
    }
}
