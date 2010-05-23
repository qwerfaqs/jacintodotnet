using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class User
    {

        private string nombre;
        private string apellido;
        private string email;
        private string nickname;
        private string pass;
        private string domicilio;
        private int id;
        private int categoria;
        private int id_localidad;

        public User()
        { }
        public User(string Nombre, string Apellido, string Email, string NickName, string Pass, string Domicilio,int Id,int Categoria,int IdLocalidad)
        {
            nombre = Nombre;
            apellido = Apellido;
            email = Email;
            nickname = NickName;
            pass = Pass;
            domicilio = Domicilio;
            id = Id;
            categoria = Categoria;
            id_localidad = IdLocalidad;
        }

        public override string ToString()
        {
            return this.nombre+" "+this.apellido;
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
        public int IdLocalidad
        {
            get { return id_localidad; }
            set { id_localidad = value; }
        }
        public int Categoria
        {
            get { return categoria; }
            set { categoria= value; }
        }
    }
}
