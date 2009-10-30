using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class Item
    {
        int _Cantidad;
        float _total;
        Producto _UnProducto;

        
        public Item(Producto UnProducto,int Cantidad)
        {
            this._Cantidad = Cantidad;
            this._UnProducto = UnProducto;
            //this.Total = UnProducto.Precio * Cantidad;
        }

        public int Cantidad
        {
            get
            {
                return (_Cantidad);
            }
            set
            {
                _Cantidad = value;
                
            }
        }

        public float Total
        {
            get
            {
                return (_Cantidad * this._UnProducto.Precio);
            }
            
        }


        
        /*
        public Producto UnProducto
        {
            get
            {
                return (_UnProducto);
            }
            set
            {
                _UnProducto = value;
            }
        }
        */
        public override string ToString()
        {
            return this.Nombre + "por"+this.Cantidad.ToString()+ "unidades $ " + this.Total.ToString();
        }
        public string Nombre
        {
            get
            {
                return (_UnProducto.Nombre);
            }
            set
            {
                _UnProducto.Nombre = value;
            }
        }
        public float PrecioUnitario
        {
            get
            {
                return (_UnProducto.Precio);
            }
            set
            {
                _UnProducto.Precio=value;
            }
        }
        public int Codigo
        {
            get
            {
                return (_UnProducto.Codigo);
            }
            
        }


    }

}
