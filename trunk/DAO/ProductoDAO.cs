using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using BO;
using System.Drawing;

namespace DAO
{
    public sealed class Productodao
    {
        private static readonly Productodao _instancia = new Productodao();
        public static Productodao Instancia()
        {
            return _instancia;
        }
        private ArrayList ListaProductos = new ArrayList();
        

        public void Agregar_producto(Producto product)
        {
            ListaProductos.Add(product);
        }
        
        public void modificar_producto(Producto product)
        {
            foreach (Producto p in ListaProductos)
            {
                if (p.Codigo == product.Codigo)
                {
                    p.Nombre = product.Nombre;
                    p.Cat = product.Cat;
                    p.FotoPath = product.FotoPath;
                    p.Precio = product.Precio;
                    p.PrecioOferta = product.PrecioOferta;
                    p.StockActual = product.StockActual;
                    p.StockComprometido = product.StockComprometido;
                    break;
                }
            }
        }

        public void EliminarProducto(Producto UnProducto)
        {
            ListaProductos.Remove(UnProducto);
        }

        public ArrayList leer_productos()
        {
            return ListaProductos;
        }

        public ArrayList leer_productos(int categoria)
        {
            ArrayList Lista = null;
            if(categoria == -1)
            {
                return this.ListaProductos;
            }else
            {
                Lista = new ArrayList();

                foreach (Producto UnProducto in this.ListaProductos)
                {
                    if(UnProducto.Cat.Codigo == categoria)
                        Lista.Add(UnProducto);
                }
                
            }
                return Lista;
        }

        public Producto leer_unproducto(int codigoproducto)
        {
            Producto p=new Producto();
            foreach (Producto UnProducto in ListaProductos)
            {
                if (UnProducto.Codigo == codigoproducto)
                {
                    p = UnProducto;
                }
            }
            return p;
        }

        //---------------------------------------------------------------------------

        public bool ModificarProducto(Producto UnProducto)
        {
            int Encontrado = 0;
            int x = 0;
            while ((x < ListaProductos.Count) && (Encontrado == 0))
            {
                Producto Product = (Producto)ListaProductos[x];
                if (Product.Codigo == UnProducto.Codigo)
                {
                    Product = UnProducto;
                    Encontrado = 1;
                }
                x++;
            }
            if (Encontrado == 1)
            {
                return true;
            }
            else { return false; }



        }
        
        public int StockComprometido(Producto UnProducto) //devuelve el stock de un producto
        {
            int Cantidad = -1;//devuelve -1 si no lo encuentra
            int Encontrado = 0;
            int x = 0;
            while ((x < ListaProductos.Count) && (Encontrado == 0))
            {
                Producto Product = (Producto)ListaProductos[x];
                if (Product.Codigo == UnProducto.Codigo)
                {
                    Cantidad = Product.StockComprometido;
                    Encontrado = 1;
                }
                x++;
            }
            return (Cantidad);
        }
        
        public void ModificarStock(Producto UnProducto, int cant)// modifica stock de un producto
        {
            int Encontrado = 0;
            int x = 0;
            while ((x < ListaProductos.Count) && (Encontrado == 0))
            {
                Producto Product = (Producto)ListaProductos[x];
                if (Product.Codigo == UnProducto.Codigo)
                {
                    Product.StockActual = cant;
                    Encontrado = 1;
                }
                x++;
            }

        }
        
        public void ModificarStockComprometido(Producto UnProducto, int cant)// modifica stock de un producto
        {
            int Encontrado = 0;
            int x = 0;
            while ((x < ListaProductos.Count) && (Encontrado == 0))
            {
                Producto Product = (Producto)ListaProductos[x];
                if (Product.Codigo == UnProducto.Codigo)
                {
                    Product.StockComprometido= cant;
                    Encontrado = 1;
                }
                x++;
            }

        }

        public int StockActual(Producto UnProducto) //devuelve el stock de un producto
        {
            int Cantidad = -1;//devuelve -1 si no lo encuentra
            int Encontrado = 0;
            int x = 0;
            while ((x < ListaProductos.Count) && (Encontrado == 0))
            {
                Producto Product = (Producto)ListaProductos[x];
                if (Product.Codigo == UnProducto.Codigo)
                {
                    Cantidad = Product.StockActual;
                    Encontrado = 1;
                }
                x++;
            }
            return (Cantidad);
        }
    }
}
