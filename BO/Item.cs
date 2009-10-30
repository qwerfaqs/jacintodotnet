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
            this.Total = UnProducto.Precio * Cantidad;
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
                Total = _Cantidad * this.UnProducto.Precio;
            }
        }

        public float Total
        {
            get
            {
                return (_total);
            }
            set
            {
                _total = value;
            }
        }


        
        
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





    }
}
