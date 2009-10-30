using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using BO;

namespace BO
{
    public class Cliente
    {
        private string _nombre;
        private string  _domicilio;
        private string  _ciudad;
        private string _email;

        public Cliente(string _nom, string _dom, string _ciu, string _em)
        {
            Nombre = _nom;
            Domicilio = _dom;
            Ciudad = _ciu;
            email = _em;
        }

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
	
        public string  Ciudad
        {
            get { return _ciudad; }
            set { _ciudad = value; }
        }
	
        public string  Domicilio
        {
            get { return _domicilio; }
            set { _domicilio = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public override string ToString()
        {
            return this.Nombre;
        }

    }
}
