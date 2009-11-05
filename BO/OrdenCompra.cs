using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using BO;

namespace BO
{
    public class OrdenCompra 
    {
        private ArrayList _items;
        private int _numero;
        private Cliente _unCliente;
        private string _estado;
        private double _iva =0.21f;
        private double _envio = 50;

        public double Envio
        {
            get { return _envio; }
            set { _envio = value; }
        }


        public double Iva
        {
            get { return _iva; }
            set { _iva = value; }
        }


        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

	

        public Cliente UnCliente
        {
            get { return _unCliente; }
            set { _unCliente = value; }
        }
	

        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        public OrdenCompra(Carrito carr, Cliente client,double iva): this(carr,client)
        {
            this._iva = iva;

        }
        public OrdenCompra(Carrito carr,Cliente client)
        {
            this._items = carr.DameFuego();
            this._unCliente = client;
            this.estado = "PENDIENTE";
            


        }
        

        
    
    
    }
}
