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
        public CarritoMostrable ass;

        
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
                    sub = sub +( i.Cantidad * i.UnProducto.Precio);
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
            
            //busca item en el carrito
            //sino lo agrega al arraylist
            if (buscarProducto(prod))
            {
                // modifica cantidad del item en el carrito
                modificaCantidad(prod, cant);
            }
            else
            {
                //agrega el Item al carrito
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
                Encontrado = (i.UnProducto.Codigo == Prod.Codigo);
                x++;
            }
            return Encontrado;
        }
      
      private bool modificaCantidad(Producto prod, int cant)
      {
          bool modificado = false;
          int x = 0;
          while ((x < _ListaItems.Count) && (!modificado))
          {
              Item i = (Item)_ListaItems[x];
              if (i.UnProducto.Codigo == prod.Codigo)
              {
                  i.Cantidad = cant;
                  //ModificarStock(prod, cant);
                  //i.UnProducto.StockActual = cant;
                  modificado = true;
              }
              x++;
          }
          return modificado;
      }
      public CarritoMostrable ToMostrable()
      {
          return new CarritoMostrable(this);
      }
      public void eliminar_item(Producto prod)
      {
          bool Encontrado = false;
          int x = 0;
          while ((x < _ListaItems.Count) && (!Encontrado))
          {
              Item aux = (Item)_ListaItems[x];
              if (aux.UnProducto.Codigo == prod.Codigo)
              {
                  _ListaItems.RemoveAt(x);
              }
              x++;
          }
      }

 
    }
    public struct CarritoMostrable
    {
        public ArrayList _listaItems; 
        public CarritoMostrable(Carrito car)
        {
            _listaItems = new ArrayList();
            foreach(Item it in car.ver_lista())
            {
                _listaItems.Add(new ItemMostrable(it));
            }
        }
    }
}
