using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Xml;

namespace DAOSQL
{
    public struct CadenaDeConexiones
    {
        public string descripcion;
        public string cadena;
        public CadenaDeConexiones(string descripcion, string cadena)
        {
            this.descripcion = descripcion;
            this.cadena = cadena;
        }
    }
    public sealed class ConecctionServer
    {
        private static readonly ConecctionServer _instancia = new ConecctionServer();
        public static ConecctionServer Instancia()
        {
            return _instancia;
        }
        private SqlConnection _conn = new SqlConnection();
        private IList<CadenaDeConexiones> _connectionStrings;
        private String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
        public SqlConnection Conexion()
        {
           return _conn;           
        }
        public void CargarListaStrings()
        {
            XmlDocument xmlListaConexiones = new XmlDocument();
            _connectionStrings.Clear();
            xmlListaConexiones.Load(path + "\\Conexiones.xml");
            XmlNode conexiones = xmlListaConexiones.GetElementsByTagName("conexiones")[0];
            foreach (XmlElement conexion in conexiones.ChildNodes)
            {
                _connectionStrings.Add(new CadenaDeConexiones(conexion.GetAttribute("name"),conexion.GetAttribute("connectionString")));
            }
            

        }
        public void Abrir()
        {
            
            foreach (CadenaDeConexiones cs in _connectionStrings)
            {
                bool conecto = false;
                try
                {

                    if (conecto == true && _conn.State == System.Data.ConnectionState.Open)
                    {
                        break;
                    }
                    else
                    {
                        _conn.ConnectionString = cs.cadena;
                        _conn.Open();
                    }
                }
                catch
                {
                    conecto = false;
                }
                finally
                {
                    if (_conn.State == System.Data.ConnectionState.Open)
                    {
                        conecto = true;
                    }
                    else
                    {
                        conecto = false;
                    }
                    
                }
            }
        }
        public void Cerrrar()
        {
        }
        }
}
