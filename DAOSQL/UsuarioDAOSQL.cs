using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using BO;
using System.Data.SqlClient;

namespace DAOSQL
{
    public sealed class UsuarioDAOSQL
    {
        private static readonly UsuarioDAOSQL _instancia = new UsuarioDAOSQL();
        private ConecctionServer connServ = ConecctionServer.Instancia();
        private UsuarioDAOSQL()
        {

        }
        public static UsuarioDAOSQL Instancia()
        {
            return _instancia;
        }
        public void AgregarUsuario(BO.User usuario)
        {
            try
            {

                connServ.Abrir();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "INSERT INTO Usuarios (categoria,apellido,nombre,pass,domicilio,email,nickname)VALUES(" + usuario.Categoria + ", '" + usuario.Apellido + "', '" + usuario.Nombre + "', '" + usuario.Pass + "', '" + usuario.Domicilio + "', '" + usuario.Email + "', '" + usuario.NickName + "')";
                    command.Connection = connServ.Conexion();

                    command.ExecuteNonQuery();
                }
                connServ.Cerrar();

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error Agregando Categoria", ex);
            }
        }
  
        public User Logueo(string Nick, string Pass)
        {
            User result = null;
            ///hago un select y si me lo devuelve es que esta logeado
            try
            {
                
                connServ.Abrir();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT id_usuario,categoria,apellido,nombre,pass,domicilio,email,nickname FROM Usuarios where nickname='"+Nick+"' and pass='"+Pass+"'";
                    command.Connection = connServ.Conexion();

                    SqlDataReader rdr = command.ExecuteReader();
                    

                    while (rdr.Read())
                    {
                        result = new User(rdr.GetString(3), rdr.GetString(2), rdr.GetString(6), rdr.GetString(7), rdr.GetString(4), rdr.GetString(5), rdr.GetInt32(0), rdr.GetInt16(1));
                        
                    }
                }
                connServ.Cerrar();


            }
            catch (Exception e)
            {
                throw new ArgumentException("Error Cargando LEYENDO USUARIOS", e);
            }
            if (result == null)
            {
                throw new Exception("ERROR DE LOGIN");
            }
            return result;
        }
    }
}
