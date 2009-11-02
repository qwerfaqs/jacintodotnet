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
        private SqlConnection _conn = new SqlConnection();
        private IList<CadenaDeConexiones> _connectionStrings = new List<CadenaDeConexiones>();
        private String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
        private bool conecto = false;
        private ConecctionServer()
        {
            bool conecto = false;
            CargarListaStrings();
            foreach (CadenaDeConexiones cs in _connectionStrings)
            {
                
                try
                {

                    if (this.conecto == true && _conn.State == System.Data.ConnectionState.Open)
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
                    this.conecto = false;
                }
                finally
                {
                    if (_conn.State == System.Data.ConnectionState.Open)
                    {
                        this.conecto = true;
                        _conn.Close();

                    }
                    else
                    {
                        this.conecto = false;
                    }


                }
            }
            
        }
        public static ConecctionServer Instancia()
        {
            return _instancia;
        }
        public SqlConnection Conexion()
        {
            //this.CargarListaStrings();
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
            //this.CargarListaStrings();
            _conn.Open();
            
        }
        public void Cerrar()
        {
            _conn.Close();

        }
        }
}
