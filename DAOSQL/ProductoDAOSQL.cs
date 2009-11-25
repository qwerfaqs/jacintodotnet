using System;
using System.Collections;//.Generic;
using System.Text;
using BO;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;
using System.Globalization;
namespace DAOSQL
{
    public sealed class ProductoDAOSQL
    {
        //obtengo la cultura inglesa sin region ni pais, independiente del sistema operativo
        CultureInfo cultura = CultureInfo.InvariantCulture;
        private ArrayList ListaProductos;
        private static readonly ProductoDAOSQL _instancia = new ProductoDAOSQL();
        private ConecctionServer connServ = ConecctionServer.Instancia();
        public static ProductoDAOSQL Instancia()
        {
            return _instancia;
        }
        private ProductoDAOSQL()
        {
            //Constructor Privado es necesario para respetar el singlenton
        }
        public void modificar_producto(Producto product)
        {
            try
            {
                
                    connServ.Abrir();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "UPDATE Productos SET Id=" + product.Codigo + ",Nombre ='" + product.Nombre + "',Categoria=" + product.Cat.Codigo + ",Precio=" + product.Precio.ToString(this.cultura) + ",PrecioOferta=" + product.PrecioOferta.ToString(this.cultura) + ",Foto= @img,Stock= " + product.StockActual + ",StockComprometido=" + product.StockComprometido + " where Id="+product.Codigo;
                        command.Parameters.Add("@img", SqlDbType.Image);
                        command.Connection = connServ.Conexion();
                        if (product.FotoPath != null)
                        {
                            MemoryStream ms = new MemoryStream();
                            product.FotoPath.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            command.Parameters["@img"].Value = ms.GetBuffer();
                        }
                        command.ExecuteNonQuery();
                    }
                    connServ.Cerrar();
                
            }
            catch
            {
                throw new ArgumentException("Error Modificando Producto");
            }
        }

        public void Agregar_producto(Producto product)
        {
            try
            {
                    connServ.Abrir();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "INSERT INTO Productos (Id,Nombre,Categoria,Precio,PrecioOferta,Foto,Stock,StockComprometido) values (" + product.Codigo + ",'" + product.Nombre + "'," + product.Cat.Codigo + "," + product.Precio.ToString(this.cultura) + "," + product.PrecioOferta + ",@img," + product.StockActual + "," + product.StockComprometido.ToString(this.cultura) + ")";
                        command.Parameters.Add("@img", SqlDbType.Image);
                        command.Connection = connServ.Conexion();
                        if (product.FotoPath != null)
                        {
                            MemoryStream ms = new MemoryStream();
                            product.FotoPath.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            command.Parameters["@img"].Value = ms.GetBuffer();
                        }

                        command.ExecuteNonQuery();
                    }
                    connServ.Cerrar();
                
            }
            catch
            {
                throw new ArgumentException("Error Agregando Producto");
            }
        }

        public ArrayList leer_productos(int Categoria1)
        {
            string string1 = "", string2 = "";
            if (Categoria1 > -1)
            {
                string1 = "where Categoria = ";
                string2 = Convert.ToString(Categoria1);
            }

            try
            {
                ListaProductos = new ArrayList();
                ListaProductos.Clear();
                
                    Producto producto = null;
                    connServ.Abrir();

                    using (SqlCommand command = new SqlCommand())
                    {//                                0    1        2      3         4        5     6          7
                        command.CommandText = "SELECT Id,Nombre,Categoria,Precio,PrecioOferta,Foto,Stock,StockComprometido FROM Productos " + string1 + string2;
                        command.Connection = connServ.Conexion();

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
                            double Precio = Convert.ToDouble(rdr.GetValue(3));
                            double PrecioOferta = Convert.ToDouble(rdr.GetValue(4));
                            int Stock = Convert.ToInt32(rdr.GetValue(6));
                            int StockComprometido = Convert.ToInt32(rdr.GetValue(7));

                            producto = new Producto(Id, Nombre, Precio, Cat, PrecioOferta, Foto, Stock, StockComprometido);
                            ListaProductos.Add(producto);
                        }
                        rdr.Close();
                    }
                    connServ.Cerrar();

                
            }
            catch
            {
                throw new ArgumentException("Error Cargando Productos");
            }
            return ListaProductos;
        }

        public void EliminarProducto(Producto UnProducto)
        {
            try
            {
                
                    connServ.Abrir();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "DELETE Productos WHERE Id=" + UnProducto.Codigo + "";
                        command.Connection = connServ.Conexion();

                        command.ExecuteNonQuery();
                    }
                    connServ.Cerrar();
                
            }
            catch
            {
                throw new ArgumentException("Error Eliminando Producto");
            }
        }

        public Producto leer_unproducto(int codigoproducto)
        {
            
            Producto producto = null;
            string string1 = "", string2 = "";

            string1 = "where Id=";
            string2 = Convert.ToString(codigoproducto);

            //try
            //{
                    connServ.Abrir();

                    using (SqlCommand command = new SqlCommand())
                    {//                                0    1        2      3         4        5     6          7
                        command.CommandText = "SELECT Id,Nombre,Categoria,Precio,PrecioOferta,Foto,Stock,StockComprometido FROM Productos " + string1 + string2;
                        command.Connection = connServ.Conexion();

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
                        }
                        rdr.Close();
                    }
                    connServ.Cerrar();
            //}
            //catch
            //{
            //    throw new ArgumentException("Error Obteniendo un objeto del Tipo Producto");
            //}
            return producto;
        }
    }
}
