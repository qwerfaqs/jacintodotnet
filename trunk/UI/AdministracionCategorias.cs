using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Control;
using System.Collections;

namespace UI
{
    public partial class AdministracionCategorias : Form
    {
        Control.ControlCategorias ControlCategorias = new ControlCategorias();
        Control.ControlProductos ControlProductos = new ControlProductos();

        public AdministracionCategorias()
        {
            InitializeComponent();
        }

        private void btn_carga_Click(object sender, EventArgs e)
        {
            try
            {
                bool r = ControlCategorias.InsertarCategoria(txt_carga_nombre.Text, txt_carga_id.Text);
                ActualizarLista();
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
            ActualizarLista();
        }
        private void ActualizarLista()
        {
            listBox_listado.Items.Clear();
            foreach (string s in ControlCategorias.CargarCategorias())
            {
                listBox_listado.Items.Add(s);
            }
        }

        private void listBox_listado_SelectedValueChanged(object sender, EventArgs e)
        {
            label_nombre.Text=ControlCategorias.NombreCategoria(listBox_listado.SelectedIndex);
            label_id.Text = ControlCategorias.IdCategoria(listBox_listado.SelectedIndex);
            txt_modif_id.Text = ControlCategorias.IdCategoria(listBox_listado.SelectedIndex);
            txt_modif_nombre.Text = ControlCategorias.NombreCategoria(listBox_listado.SelectedIndex);
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (ControlProductos.ExistenProductosConEstaCategoria(Convert.ToInt32(ControlCategorias.IdCategoria(listBox_listado.SelectedIndex))))
            {
                MessageBox.Show("Antes de Borrar la Categoria asegurese de borrar los productos de dicha categoria", "Atencion!");
            }
            else
            {
                ControlCategorias.EliminarCategoria(listBox_listado.SelectedIndex);
                this.ActualizarLista();
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlCategorias.ModificarCategoria(listBox_listado.SelectedIndex, txt_modif_nombre.Text);
                ActualizarLista();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        

    }
}