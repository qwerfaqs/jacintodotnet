using System;
using System.Collections.Generic;
using System.Text;
using DAO;

namespace Control
{
    public class ControlUsuarios
    {
        
        public ControlUsuarios()
        {
            this.miDao = DAO.UsuarioDAO.Instancia();
        }
        
        private DAO.UsuarioDAO miDao;
        public void AgregarNuevoUsuario(string Nombre,string Apellido, string Mail, string Nick,string Pass, string Domicilio, int Id, short Categoria)
        { 
            BO.User Nuevo=new BO.User(Nombre,Apellido,Mail,Nick,Pass,Domicilio, Id,Categoria);
            this.miDao.AgregarUsuario(Nuevo);
            
        }
        public short LogIn(string Nick, string Pass)
        {
            short categoria = this.miDao.Logueo(Nick, Pass);
            return categoria;
        }
    }
}
