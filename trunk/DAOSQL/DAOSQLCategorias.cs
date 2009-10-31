using System;
using System.Collections;//.Generic;
using System.Text;
using System.Data.SqlClient;
using BO;
namespace DAOSQL
{
    public sealed class DAOSQLCategorias
    {
        private static readonly DAOSQLCategorias _instancia = new DAOSQLCategorias();
        public static DAOSQLCategorias Instancia
        {
            get { return _instancia; }   
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
        public ArrayList leer_categorias()
        {
            try
            {
                //IList<Categoria> listCategorias = new List<Categoria>();
                ArrayList listCategorias = new ArrayList();
                Categoria cat = null;

                using (SqlConnection conn = new SqlConnection("Data Source=EMMANUEL2; Initial Catalog=Carrito; Integrated Security=True"))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "SELECT Id,Nombre FROM Categorias";
                        command.Connection = conn;

                        SqlDataReader rdr = command.ExecuteReader();

                        while (rdr.Read())
                        {

                            cat = new Categoria(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1).ToString());
                            listCategorias.Add(cat);
                        }
                    }
                    conn.Close();
                }

                return listCategorias;
            }
            catch 
            {
                throw new ArgumentException("Error Cargando Categorias");
            }
        }

        public void agregar_categoria(Categoria cat)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=EMMANUEL2; Initial Catalog=Examen; Integrated Security=True"))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "INSERT INTO Categorias (Id,Nombre) values ("+cat.Codigo+","+cat.Nombre+")";
                        command.Connection = conn;

                        command.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch
            { }
        }
        
        //public void ModificarCategoria(int codigo, string nombre)
        //{
        //    foreach (Categoria c in ListaCategorias)
        //    {
        //        if (c.Codigo == codigo)
        //        {
        //            c.Nombre = nombre;
        //            break;
        //        }
        //    }
        //}
        //public Categoria UnObjetoCategoria(int i)
        //{
        //    Categoria Nueva = new Categoria(0, "v");
        //    foreach (Categoria c in ListaCategorias)
        //    {
        //        if (c.Codigo == i)
        //        {
        //            Nueva.Codigo = c.Codigo;

        //            Nueva.Nombre = c.Nombre;
        //            break;
        //        }
        //    }
        //    return Nueva;
        //}
    }
}
