using System;
using System.Collections;//.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class AdministracionABMProductos : Form
    {
        Control.ControlProductos CP = new Control.ControlProductos();
        Control.ControlCategorias CC = new Control.ControlCategorias();
        ArrayList Categorias;
        int x;//producto seleccionado
        

        BindingSource BS = new BindingSource();

        public AdministracionABMProductos()
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


        private void AdministracionABMProductos_Load(object sender, EventArgs e)
        {
            Categorias = CC.CargarCategorias();
            Categorias.Add("Todas");
            cmb_categorias.DataSource = Categorias;
            cmb_categorias.Text = "Todas";
            RecargarGrilla(-1);
        }

                
        private void cmb_categorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            x = -1;
            RecargarGrilla(cmb_categorias.SelectedIndex);            
        }



        

        private void button3_Click(object sender, EventArgs e)
        {
            if (x > -1)
            {
                if (MessageBox.Show("Esta seguro de borrar el producto " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "?", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        CP.BorrarProducto(x);
                        RecargarGrilla(cmb_categorias.SelectedIndex);
                        x = -1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
                MessageBox.Show("Seleccione un producto de la lista");
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            x = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            label2.Text = Convert.ToString(x);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdministracionProductos agregarProd = new AdministracionProductos();
            agregarProd.ShowDialog();
            if (agregarProd.DialogResult == DialogResult.OK)
                {
                    RecargarGrilla(cmb_categorias.SelectedIndex);
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdministracionProductos adm = new AdministracionProductos(dataGridView1.CurrentRow);
            adm.ShowDialog();
            if (adm.DialogResult == DialogResult.OK)
            {
                RecargarGrilla(cmb_categorias.SelectedIndex);
            }
        }

       

        
    }
}