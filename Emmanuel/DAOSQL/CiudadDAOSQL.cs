using System;
using System.Collections.Generic;
using System.Text;
using BO;
using System.Data.SqlClient;

namespace DAOSQL
{
    class CiudadDAOSQL
    {
        ////obtengo la cultura inglesa sin region ni pais, independiente del sistema operativo
        CultureInfo cultura = CultureInfo.InvariantCulture;

        private static readonly CiudadDAOSQL _instancia = new CiudadDAOSQL();
        private ConecctionServer CS = ConecctionServer.Instancia();
        public static CiudadDAOSQL Instancia()
        {
            return _instancia;
        }
        private CiudadDAOSQL()
        {

        }

        public Provincia ObtenerCiudad(int Id)
        {
            Ciudad Ciudad;
            
            connServ.Abrir();

            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = "SELECT Id,Nombre, IdDepartamento FROM Localidad where Id=" + Id;
                command.Connection = connServ.Conexion();

                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Ciudad = new Ciudad(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1), Convert.ToInt32(rdr.GetValue(2)));
                }
            }
            connServ.Cerrar();
            return Ciudad;
        }

    }
}
