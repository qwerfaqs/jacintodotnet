using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using BO;

namespace BO
{
    public class OrdenCompra 
    {
        private Carrito _unCarrito;
        private int _numero;
        private Cliente _unCliente;
        private string _pendiente;
        private double _iva;
        private double _envio;

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


        public string Pendiente
        {
            get { return _pendiente; }
            set { _pendiente = value; }
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

        public OrdenCompra(int numero,Carrito carr, double iva, double total,double envio, DateTime fecha, string estado)
        {
            this.Numero = numero;
            this.UnCarrito = carr;
            this.Iva = iva;
            this.Pendiente = estado;
            this.Envio = envio;
        }


        public Carrito UnCarrito
        {
            get { return _unCarrito; }
            set { _unCarrito = value; }
        }
    
    
    }
}
