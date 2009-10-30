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
        public ArrayList leer_categorias()
        {
            return ListaCategorias;
        }     
        public void EliminarCategoria(int i)
        {
            ListaCategorias.RemoveAt(i);          
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
        public int CodigoCategoria(int indice)
        {
            Categoria c = (Categoria)ListaCategorias[indice];
            return c.Codigo;
        }
        public string NombreCategoria(int indice)
        {
            Categoria c = (Categoria)ListaCategorias[indice];
            return c.Nombre;
        }
        public int IdCategoria(int indice)
        {
            Categoria c = (Categoria)ListaCategorias[indice];
            return c.Codigo;
        }
        public string NombreCategoriaPorId(int Id)
        {
            string Cat="";
            foreach (Categoria cat in ListaCategorias)
            {
                if (cat.Codigo == Id)
                {
                    Cat = cat.Nombre;    
                    break;
                }
            }
            return Cat;
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
        public Categoria ObjetoCategoria(int i)
        {
            Categoria Nueva=new Categoria(0,"v");
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

