using System;
using System.Collections;//.Generic;
using System.Text;
using System.Data.SqlClient;
using BO;
namespace DAOSQL
{
    public sealed class DAOSQLCategorias
    {
        
        
        private ArrayList ListaCategorias = new ArrayList();
        private ConecctionServer connServ = ConecctionServer.Instancia();
        private static readonly DAOSQLCategorias _instancia = new DAOSQLCategorias();
        public static DAOSQLCategorias Instancia ()
        {
             return _instancia;    
        }
        private DAOSQLCategorias()
        {
            //Constructor Privado es necesario para respetar el singlenton
        }
       
        
        public void EliminarCategoriaId(int catID)
        {
            try
            {

                connServ.Abrir();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "DELETE FROM Categorias WHERE Id=" + catID;
                        command.Connection = connServ.Conexion();

                        command.ExecuteNonQuery();
                    }
                    connServ.Cerrar();
                
            }
            catch(Exception ex)
            {
                throw new Exception("ERROR ELIMINANDO CATEGORIA", ex);
            }
        }
       
        public ArrayList leer_categorias(bool DesdeMemoria)
        {
            if (DesdeMemoria)
            {
                try
                {
                    if (ListaCategorias != null && ListaCategorias.Count > 0)
                    {
                        return ListaCategorias;
                    }
                    else
                        return null;
                }
                catch(Exception ex) 
                {
                    throw new ArgumentException("Error",ex);
                }                
            }            	        
		    else
            {
                try
                {
                    //ListaCategorias = new ArrayList();
                    ListaCategorias.Clear();
                    
                        Categoria cat = null;
                        connServ.Abrir();

                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = "SELECT Id,Nombre FROM Categorias";
                            command.Connection = connServ.Conexion();

                            SqlDataReader rdr = command.ExecuteReader();

                            while (rdr.Read())
                            {

                                cat = new Categoria(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1).ToString());
                                ListaCategorias.Add(cat);
                            }
                        }
                        connServ.Cerrar();
                        
                    
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Error Cargando Categorias ",e);
                }
                return ListaCategorias;
            }
        }

        public void agregar_categoria(Categoria cat)
        {
            try
            {

                connServ.Abrir();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "INSERT INTO Categorias (Id,Nombre) values ("+cat.Codigo+",'"+cat.Nombre+"')";
                        command.Connection = connServ.Conexion();

                        command.ExecuteNonQuery();
                    }
                    connServ.Cerrar();
                
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Error Agregando Categoria",ex);
            }
        }

        public void ModificarCategoria(int codigo, string nombre)
        {
            try
            {
                
                    connServ.Abrir();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "UPDATE Categorias Set Nombre='"+nombre+"' where Id="+codigo+"";
                        command.Connection = connServ.Conexion();

                        command.ExecuteNonQuery();
                    }
                    connServ.Cerrar();
                
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Error Modificando Categoria",ex);
            }
        }
        
        public Categoria UnObjetoCategoria(int i)
        {
            Categoria Nueva = new Categoria();
            try
            {
                if (ListaCategorias!=null)
                {
                    foreach (Categoria c in ListaCategorias)
                    {
                        if (c.Codigo == i)
                        {
                            Nueva.Codigo = c.Codigo;
                            Nueva.Nombre = c.Nombre;

                            break;
                        }
                    } 
                }
                
                return Nueva;
                
            }
            catch(Exception ex) 
            {
                throw new ArgumentException("Error Buscando Categoria [DAOSQL]",ex) ;
            }         
        }
    }
}
