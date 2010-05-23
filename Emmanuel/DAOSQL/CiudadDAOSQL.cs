using System;
using System.Collections;//.Generic;
using System.Text;
using BO;
using System.Data.SqlClient;
using System.Globalization;

namespace DAOSQL
{
    public class CiudadDAOSQL
    {
        ////obtengo la cultura inglesa sin region ni pais, independiente del sistema operativo
        CultureInfo cultura = CultureInfo.InvariantCulture;

        private static readonly CiudadDAOSQL _instancia = new CiudadDAOSQL();
        
        private ConecctionServer connServ = ConecctionServer.Instancia();
        
        public static CiudadDAOSQL Instancia()
        {
            return _instancia;
        }
        
        private CiudadDAOSQL()
        {

        }

        public Ciudad ObtenerCiudad(int Id)
        {
            Ciudad Ciudad=new Ciudad();
            
            connServ.Abrir();

            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = "SELECT Id,Nombre, IdDepartamento FROM Localidad where Id=" + Id;
                command.Connection = connServ.Conexion();

                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Ciudad = new Ciudad(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1).ToString(), Convert.ToInt32(rdr.GetValue(2)));
                }
            }
            connServ.Cerrar();
            return Ciudad;
        }
        public ArrayList ObtenerCiudades(int IdProvincia)
        {
            Ciudad Ciudad = new Ciudad();
            ArrayList Ciudades=new ArrayList();
            connServ.Abrir();

            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = "select c.Id,c.Nombre, c.IdDepartamento from Localidad c left join Departamento d on d.Id=c.IdDepartamento left join Provincia p on p.Id=d.IdProvincia where p.Id=" + IdProvincia + " order by c.nombre asc";
                command.Connection = connServ.Conexion();

                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Ciudad = new Ciudad(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1).ToString(), Convert.ToInt32(rdr.GetValue(2)));
                    Ciudades.Add(Ciudad);
                }
            }
            connServ.Cerrar();
            return Ciudades;
        }
    }
}
