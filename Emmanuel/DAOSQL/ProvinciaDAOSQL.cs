using System;
using System.Collections;//.Generic;
using System.Text;

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
        
        
        

        

    }
}
