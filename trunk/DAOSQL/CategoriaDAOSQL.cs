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
        
        //private static ArrayList ListaCategorias;
        private static readonly DAOSQLCategorias _instancia = new DAOSQLCategorias();
        public static DAOSQLCategorias Instancia ()
        {
             return _instancia;    
        }

        
        public void EliminarCategoriaId(int catID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=EMMANUEL2; Initial Catalog=Carrito; Integrated Security=True"))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "DELETE FROM Categorias WHERE Id=" + catID;
                        command.Connection = conn;

                        command.ExecuteNonQuery();
                    }
                    conn.Close();
                }
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
                    using (SqlConnection conn = new SqlConnection("Data Source=EMMANUEL2; Initial Catalog=Carrito; Integrated Security=True"))
                    {
                        Categoria cat = null;
                        conn.Open();

                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = "SELECT Id,Nombre FROM Categorias";
                            command.Connection = conn;

                            SqlDataReader rdr = command.ExecuteReader();

                            while (rdr.Read())
                            {

                                cat = new Categoria(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1).ToString());
                                ListaCategorias.Add(cat);
                            }
                        }
                        conn.Close();
                        
                    }
                }
                catch 
                {
                    throw new ArgumentException("Error Cargando Categorias");
                }
                return ListaCategorias;
            }
        }

        public void agregar_categoria(Categoria cat)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=EMMANUEL2; Initial Catalog=Carrito; Integrated Security=True"))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "INSERT INTO Categorias (Id,Nombre) values ("+cat.Codigo+",'"+cat.Nombre+"')";
                        command.Connection = conn;

                        command.ExecuteNonQuery();
                    }
                    conn.Close();
                }
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
                using (SqlConnection conn = new SqlConnection("Data Source=EMMANUEL2; Initial Catalog=Carrito; Integrated Security=True"))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "UPDATE Categorias Set Nombre='"+nombre+"' where Id="+codigo+"";
                        command.Connection = conn;

                        command.ExecuteNonQuery();
                    }
                    conn.Close();
                }
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
