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

        public  int grabarCompra(OrdenCompra UnaOrden)
        {   
            int Numerito=0;
            foreach (OrdenCompra OC in ListaOrdenes)
            {
                if (OC.Numero > Numerito)
                {
                    Numerito = OC.Numero;
                }
            }
            UnaOrden.Numero = Numerito + 1;
            ListaOrdenes.Add(UnaOrden);
            return UnaOrden.Numero;
        }

        //public OrdenCompra grabarCompra2(OrdenCompra UnaOrden)//Borrar luego- solo sirve para precarga en arraylist de orden de compra confrimada 
        //{
        //    int Numerito = 0;
        //    foreach (OrdenCompra OC in ListaOrdenes)
        //    {
        //        if (OC.Numero > Numerito)
        //        {
        //            Numerito = OC.Numero;
        //        }
        //    }
        //    UnaOrden.Numero = Numerito + 1;
        //    ListaOrdenes.Add(UnaOrden);
        //    return UnaOrden;
        //}

        public OrdenCompra LeerUnaOrden(int IdOrden)
        {
            OrdenCompra UnaOrden=null;
            foreach (OrdenCompra OC in ListaOrdenes)
            {
                if (OC.Numero == IdOrden)
                {
                    UnaOrden = OC;
                    break;
                }
            }
            return UnaOrden;
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

        public void ModificarOrden(OrdenCompra OrdenModificada)
        {
            foreach (OrdenCompra OC in ListaOrdenes)
            {
                if (OC.Numero == OrdenModificada.Numero)
                {
                    OC.Estado = OrdenModificada.Estado;
                    break;
                }
            }
        }
    }
}
