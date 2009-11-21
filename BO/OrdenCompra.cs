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
        private User _Cliente;
        private string _estado;
        private double _iva =0.21f;
        private double _envio = 50;

        public OrdenCompra(ArrayList items, int numero, User cliente, string estado)
        {
            _items = items;
            _numero = numero;
            _Cliente = cliente;
            _estado = estado;
        }

        public OrdenCompra()
        { }

        public double Envio
        {
            get { return _envio; }
            set { _envio = value; }
        }

        public ArrayList Items
        {
            get { return _items; }
            set { _items = value; }
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

	

        public User Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }
	

        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        public OrdenCompra(Carrito carr, User client,double iva): this(carr,client)
        {
            this._iva = iva;
        }
        public OrdenCompra(Carrito carr,User client)
        {
            this._items = carr.DameFuego();
            this._Cliente = client;
            this._estado = "PENDIENTE";            
        }
        
        

        
    
    
    }
}
