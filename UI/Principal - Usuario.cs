using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class Principal___Usuario : Form
    {
        Control.ControlProductos CP = new Control.ControlProductos();
        Control.ControlCategorias CC = new Control.ControlCategorias();
        ArrayList Categorias;
        int x;//producto seleccionado


        BindingSource BS = new BindingSource();

        public Principal___Usuario()
        {
            InitializeComponent();
        }
        private void RecargarGrilla(int categoria)
        {
            try
            {
                BS.ResetBindings(false);
                BS.DataSource = CP.CargarProductos(categoria);
                dataGridView1.DataSource = BS;

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView1.Columns["Codigo"].Width = 50;
                    dataGridView1.Columns["Cat"].Width = 80;
                    dataGridView1.Columns["Cat"].HeaderText = "Categoria";
                    dataGridView1.Columns["StockActual"].Width = 70;
                    dataGridView1.Columns["StockActual"].HeaderText = "Stock Actual";
                    dataGridView1.Columns["Nombre"].Width = 200;
                    dataGridView1.Columns["PrecioOferta"].Width = 60;
                    dataGridView1.Columns["PrecioOferta"].HeaderText = "Precio de Oferta";
                    dataGridView1.Columns["Precio"].Width = 60;
                    dataGridView1.Columns["StockComprometido"].Width = 80;
                    dataGridView1.Columns["StockComprometido"].HeaderText = "Stock Comprometido";
                    dataGridView1.Columns["FotoPath"].Width = 135;
                    dataGridView1.Columns["FotoPath"].HeaderText = "Imagen";



                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Principal___Usuario_Load(object sender, EventArgs e)
        {
            Categorias = CC.CargarCategorias();
            Categorias.Add("Todas");
            cmb_categorias.DataSource = Categorias;
            cmb_categorias.Text = "Todas";
            RecargarGrilla(-1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            x = -1;
            RecargarGrilla(cmb_categorias.SelectedIndex);  
        }

        private void dataGridView2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))

                e.Effect = DragDropEffects.Copy;

            else

                e.Effect = DragDropEffects.None;

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            dataGridView1.Update();
            DoDragDrop(this.dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString(), DragDropEffects.Copy);
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            x = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Codigo"].Value);
        }
        private void AgregarACarrito(int codigo, int cant)
        {
            //llamada al control del carrito
            MessageBox.Show("Ingresastes" + cant.ToString() + " Articulos del Producto con Codigo: " + codigo.ToString());
        }
        private void dataGridView2_DragDrop(object sender, DragEventArgs e)
        {
            int codigo = int.Parse(e.Data.GetData(DataFormats.Text).ToString());

           
            IngresoCantidad form_cantidad = new IngresoCantidad();
            form_cantidad.ShowDialog();
            if (form_cantidad.DialogResult == DialogResult.OK)
            {
                this.AgregarACarrito(codigo, form_cantidad.Cantidad);
            }



        }

    }
}