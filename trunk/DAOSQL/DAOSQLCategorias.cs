using System;
using System.Collections.Generic;
using System.Text;

namespace DAOSQL
{
    public class DAOSQLCategorias
    {
        
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
