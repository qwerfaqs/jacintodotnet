using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using BO;

namespace DAO
{
    public sealed class OrdenCompraDAO
    {
        private static readonly OrdenCompraDAO _instancia = new OrdenCompraDAO();
        public static OrdenCompraDAO Instancia()
        {
            return _instancia;
        }
        static private ArrayList ListaOrdenes = new ArrayList (); 

        public static void grabarCompra(OrdenCompra UnaOrden)
        {
            ListaOrdenes.Add(UnaOrden);
        }
        
        public static ArrayList LeerOrdenes()
        { 
         return(ListaOrdenes);
        }
        
        public static void CambiarEstadoOrden(OrdenCompra OrdenModificada)
        { 
            int Encontrado = 0;
            int x = 0;
            while ((x < ListaOrdenes.Count) && (Encontrado == 0))
            {
                OrdenCompra aux = (OrdenCompra)ListaOrdenes[x];
                if (aux.Numero == OrdenModificada.Numero)
                {
                    aux = OrdenModificada;
                    Encontrado = 1;
                }
                x++;
             }          
        }
    }
}
