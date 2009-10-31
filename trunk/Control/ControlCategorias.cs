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
        private DAO.CategoriaDAO miDao;
        private DAOSQL.DAOSQLCategorias MiDAOSQL;

        public ControlCategorias()
        {
            this.miDao = DAO.CategoriaDAO.Instancia();
            this.MiDAOSQL = new DAOSQL.DAOSQLCategorias();
        }
        
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
            ArrayList Categorias = miDao.leer_categorias();
            return Categorias;
        }
        
        public void EliminarCategoria(int Id)
        {
           miDao.EliminarCategoriaId(Id);
           //MiDAOSQL.EliminarCategoriaId(Id);
        }
        
        public void ModificarCategoria(int Id,string nombre)
        {
            miDao.ModificarCategoria(Id, nombre);
        }
    }
}
