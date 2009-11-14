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
        private OrdenCompraDAO()
        { 
        }
        public static OrdenCompraDAO Instancia()
        {
            return _instancia;
        }
        static private ArrayList ListaOrdenes = new ArrayList (); 

        public  void grabarCompra(OrdenCompra UnaOrden)
        {   
            int Numerito=0;
            foreach (OrdenCompra OC in ListaOrdenes)
            {
                if (OC.Numero < Numerito)
                {
                    Numerito = OC.Numero;
                }
            }
            UnaOrden.Numero = Numerito - 1;
            ListaOrdenes.Add(UnaOrden);
        }
        
        public  ArrayList LeerOrdenes(string Estado)
        {   

            ArrayList Lista=new ArrayList();
            foreach (OrdenCompra oc in ListaOrdenes)
            { 
                if(oc.Estado==Estado)
                {
                    Lista.Add(oc);
                }
            }
            return Lista;
        }

        public ArrayList LeerOrdenes()
        {
            return ListaOrdenes;
        }

        public void CambiarEstadoOrden(OrdenCompra OrdenModificada)
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
