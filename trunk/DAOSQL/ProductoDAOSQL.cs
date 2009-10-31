using System;
using System.Collections;//.Generic;
using System.Text;
using BO;
namespace DAOSQL
{
    class ProductoDAOSQL
    {
        private static ArrayList ListaProductos;
        private static readonly ProductoDAOSQL _instancia = new ProductoDAOSQL();
        public static ProductoDAOSQL Instancia()
        {
            return _instancia;
        }

        public void agregar_producto(Producto product)
        {
            ListaProductos.Add(product);
        }

        //public void modificar_producto(Producto product)
        //{
        //    foreach (Producto p in ListaProductos)
        //    {
        //        if (p.Codigo == product.Codigo)
        //        {
        //            p.Nombre = product.Nombre;
        //            p.Cat = product.Cat;
        //            p.FotoPath = product.FotoPath;
        //            p.Precio = product.Precio;
        //            p.PrecioOferta = product.PrecioOferta;
        //            p.StockActual = product.StockActual;
        //            p.StockComprometido = product.StockComprometido;
        //            break;
        //        }
        //    }
        //}

        //public void EliminarProducto(Producto UnProducto)
        //{
        //    ListaProductos.Remove(UnProducto);
        //}

        //public ArrayList leer_productos()
        //{
        //    return ListaProductos;
        //}

        //public ArrayList leer_productos(int categoria)
        //{
        //    ArrayList Lista = new ArrayList();
        //    foreach (Producto UnProducto in ListaProductos)
        //    {
        //        if (UnProducto.Cat.Codigo == categoria)
        //            Lista.Add(UnProducto);
        //    }
        //    return Lista;
        //}

        //public Producto leer_unproducto(int codigoproducto)
        //{
        //    Producto p = new Producto();
        //    foreach (Producto UnProducto in ListaProductos)
        //    {
        //        if (UnProducto.Codigo == codigoproducto)
        //        {
        //            p = UnProducto;
        //        }
        //    }
        //    return p;
        //}
    }
}
