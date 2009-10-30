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

        public void EliminarCategoria(int catID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=EMMANUEL2; Initial Catalog=Examen; Integrated Security=True"))
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

                using (SqlConnection conn = new SqlConnection("Data Source=EMMANUEL2; Initial Catalog=Examen; Integrated Security=True"))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "SELECT Id,Nombre FROM CATEGORIAS";
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
                return null;
            }
        }
        //public void agregar_categoria(Categoria cat)
        //{
        //    ListaCategorias.Add(cat);
        //}
        //public ArrayList leer_categorias()
        //{
        //    return ListaCategorias;
        //}
        //public void EliminarCategoria(int i)
        //{
        //    ListaCategorias.RemoveAt(i);
        //}
        //public int CodigoCategoria(int indice)
        //{
        //    Categoria c = (Categoria)ListaCategorias[indice];
        //    return c.Codigo;
        //}
        //public string NombreCategoria(int indice)
        //{
        //    Categoria c = (Categoria)ListaCategorias[indice];
        //    return c.Nombre;
        //}
        //public int IdCategoria(int indice)
        //{
        //    Categoria c = (Categoria)ListaCategorias[indice];
        //    return c.Codigo;
        //}
        //public string NombreCategoriaPorId(int Id)
        //{
        //    string Cat = "";
        //    foreach (Categoria cat in ListaCategorias)
        //    {
        //        if (cat.Codigo == Id)
        //        {
        //            Cat = cat.Nombre;
        //            break;
        //        }
        //    }
        //    return Cat;
        //}
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
        //public Categoria ObjetoCategoria(int i)
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
        // public void EliminarItem(int catID)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection("ConnectionString"))
        //        {
        //            conn.Open();
                    
        //            using (SqlCommand command = new SqlCommand())
        //            {
        //                command.CommandText = "DELETE FROM Categorias WHERE ID=" + catID;
        //                command.Connection = conn;

        //                command.ExecuteNonQuery();
        //            }
                    
        //            conn.Close();
        //        }
        //    }
        //    catch 
        //    { }
        //}
         
        //public IList<Categoria> ModificarItem()
        //{
        //    try
        //    {
        //        IList<Categoria> listCategorias = new List<Categoria>();
        //        Categoria cat = null;
        //        using (SqlConnection conn = new SqlConnection("ConnectionString"))
        //        {
        //            conn.Open();

        //            using (SqlCommand command = new SqlCommand())
        //            {
        //                command.CommandText = "SELECT ID,NAME FROM CATEGORIES";
        //                command.Connection = conn;

        //                SqlDataReader rdr = command.EndExecuteReader();

        //                while (rdr.Read())
        //                {
        //                    cat = new Categoria(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1).ToString());
        //                    listCategorias.Add(cat);
        //                }
        //            }
        //            conn.Close();
        //        }

        //        return listCategorias;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}
