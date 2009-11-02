using System;
using System.Collections;//.Generic;
using System.Text;
using System.Data.SqlClient;
using BO;
namespace DAOSQL
{
    public sealed class DAOSQLCategorias
    {
        
        
        private static ArrayList ListaCategorias = new ArrayList();
        private ConecctionServer connServ = ConecctionServer.Instancia();
        private static readonly DAOSQLCategorias _instancia = new DAOSQLCategorias();
        public static DAOSQLCategorias Instancia ()
        {
             return _instancia;    
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
            catch
            { }
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
                catch 
                {
                    throw new ArgumentException("Error");
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
                    throw new ArgumentException("Error Cargando Categorias :"+e.Message);
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
            catch
            {
                throw new ArgumentException("Error Agregando Categoria");
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
            catch
            {
                throw new ArgumentException("Error Modificando Categoria");
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
            catch 
            {
                throw new ArgumentException("Error Buscando Categoria [DAOSQL]") ;
            }         
        }
    }
}
