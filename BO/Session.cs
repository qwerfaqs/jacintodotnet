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
        bool Loged
        {
            get { if (_user!=null) { return true; } }
        }
        string tipo
        {
            get
            {
                if (_user.Categoria == 2)
                {
                    return "ADMIN";
                }
                else if(_user.Categoria == 1)
                {
                    return "CLIENT";
                }
            }
            
        }
        public Session(User usuario)
        {
            this._user = usuario;
        }
    }
}
