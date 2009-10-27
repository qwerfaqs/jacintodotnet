using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class User
    {
        
        public string nombre;
        public string apellido;
        public string email;
        public string nickname;
        private string pass;
        private string domicilio;
        private int id;
        private short categoria;

        public User(string Nombre, string Apellido, string Email, string NickName, string Pass, string Domicilio,int Id,short Categoria)
        {
            nombre = Nombre;
            apellido = Apellido;
            email = Email;
            nickname = NickName;
            pass = Pass;
            domicilio = Domicilio;
            id = Id;
            categoria = Categoria;
        }

        public string Nombre
        { 
            get{return nombre;}
            set { nombre = value; }
        }
        public string Apellido
        { 
            get{return apellido;}
            set { apellido = value; }
        }
        public string Email
        { 
            get{return email;}
            set { email = value; }
        }
        public string NickName
        { 
            get{return nickname;}
            set { nickname = value; }
        }
        public string Pass
        { 
            get{return pass;}
            set { pass = value; }
        }
        public string Domicilio
        { 
            get{return domicilio;}
            set { domicilio = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public short Categoria
        {
            get { return categoria; }
            set { categoria= value; }
        }
    }
}
