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

      public double Subtotal
        {
            get
            {
                double sub = 0;
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
            if (cant > prod.StockActual)
            {
                throw new Exception("STOCK");
            }
            bool _existia = false;
            foreach (Item it in _ListaItems)
            {
                if (it.Codigo == prod.Codigo)
                {
                    if ((cant+it.Cantidad) <= prod.StockActual)
                    {
                        it.Cantidad = it.Cantidad + cant;
                    }
                    else
                    {
                        throw new Exception("STOCK");
                    }
                    _existia = true;
                }
            }
            if (_existia == false)
            {
                
                Item i = new Item(prod, cant);
                _ListaItems.Add(i);
               
            }
        }



      public void modificar_item(Producto prod, int cant)
      {

          try
          {
              modificaCantidad(prod, cant);
          }
          catch (Exception ex)
          {
              throw new Exception(ex.Message, ex);
          }
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
      /// <summary>
      /// Busca un PRoducto en el carrito
      /// </summary>
      /// <param name="Prod"></param>
      /// <returns> un valor boleano si encontro o no</returns>
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
      
      private void modificaCantidad(Producto prod, int cant)
      {
          if (cant > prod.StockActual)
          {
              throw new Exception("STOCK");
          }
          
          bool modificado = false;
                   
          foreach (Item it in _ListaItems)
          {
              if (it.Codigo == prod.Codigo)
              {            
                  it.Cantidad = cant;
                  modificado = true;
              }
          }
          if (modificado == false)
          {
              throw new Exception("ERROR NO EXISTE EL ITEM A MODIFICAR");
          }
      }
      public void eliminar_item(Producto prod)
      {
          bool _existia = false;
          foreach (Item it in _ListaItems)
          {
              if (it.Codigo == prod.Codigo)
              {
                  _ListaItems.Remove(it);
                  _existia = true;
                  break;
              }
          }
          if (_existia == false)
          {
              //manejo de error no existia
          }
      }
      public void VaciarCarrito()
      {
          _ListaItems.Clear();
      }
      /// <summary>
      /// Esta Funcion Lee la Lista Del carrito y la retorna
      /// </summary>
      /// <returns>Lista de Items</returns>
      public ArrayList DameFuego()
      {
          return this._ListaItems;
      }
 
    }
}
