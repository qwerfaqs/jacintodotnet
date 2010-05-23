using System;
using System.Collections;//.Generic;
using System.Text;
using BO;
using System.Data.SqlClient;
using System.Globalization;

namespace DAOSQL
{
    public sealed class ProvinciaDAOSQL
    {
        ConecctionServer connServ = ConecctionServer.Instancia();
        ////obtengo la cultura inglesa sin region ni pais, independiente del sistema operativo
        CultureInfo cultura = CultureInfo.InvariantCulture;
        
        private static readonly ProvinciaDAOSQL _instancia = new ProvinciaDAOSQL();
        
        public static ProvinciaDAOSQL Instancia()
        {
            return _instancia;
        }
        private ProvinciaDAOSQL()
        { 
            
        }
        
        public Provincia ObtenerProvincia(int Id)
        {
            Provincia Provincia=new Provincia(0,"");
            connServ.Abrir();

            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = "SELECT Id,Nombre FROM Provincia where Id="+Id;
                command.Connection = connServ.Conexion();

                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Provincia = new Provincia(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1).ToString());                                        
                }
            }
            connServ.Cerrar();
            return Provincia;            

        }
        
        
        
        

        

    }
}
