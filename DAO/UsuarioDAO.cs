using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using BO;

namespace DAO
{
    public sealed class UsuarioDAO
    {
        private static readonly UsuarioDAO _instancia = new UsuarioDAO();
        public static UsuarioDAO Instancia()
        {
            return _instancia;
        }
        private ArrayList Usuarios = new ArrayList();
        private UsuarioDAO()
        {
        }
        public  void AgregarUsuario(BO.User usuario)
        {
            Usuarios.Add(usuario);
        }


        public User Logueo(string Nick, string Pass)
        {
            User result = null;
            foreach (User Chabon in Usuarios)
            {
                if (Chabon.NickName == Nick)
                {
                    if (Chabon.Pass == Pass)
                    {
                        result = Chabon;
                    }
                }
            }
            if (result == null)
            {
                throw new Exception("ERROR DE LOGIN");
            }
            return result;
        }
    }
}
