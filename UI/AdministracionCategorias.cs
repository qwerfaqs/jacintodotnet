using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Control;
using System.Collections;
using BO;
namespace UI
{
    public partial class AdministracionCategorias : Form
    {
        Control.ControlCategorias ControlCategorias = new ControlCategorias();
        Control.ControlProductos ControlProductos = new ControlProductos();
        private ArrayList ListaCategorias;
        Categoria c;
        public AdministracionCategorias()
        {
            InitializeComponent();
        }

        private void btn_carga_Click(object sender, EventArgs e)
        {
            try
            {
                bool r = ControlCategorias.InsertarCategoria(txt_carga_nombre.Text, txt_carga_id.Text);
                ActualizarLista(false);
                txt_carga_id.Clear();
                txt_carga_nombre.Clear();
                if (r == false)
                    MessageBox.Show("Verifique codigo y Nombre de la Categoria a Insertar");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            ActualizarLista(false);
        }
        private void ActualizarLista(bool Desdememoria)
        {
            listBox_listado.Items.Clear();
            
            this.ListaCategorias=ControlCategorias.CargarCategorias(Desdememoria);
            foreach (Categoria c in this.ListaCategorias) 
            {
                listBox_listado.Items.Add(Convert.ToString(c.Codigo)+" "+c.Nombre);
            }
        }

        private void listBox_listado_SelectedValueChanged(object sender, EventArgs e)
        {
            c = (Categoria)ListaCategorias[listBox_listado.SelectedIndex];
            label_nombre.Text = c.Nombre;
            label_id.Text = c.Codigo.ToString();
            txt_modif_id.Text = c.Codigo.ToString();
            txt_modif_nombre.Text = c.Nombre;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria c = (Categoria)this.ListaCategorias[listBox_listado.SelectedIndex];
                if (ControlProductos.ExistenProductosConEstaCategoria(c.Codigo))
                {
                    MessageBox.Show("Antes de Borrar la Categoria asegurese de borrar los productos de dicha categoria", "Atencion!");
                }
                else
                {

                    ControlCategorias.EliminarCategoria(c.Codigo);
                    this.ActualizarLista(false);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlCategorias.ModificarCategoria(c.Codigo, txt_modif_nombre.Text);
                ActualizarLista(false);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}