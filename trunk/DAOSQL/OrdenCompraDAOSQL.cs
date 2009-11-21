using System;
using System.Collections;//.Generic;
using System.Text;
using BO;
using System.Data.SqlClient;
namespace DAOSQL
{
    public sealed class OrdenCompraDAOSQL
    {
        private static readonly OrdenCompraDAOSQL _instancia = new OrdenCompraDAOSQL();
        private static Session Sesion = null;
        ConecctionServer connServ = ConecctionServer.Instancia();
        DAOSQL.ProductoDAOSQL DAOProductos = DAOSQL.ProductoDAOSQL.Instancia();
        DAOSQL.UsuarioDAOSQL DAOUsuarios = DAOSQL.UsuarioDAOSQL.Instancia();

        private OrdenCompraDAOSQL()
        {
        }
        
        public ArrayList LeerOrdenes()//nota: debido a q no puedo abrir 2 datareaders a la vz en una misma coneccion tengo q desconectar y luego volver a conectar para ir a buscar los items, lo mismo para el usuario de cada orden
        {
            //try
            //{
                ArrayList Ordenes = new ArrayList();
                OrdenCompra OC = null;
                connServ.Abrir();

                using(SqlCommand command = new SqlCommand())//aca lleno el arraylista con todas las ordenes
                {   //                                0          1         2         3           4            5        6     
                    command.CommandText = "SELECT id_orden, pendiente, total_iva, subtotal, total_envio, id_cliente, fecha FROM OrdenesCompra";
                    command.Connection = connServ.Conexion();
                    SqlDataReader rdr1 = command.ExecuteReader();
                    
                    int usuario;
                    while (rdr1.Read())
                    {
                        OC = new OrdenCompra();
                        OC.Envio = Convert.ToDouble(rdr1.GetValue(4));
                        OC.Estado = (string)rdr1.GetValue(1);
                        OC.Iva = Convert.ToDouble(rdr1.GetValue(2));
                        OC.Numero = (int)rdr1.GetValue(0);

                        OC.Items = new ArrayList();

                        usuario = (int)rdr1.GetValue(5);
                        OC.Cliente = new User("", "", "", "", "", "", usuario, 0);
                                                
                        Ordenes.Add(OC);
                    }
                    rdr1.Close();
                    connServ.Cerrar();
                }
                
                
                using (SqlCommand Command2 = new SqlCommand())//aca le agrego items a cada orden
                {
                    connServ.Abrir();
                    foreach (OrdenCompra unaOrden in Ordenes)
                    {   //                                   0         1                  2        3    4
                        Command2.CommandText = "SELECT id_orden, codigo_articulo, descripcion, precio, cant FROM DetallesOrden WHERE id_orden=" + unaOrden.Numero + " ";
                        Command2.Connection = connServ.Conexion();
                        
                        SqlDataReader rdr2 = Command2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            Item Item = new Item(DAOProductos.leer_unproducto((int)rdr2.GetValue(1)), (int)rdr2.GetValue(4));
                            unaOrden.Items.Add(Item);
                        }
                        rdr2.Close();
                    }
                }
                connServ.Cerrar();
                foreach (OrdenCompra unaorden in Ordenes)//aca le pongo el cliente a la orden
                {
                    unaorden.Cliente = DAOUsuarios.UnUser(unaorden.Cliente.Id);
                }
                
                

                return Ordenes;
            //}
                
            //catch (Exception e)
            //{
            //    throw new ArgumentException("Error Cargando Ordenes de Compra[DAOSQL]", e);
            //}
        }
        public ArrayList LeerOrdenes(string estado)
        {
            ArrayList Lista=null;
            return Lista;
        }

        public static OrdenCompraDAOSQL Instancia()
        {
            return _instancia;
        }
        
        public int grabarCompra(BO.OrdenCompra _orden)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public BO.OrdenCompra grabarCompra2(BO.OrdenCompra _orden)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        
        public BO.OrdenCompra LeerUnaOrden(int IdOrden)
        {
            throw new Exception("The method or operation is not implemented.");
        }       

        public void ModificarOrden(BO.OrdenCompra OC)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
