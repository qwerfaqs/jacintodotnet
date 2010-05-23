using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class Departamento
    {
        private int id;
        private string nombre;
        private int idProvincia;


        public Departamento() { }
        public Departamento(int Id, string Nombre,int IdProvincia)
        {
            id = Id;
            nombre = Nombre;
            idProvincia = IdProvincia;
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

        public int IdProvincia
        {
            get { return idProvincia; }
            set { idProvincia = value; }
        }
    }
}
