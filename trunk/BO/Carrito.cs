using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;


namespace BO
{
  public  class Carrito
    {
        private ArrayList _ListaItems=new ArrayList();
        private DateTime _fecha;

        
        public Carrito(DateTime fecha)
        {
            this.Fecha = fecha;
        }

        public float Subtotal
        {
            get
            {
                float sub = 0;
                int x=0;
                while (( x < _ListaItems.Count))
                {
                    Item i = (Item)_ListaItems[x];
                    sub = sub +( i.Cantidad * i.PrecioUnitario);
                    x++;
                }
                return sub;
            }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public void agregar_item(Producto prod,int cant)
        {
            bool _existia = false;
            foreach (Item it in _ListaItems)
            {
                if (it.Codigo == prod.Codigo)
                {
                    it.Cantidad = it.Cantidad + cant;
                    _existia = true;
                }
            }
            if (_existia == false)
            {
                Item i = new Item(prod, cant);
                _ListaItems.Add(i);
            }
            
            
            
       

        }



      public bool modificar_item(Producto prod, int cant)
      {
              return modificaCantidad(prod ,cant);
      }

      public ArrayList ver_lista()
        {
            return _ListaItems;
        }

      //public bool ModificarStock(Producto UnProducto, int cant)
      //{
      //    int Encontrado = 0;
      //    int x = 0;
      //    while ((x < _ListaItems.Count) && (Encontrado == 0))
      //    {
      //        Producto Product = (Producto)_ListaItems[x];
      //        if (Product.Codigo == UnProducto.Codigo)
      //        {
      //            Product.StockActual =  cant;
      //            Encontrado = 1;
      //        }
      //        x++;
      //    }
      //    if (Encontrado == 1)
      //    {
      //        return true;
      //    }
      //    else { return false; }
      //}
      
      public  bool buscarProducto(Producto Prod)//busca un producto en el carrito
        {
            bool Encontrado = false ;
            int x = 0;
            while ((x < _ListaItems.Count) && (!Encontrado))
            {
                Item  i = (Item)_ListaItems[x];
                Encontrado = (i.Codigo == Prod.Codigo);
                x++;
            }
            return Encontrado;
            
        }
      
      private bool modificaCantidad(Producto prod, int cant)
      {
          bool modificado = false;
          foreach (Item it in _ListaItems)
          {
              if (it.Codigo == prod.Codigo)
              {
                  it.Cantidad = it.Cantidad + cant;
                  modificado = true;
              }
          }
          return modificado;
      }
      public void eliminar_item(Producto prod)
      {
          bool Encontrado = false;
          int x = 0;
          while ((x < _ListaItems.Count) && (!Encontrado))
          {
              Item aux = (Item)_ListaItems[x];
              if (aux.Codigo == prod.Codigo)
              {
                  _ListaItems.RemoveAt(x);
              }
              x++;
          }
      }
      public void VaciarCarrito()
      {
          _ListaItems.Clear();
      }

 
    }
}
