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
        
        public ArrayList leer_productos(int Categoria1)
        {   
            string string1="",string2="";
            if (Categoria1>-1)
            {
                string1="where Id=";
                string2 = Convert.ToString(Categoria1);
            }

            try
            {
                ListaProductos = new ArrayList();
                ListaProductos.Clear();
                using (SqlConnection conn = new SqlConnection("Data Source=EMMANUEL2; Initial Catalog=Carrito; Integrated Security=True " + string1 + string2))
                {
                    Producto producto = null;
                    conn.Open();

                    using (SqlCommand command = new SqlCommand())
                    {//                                0    1        2      3         4        5     6          7
                        command.CommandText = "SELECT Id,Nombre,Categoria,Precio,PrecioOferta,Foto,Stock,StockComprometido FROM Productos";
                        command.Connection = conn;

                        SqlDataReader rdr = command.ExecuteReader();

                        while (rdr.Read())
                        {

                            DAOSQL.DAOSQLCategorias miDAOSQLCat = DAOSQL.DAOSQLCategorias.Instancia();

                            /*
                             byte[] image = (byte[])command.ExecuteScalar();
                             MemoryStream ms1 = new MemoryStream(image);
                             exceptionPictureBox.Image = Bitmap.FromStream (ms1);  //this is how it should be.  I was using Image.FromStream and was getting error.
                             */
                            byte[] image = (byte[])rdr.GetValue(5);
                            MemoryStream ms1 = new MemoryStream(image);
                            Image Foto = Bitmap.FromStream(ms1);
                            int Id = Convert.ToInt32(rdr.GetValue(0));
                            string Nombre = rdr.GetValue(1).ToString();
                            Categoria Cat = miDAOSQLCat.UnObjetoCategoria((int)rdr.GetValue(2));
                            int Precio = Convert.ToInt32(rdr.GetValue(3));
                            int PrecioOferta = Convert.ToInt32(rdr.GetValue(4));
                            int Stock = Convert.ToInt32(rdr.GetValue(6));
                            int StockComprometido = Convert.ToInt32(rdr.GetValue(7));

                            producto = new Producto(Id, Nombre, Precio, Cat, PrecioOferta, Foto, Stock, StockComprometido);
                            ListaProductos.Add(producto);
                        }
                    }
                    conn.Close();

                }
            }
            catch
            {
                throw new ArgumentException("Error Cargando Categorias");
            }
            return ListaProductos;
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