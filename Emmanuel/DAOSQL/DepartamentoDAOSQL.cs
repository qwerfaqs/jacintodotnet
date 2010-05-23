using System;
using System.Collections.Generic;
using System.Text;
using BO;
using System.Data.SqlClient;
namespace DAOSQL
{
    class DepartamentoDAOSQL
    {////obtengo la cultura inglesa sin region ni pais, independiente del sistema operativo
        CultureInfo cultura = CultureInfo.InvariantCulture;

        private static readonly DepartamentoDAOSQL _instancia = new DepartamentoDAOSQL();
        private ConecctionServer CS = ConecctionServer.Instancia();
        public static DepartamentoDAOSQL Instancia()
        {
            return _instancia;
        }
        private DepartamentoDAOSQL()
        {

        }

        public Provincia ObtenerDepartamento(int Id)
        {
            Departamento Departamento;
            
            connServ.Abrir();

            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = "SELECT Id,Nombre,IdProvincia FROM Departamento where Id=" + Id;
                command.Connection = connServ.Conexion();

                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Departamento = new Departamento(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1), Convert.ToInt32(rdr.GetValue(2)));
                }
            }
            connServ.Cerrar();
            return Departamento;
        }
    }
}