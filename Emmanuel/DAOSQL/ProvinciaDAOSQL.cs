using System;
using System.Collections;//.Generic;
using System.Text;
using BO;
using System.Data.SqlClient;
namespace DAOSQL
{
    public sealed class ProvinciaDAOSQL
    {
        ////obtengo la cultura inglesa sin region ni pais, independiente del sistema operativo
        CultureInfo cultura = CultureInfo.InvariantCulture;
        private ArrayList Provincias;
        private static readonly ProvinciaDAOSQL _instancia = new ProvinciaDAOSQL();
        private ConecctionServer CS = ConecctionServer.Instancia();
        public static ProvinciaDAOSQL Instancia()
        {
            return _instancia;
        }
        private ProvinciaDAOSQL()
        { 
            
        }

        public Provincia ObtenerProvincia(int Id)
        {
            Provincia p = new Provincia(Id, "");
            SqlCommand cmd = new SqlCommand("select * from Provincia where idProvincia=" + Id, CS.Conexion);
            

        }
        
        
        
        

        

    }
}
