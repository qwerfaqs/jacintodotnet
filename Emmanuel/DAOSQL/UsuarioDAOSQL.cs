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
                    command.CommandText = "INSERT INTO Usuarios (categoria,apellido,nombre,pass,domicilio,email,nickname, id_localidad)VALUES(" + usuario.Categoria + ", '" + usuario.Apellido + "', '" + usuario.Nombre + "', '" + usuario.Pass + "', '" + usuario.Domicilio + "', '" + usuario.Email + "', '" + usuario.NickName + "',"+usuario.IdLocalidad+")";
                    command.Connection = connServ.Conexion();

                    command.ExecuteNonQuery();
                }
                connServ.Cerrar();

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error Agregando Usuario", ex);
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
                {   //                                 0          1         2       3     4      5        6       7     
                    command.CommandText = "SELECT id_usuario,categoria,apellido,nombre,pass,domicilio,email,nickname,id_localidad FROM Usuarios where nickname='"+Nick+"' and pass='"+Pass+"'";
                    command.Connection = connServ.Conexion();

                    SqlDataReader rdr = command.ExecuteReader();
                    

                    while (rdr.Read())
                    {
                        result = new User(rdr.GetString(3), rdr.GetString(2), rdr.GetString(6), rdr.GetString(7), rdr.GetString(4), rdr.GetString(5), rdr.GetInt32(0), rdr.GetInt32(1),Convert.ToInt32(rdr.GetValue(8)));
                        
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
                
        public ArrayList TodosLosUsuarios()
        {
            ArrayList ListaUsuarios=new ArrayList();
            connServ.Abrir();

            using (SqlCommand command3 = new SqlCommand())
            {   //                                 0          1         2       3     4      5        6       7     
                command3.CommandText = "SELECT id_usuario,categoria,apellido,nombre,pass,domicilio,email,nickname, id_localidad FROM Usuarios";
                command3.Connection = connServ.Conexion();

                SqlDataReader rdr3 = command3.ExecuteReader();


                while (rdr3.Read())
                {
                    User Usuario  = new User(rdr3.GetString(3), rdr3.GetString(2), rdr3.GetString(6), rdr3.GetString(7), rdr3.GetString(4), rdr3.GetString(5), rdr3.GetInt32(0), rdr3.GetInt32(1),Convert.ToInt32(rdr3.GetValue(8)));
                    ListaUsuarios.Add(Usuario);
                }
            }
            connServ.Cerrar();
                       
            return ListaUsuarios;
        }

        public User UnUser(int UserId)
        {
            User result = null;
            
            connServ.Abrir();

            using (SqlCommand command3 = new SqlCommand())
            {   //                                 0          1         2       3     4      5        6       7     
                command3.CommandText = "SELECT id_usuario,categoria,apellido,nombre,pass,domicilio,email,nickname, id_localidad FROM Usuarios where id_usuario='" + UserId + "'";
                command3.Connection = connServ.Conexion();

                SqlDataReader rdr3 = command3.ExecuteReader();


                while (rdr3.Read())
                {
                    result = new User(rdr3.GetString(3), rdr3.GetString(2), rdr3.GetString(6), rdr3.GetString(7), rdr3.GetString(4), rdr3.GetString(5), rdr3.GetInt32(0), rdr3.GetInt32(1),Convert.ToInt32(rdr3.GetValue(8)));

                }
            }
            connServ.Cerrar();
            
            if (result == null)
            {
                throw new Exception("ERROR: NO EXISTE TAL USUARIO");
            }
            return result;
        }

        public void EliminarUser(int UserId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("delete Usuarios where id_usuario=" + UserId, connServ.Conexion());
                connServ.Abrir();
                cmd.ExecuteNonQuery();
                connServ.Cerrar();
            }
            catch 
            {
                throw new ArgumentException("[DAOSQL] - Error Eliminando Usuario");
            }
        }     
    }
}
