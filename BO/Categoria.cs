using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
 public class Categoria
    {
        int _Codigo;
        string _Nombre;
        
        public Categoria(int Codigo, string Nombre)
        {
            this._Codigo = Codigo;
            this._Nombre = Nombre;
        }
        public Categoria()
        {}

        public int Codigo
        {
            get
            { 
                return(_Codigo);
            }
            set
            {
                _Codigo = value;
            }        
        }

        public string Nombre
        {
            get
            {
                return (_Nombre);
            }
            set
            {
                _Nombre = value;
            }
        }
          

         public override string ToString()
         {
             return this.Nombre;
         }












    }
}
