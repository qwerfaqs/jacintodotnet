using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using BO;

namespace DAO
{
    public sealed class CategoriaDAO
    {
        private  ArrayList ListaCategorias = new ArrayList();
        private static readonly CategoriaDAO _instancia = new CategoriaDAO();
        public static CategoriaDAO Instancia()
        {
            return _instancia;
        }
        public void agregar_categoria(Categoria cat)
        {
            ListaCategorias.Add(cat);
        }
        public ArrayList leer_categorias(bool Siempretrue)
        {
            if (Siempretrue)
            {
                return ListaCategorias;
            }
            else
                return null;
        }     
        public void EliminarCategoriaId(int IdCategoria)
        {
            foreach (Categoria c in ListaCategorias)
            {
                if (c.Codigo == IdCategoria)
                {
                    ListaCategorias.Remove(c);
                    break;
                }
            }
        }
        public void ModificarCategoria(int codigo, string nombre)
        {
            foreach (Categoria c in ListaCategorias)
            {
                if (c.Codigo == codigo)
                {
                    c.Nombre = nombre;
                    break;
                }
            }
        }
        public Categoria UnObjetoCategoria(int i)
        {
            Categoria Nueva=new Categoria();
            foreach (Categoria c in ListaCategorias)
            {
                if (c.Codigo == i)
                {
                    Nueva.Codigo = c.Codigo;

                    Nueva.Nombre = c.Nombre;
                    break;
                }
            }
            return Nueva;
        }
    }
}

