using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace BO
{
    public class Producto
    {
        string _Nombre;
        int _Precio;
        int _Codigo;
        Categoria _Cat;
        private int _StockActual;
        private int _StockComprometido;
        private Image  _FotoPath;
        private int _PrecioOferta;

        public Producto()
        { }
        public Producto(int Codigo,string Nombre,int Precio,Categoria Cat,int PrecioOferta,Image FotoPath,int StockActual, int StockComprometido)
        {
            this._Codigo = Codigo;
            this._Nombre = Nombre;
            this._Precio = Precio ;
            this._Cat = Cat;
            this._PrecioOferta = PrecioOferta;
            this._StockActual = StockActual;
            this._StockComprometido = StockComprometido;
            this._FotoPath = FotoPath;                      
        }

        public int Codigo
        {
            get
            {
                return (_Codigo);
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

        public int Precio
        {
            get
            {
                return (_Precio);
            }
            set
            {
                _Precio = value;
            }
        }

        public Categoria Cat
        {
            get
            {
                return (_Cat);
            }
            set
            {
                _Cat = value;
            }
        }

        public int StockActual
        {
            get { return _StockActual; }
            set { _StockActual = value; }
        }


        public int StockComprometido
        {
            get { return _StockComprometido; }
            set { _StockComprometido = value; }
        }

        public Image FotoPath
        {
            get { return _FotoPath; }
            set { _FotoPath = value; }
        }


        public int PrecioOferta
        {
            get { return _PrecioOferta; }
            set { _PrecioOferta = value; }
        }

        public override string ToString()
        {
            return this.Nombre+"  $ "+this.Precio.ToString();
        }
    
    
    
    
    
    
    
    
    }
}
