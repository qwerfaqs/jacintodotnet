using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class Provincia
    {
        private int id;
        private string nombre;

        public Provincia(int Id, string Nombre)
        {
            id = Id;
            nombre = Nombre;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
