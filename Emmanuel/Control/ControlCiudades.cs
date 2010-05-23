using System;
using System.Collections;//.Generic;
using System.Text;
using BO;
namespace Control
{
    public class ControlCiudades
    {
        private DAOSQL.ProvinciaDAOSQL DAOProvincia = DAOSQL.ProvinciaDAOSQL.Instancia();
        private DAOSQL.DepartamentoDAOSQL DAODepartamento = DAOSQL.DepartamentoDAOSQL.Instancia();
        private DAOSQL.CiudadDAOSQL DAOCiudad = DAOSQL.CiudadDAOSQL.Instancia();

        public ArrayList CargarProvincias()
        {
            return DAOProvincia.ObtenerProvincias();
        }

        public ArrayList CargarCiudadesporProvincia(int IdProvincia)
        {
            return DAOCiudad.ObtenerCiudades(IdProvincia);
        }

        public Departamento CargarDepartamentoporCiudad(int idCiudad)
        {
            Ciudad c = DAOCiudad.ObtenerCiudad(idCiudad);
            return DAODepartamento.ObtenerDepartamento(c.IdDepartamento);
        }

    }
    
}
