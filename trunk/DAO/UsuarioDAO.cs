using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

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

        public  void AgregarUsuario(BO.User usuario)
        {
            Usuarios.Add(usuario);
        }


        public  short Logueo(string Nick, string Pass)
        {
            short Entra = -1;
            foreach (BO.User Chabon in Usuarios)
            {
                if (Chabon.NickName == Nick)
                {
                    if (Chabon.Pass == Pass)
                    {
                        Entra = Chabon.Categoria;
                    }
                    break;
                }
            }
            return Entra;
        }
    }
}
