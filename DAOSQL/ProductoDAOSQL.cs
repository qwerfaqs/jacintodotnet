using System;
using System.Collections;//.Generic;
using System.Text;
using BO;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;
namespace DAOSQL
{
    public sealed class ProductoDAOSQL
    {
        private static ArrayList ListaProductos;
        private static readonly ProductoDAOSQL _instancia = new ProductoDAOSQL();
        public static ProductoDAOSQL Instancia()
        {
            return _instancia;
        }
       
        public void Agregar_producto(Producto product)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=EMMANUEL2; Initial Catalog=Carrito; Integrated Security=True"))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "INSERT INTO Productos (Id,Nombre,Categoria,Precio,PrecioOferta,Foto,Stock,StockComprometido) values (" + product.Codigo + ",'" + product.Nombre + "'," + product.Cat.Codigo + "," + product.Precio + "," + product.PrecioOferta + ",@img," + product.StockActual + "," + product.StockComprometido + ")";
                        command.Parameters.Add("@img", SqlDbType.Image);
                        command.Connection = conn;
                        if (product.FotoPath != null)
                        {
                            MemoryStream ms = new MemoryStream();
                            product.FotoPath.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            command.Parameters["@img"].Value = ms.GetBuffer();
                        }

                        command.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch
            {
                throw new ArgumentException("Error Agregando Producto");
            }
        }

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
