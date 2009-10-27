using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using BO;
using DAO;

namespace Control
{
    public class ControlCategorias
    {
        public ControlCategorias()
        {
            this.miDao = DAO.CategoriaDAO.Instancia();
        }
        private DAO.CategoriaDAO miDao;
        public bool InsertarCategoria(string nombre, string c)
        {
            bool Exito = false;
            try
            {
                int codigo = Convert.ToInt32(c);
                if (nombre != "" && c != "" && (CodigoRepetido(codigo) == false) && (NombreRepetido(nombre) == false))
                {
                    this.miDao.agregar_categoria(new Categoria(codigo, nombre));
                    Exito = true;
                }
            }
            catch
            {
                throw new ArgumentException("Error Insertando Categoria");
            }
            return Exito;
        }

        public bool CodigoRepetido(int codigo)
        {
            bool Repetido = false;
            foreach (Categoria c in this.miDao.leer_categorias())
            {
                if (c.Codigo == codigo)
                {
                    Repetido = true;
                    break;
                }            
            }
            return Repetido;
        }
        public bool NombreRepetido(string nombre)
        {
            bool Repetido = false;
            foreach (Categoria c in this.miDao.leer_categorias())
            {
                if (c.Nombre == nombre)
                {
                    Repetido = true;
                    break;
                }
            }
            return Repetido;
        }

        public ArrayList CargarCategorias()
        {
            ArrayList Categorias=new ArrayList();

            foreach (Categoria c in this.miDao.leer_categorias())
            {
                Categorias.Add(c.Codigo + "    " + c.Nombre);
            }
            return Categorias;
        }
        public string NombreCategoria(int i)
        {
            return this.miDao.NombreCategoria(i);            
        }

        public string NombreCategoriaporId(int i)
        {
            return this.miDao.NombreCategoriaPorId(i);
        }

        public string IdCategoria(int i)
        {
            Categoria c;
            c = (Categoria)this.miDao.leer_categorias()[i];
            return Convert.ToString(c.Codigo);
        }
        public void EliminarCategoria(int i)
        {
            this.miDao.EliminarCategoria(i);
        }
        public void ModificarCategoria(int indice,string nombre)
        {
            try
            {
                int i = this.miDao.CodigoCategoria(indice);
                this.miDao.ModificarCategoria(i, nombre);
            }
            catch
            {
                throw new Exception("Error Modificando Categoria");
            }
        }
    }
}
