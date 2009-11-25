using System;
using System.Collections;//.Generic;
using System.Text;
using BO;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace DAOSQL
{
    public sealed class OrdenCompraDAOSQL
    {
        //obtiene la cultura inglesa sin pais ni region,  independiente del sistema operativo
        CultureInfo cultura = CultureInfo.InvariantCulture;
        ArrayList ListaOrdenes = new ArrayList();
        private static readonly OrdenCompraDAOSQL _instancia = new OrdenCompraDAOSQL();
        private static Session Sesion = null;
        ConecctionServer connServ = ConecctionServer.Instancia();
        DAOSQL.ProductoDAOSQL DAOProductos = DAOSQL.ProductoDAOSQL.Instancia();
        DAOSQL.UsuarioDAOSQL DAOUsuarios = DAOSQL.UsuarioDAOSQL.Instancia();

        private OrdenCompraDAOSQL()
        {

        }
        
        public ArrayList LeerOrdenes()
        {
            try
            {
                ListaOrdenes.Clear();
                connServ.Abrir();

                using (SqlCommand command = new SqlCommand())
                {   //                                0        1         2         3          4         5        6
                    command.CommandText = "SELECT id_orden,pendiente,total_iva,subtotal,total_envio,id_cliente,fecha from OrdenesCompra";
                    command.Connection = connServ.Conexion();

                    SqlDataReader rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        //int StockComprometido = Convert.ToInt32(rdr.GetValue(7));
                        OrdenCompra Orden = new OrdenCompra();
                        Orden.Envio = Convert.ToDouble(rdr.GetValue(4));
                        Orden.Estado = rdr.GetValue(1).ToString();
                        Orden.Iva = Convert.ToDouble(rdr.GetValue(2));
                        Orden.Numero = (int)rdr.GetValue(0);
                        Orden.Items = new ArrayList();

                        User Usuario = new User();
                        Usuario.Id = (int)rdr.GetValue(5);
                        Orden.Cliente = Usuario;
                        
                        ListaOrdenes.Add(Orden);
                    }
                    rdr.Close();
                }
                connServ.Cerrar();
                CompletarListaOrdenes();
                return ListaOrdenes;
            }
            catch
            {
                throw new ArgumentException("Error Obteniendo un objeto del Tipo Producto");
            }
        }
        
        private void CompletarListaOrdenes()
        {
            try
            {
                
                DataTable dt=new DataTable();
                SqlDataReader reader;
                SqlCommand command = new SqlCommand(); 
                command.CommandText = "SELECT id_orden, codigo_articulo, descripcion, precio, cant from DetallesOrden";
                command.Connection=connServ.Conexion();

                connServ.Abrir();
                reader=command.ExecuteReader();
                dt.Load(reader);
                connServ.Cerrar();

                foreach(OrdenCompra Orden in ListaOrdenes)
                {
                    Orden.Cliente=DAOUsuarios.UnUser(Orden.Cliente.Id);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if ((int)dr["id_orden"] == Orden.Numero)
                        {
                            Producto p = DAOProductos.leer_unproducto((int)dr["codigo_articulo"]);
                            Orden.Items.Add(new Item(p,(int)dr["cant"]));                            
                        }
                    }
                }
            }
            catch
            {
                throw new ArgumentException("Error Cargando Items");
            }
        }

        public ArrayList LeerOrdenes(string estado)
        {
            try
            {
                ListaOrdenes.Clear();
                connServ.Abrir();

                using (SqlCommand command = new SqlCommand())
                {   //                                0        1         2         3          4         5        6
                    command.CommandText = "SELECT id_orden,pendiente,total_iva,subtotal,total_envio,id_cliente,fecha from OrdenesCompra WHERE pendiente='"+estado+"'";
                    command.Connection = connServ.Conexion();

                    SqlDataReader rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        //int StockComprometido = Convert.ToInt32(rdr.GetValue(7));
                        OrdenCompra Orden = new OrdenCompra();
                        Orden.Envio = Convert.ToDouble(rdr.GetValue(4));
                        Orden.Estado = rdr.GetValue(1).ToString();
                        Orden.Iva = Convert.ToDouble(rdr.GetValue(2));
                        Orden.Numero = (int)rdr.GetValue(0);
                        Orden.Items = new ArrayList();

                        User Usuario = new User();
                        Usuario.Id = (int)rdr.GetValue(5);
                        Orden.Cliente = Usuario;

                        ListaOrdenes.Add(Orden);
                    }
                    rdr.Close();
                }
                connServ.Cerrar();
                CompletarListaOrdenes();
                return ListaOrdenes;
            }
            catch
            {
                throw new ArgumentException("Error Leyendo Ordenes de Compra");
            }
        }

        public static OrdenCompraDAOSQL Instancia()
        {
            return _instancia;
        }
        
        public int grabarCompra(BO.OrdenCompra _orden)
        {
            try
            {
                connServ.Abrir();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "INSERT INTO OrdenesCompra (pendiente,total_iva,total_envio,id_cliente) values ('" + _orden.Estado + "', " + _orden.Iva.ToString(this.cultura) + ", " + _orden.Envio.ToString(this.cultura) + ", " + _orden.Cliente.Id + ") select @@identity";
                    command.Connection = connServ.Conexion();

                    _orden.Numero = Convert.ToInt32(command.ExecuteScalar());
                }
                connServ.Cerrar();
                GrabarItemsdeUnaOrden(_orden);
                return _orden.Numero;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error Generando Orden de Compra", ex);
            }
        }

        private void GrabarItemsdeUnaOrden(OrdenCompra UnaOrden)
        {
            try
            {
                connServ.Abrir();
                using (SqlCommand command = new SqlCommand())
                {
                    foreach (Item Item in UnaOrden.Items)
                    {
                        command.CommandText = "INSERT INTO DetallesOrden (id_orden, codigo_articulo, precio, cant) values ("+UnaOrden.Numero+","+Item._UnProducto.Codigo+","+Item._UnProducto.Precio.ToString(this.cultura)+","+Item.Cantidad+")";
                        command.Connection = connServ.Conexion();
                        command.ExecuteNonQuery();
                    }
                }
                connServ.Cerrar();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error Guardando Items", ex);
            }

        }

        //public BO.OrdenCompra grabarCompra2(BO.OrdenCompra _orden)
        //{
        //    try
        //    {

        //        connServ.Abrir();

        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.CommandText = "INSERT INTO OrdenesCompra (pendiente,total_iva,total_envio,id_cliente) values ('"+_orden.Estado+"', "+ _orden.Iva+", "+_orden.Envio+", "+ _orden.Cliente+")";
        //            command.Connection = connServ.Conexion();

        //            command.ExecuteNonQuery();
        //        }
        //        connServ.Cerrar();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException("Error Generando Orden de Compra", ex);
        //    }
        //}

        
        public BO.OrdenCompra LeerUnaOrden(int IdOrden)
        {
            OrdenCompra UnaOrden=new OrdenCompra();
            this.LeerOrdenes();
            foreach (OrdenCompra orden in ListaOrdenes)
            {
                if (orden.Numero == IdOrden)
                    UnaOrden = orden;
            }
            return UnaOrden;
        }       

        public void ModificarOrden(BO.OrdenCompra OC)
        {
            SqlCommand cmd = new SqlCommand("UPDATE OrdenesCompra set pendiente='"+OC.Estado+"' WHERE id_orden="+OC.Numero+"", connServ.Conexion());
            connServ.Abrir();
            cmd.ExecuteNonQuery();
            connServ.Cerrar();
        }
    }
}
