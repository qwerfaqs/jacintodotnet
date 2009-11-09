using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using BO;

namespace Control
{
    public class ControlUsuarios
    {
        //dao con Array list
        private DAO.UsuarioDAO miDao = DAO.UsuarioDAO.Instancia();
        //dao con SQL
        //private DAOSQL.UsuarioDAOSQL miDao = DAOSQL.UsuarioDAOSQL.Instancia();
        public ControlUsuarios()
        {
        }
        
        public void AgregarNuevoUsuario(string Nombre,string Apellido, string Mail, string Nick,string Pass, string Domicilio, int Id, short Categoria)
        { 
            BO.User Nuevo=new BO.User(Nombre,Apellido,Mail,Nick,Pass,Domicilio, Id,Categoria);
            this.miDao.AgregarUsuario(Nuevo);
            
        }
        public Session LogIn(string Nick, string Pass)
        {
            try
            {
                return new Session(this.miDao.Logueo(Nick, Pass));
            }
            catch (Exception e)
            {
                throw new Exception("ERROR AL CREAR SESSION", e);
            }
        }
    }
}
