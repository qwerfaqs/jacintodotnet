using System;
using System.Collections;//.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BO;
namespace UI
{
    public partial class AdministracionABMProductos : Form
    {
        Control.ControlProductos CP = new Control.ControlProductos();
        Control.ControlCategorias CC = new Control.ControlCategorias();
        private ArrayList ListaCategorias;
        int x;//producto seleccionado
        Session session = null;

        BindingSource BS = new BindingSource();

        public AdministracionABMProductos(Session session)
        {
            InitializeComponent();
            if (session.Loged == true)
            {
                this.session = session;
                this.Text = "Bienvenido, " + this.session.username+"  -  ADMINISTRACION DE PRODUCTOS";
            }
            else
            {
                throw new Exception("SESSION NO VALIDA");
            }

        }

        
        private void RecargarGrilla(int Categoria)
        {
            try
            {
                BS.ResetBindings(false);
                BS.DataSource = CP.CargarProductos(Categoria);
                dataGridView1.DataSource = BS;

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    
                    dataGridView1.Columns["Codigo"].Width = 50;
                    dataGridView1.Columns["Cat"].Width = 180;
                    dataGridView1.Columns["Cat"].HeaderText = "Categoria";
                    dataGridView1.Columns["Cat"].Visible = true;
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
            
            this.ListaCategorias = CC.CargarCategorias(true);
            //this.ListaCategorias.Add("Todas");
            cmb_categorias.DataSource = this.ListaCategorias;
            
            cmb_categorias.Text = "Seleccione Categoria";
            RecargarGrilla(-1);
        }

                
        private void cmb_categorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            x = -1;
            
                Categoria c = (Categoria)this.ListaCategorias[cmb_categorias.SelectedIndex];
                RecargarGrilla(c.Codigo);
           
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
            //label2.Text = Convert.ToString(x);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdministracionProductos agregarProd = new AdministracionProductos(this.session);
            agregarProd.ShowDialog();
            if (agregarProd.DialogResult == DialogResult.OK)
                {
                    RecargarGrilla(cmb_categorias.SelectedIndex);
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdministracionProductos adm = new AdministracionProductos(dataGridView1.CurrentRow,this.session);
            adm.ShowDialog();
            if (adm.DialogResult == DialogResult.OK)
            {
                RecargarGrilla(cmb_categorias.SelectedIndex);
            }
        }

        private void AdministracionABMProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.ListaCategorias.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)//tildo
            {
                RecargarGrilla(-1);
                cmb_categorias.Enabled = false;
            }
            else//destildo
            {
                cmb_categorias.Enabled = true;
                cmb_categorias.Text = "Seleccione una Categoria";
                RecargarGrilla(-1);
            }            
        }
    }
}