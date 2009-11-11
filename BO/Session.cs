using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BO
{
    public class Session
    {
        User _user;
        ArrayList SessionVariables = new ArrayList();
        public bool Loged
        {
            get 
            {
                bool salida = false;
                if (_user!=null) { salida = true; }
                return salida;
            }
        }
        public string tipo
        {
            get
            {
                string salida = null;
                if (_user.Categoria == 2)
                {
                    salida = "ADMIN";
                }
                else if(_user.Categoria == 1)
                {
                    salida = "CLIENT";
                }
                return salida;
            }
            
        }
        public Session(User usuario)
        {
            this._user = usuario;
        }
    }
}
