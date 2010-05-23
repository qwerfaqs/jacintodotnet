using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    class Ciudad
    {
        private int id;
        private string nombre;
        private int idDepartamento;

        public Ciudad(int Id, string Nombre,int IdDepartamento)
        {
            id = Id;
            nombre = Nombre;
            idDepartamento = IdDepartamento;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento= value; }
        }
    }
}
