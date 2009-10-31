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
    public partial class AdministracionProductos : Form
    {
        BindingSource BS = new BindingSource();
        Control.ControlCategorias CC = new Control.ControlCategorias();
        
        
        DataGridViewRow prodamodif;
        public AdministracionProductos()
        {
            InitializeComponent();
            BS.DataSource = CC.CargarCategorias();
            cmbCategorias.DataSource = BS;
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            
            pictureBox1.Image = Image.FromFile(path +"\\Imagenes\\ImagenNodisponible.jpg");
            
        }
        public AdministracionProductos(DataGridViewRow prodamodif): this()
        {

            
            this.prodamodif = prodamodif;
            txtCodigo.Text = prodamodif.Cells["Codigo"].Value.ToString();
            txtNombre.Text = prodamodif.Cells["Nombre"].Value.ToString();
            txtPrecio.Text = prodamodif.Cells["Precio"].Value.ToString();
            cmbCategorias.SelectedText = prodamodif.Cells["Cat"].Value.ToString();
            txtStock.Text = prodamodif.Cells["StockActual"].Value.ToString();
            txtPrecioOferta.Text = prodamodif.Cells["PrecioOferta"].Value.ToString();
            txtStockComprometido.Text = prodamodif.Cells["StockComprometido"].Value.ToString();
            pictureBox1.Image = (System.Drawing.Image) prodamodif.Cells["FotoPath"].Value;
            btnGuardar.Visible = false;
            button1.Visible = true;
            txtCodigo.Enabled = false;

            
        }

        private void AdministracionProductos_Load(object sender, EventArgs e)
        {
            
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Nuevo Producto - Imagen";
            openFileDialog1.Filter = "Imagenes | *.png; *.jpg";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Control.ControlProductos CP = new Control.ControlProductos();
                Control.ControlCategorias CC = new Control.ControlCategorias();
                ArrayList AL = CC.CargarCategorias();
                Categoria C = (Categoria)AL[cmbCategorias.SelectedIndex];

                CP.AgregarProducto(C, txtCodigo.Text, pictureBox1.Image, txtNombre.Text, txtPrecio.Text, txtPrecioOferta.Text, txtStock.Text, txtStockComprometido.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Control.ControlProductos CP = new Control.ControlProductos();
                CP.ModificarProducto((cmbCategorias.SelectedIndex +1), txtCodigo.Text, pictureBox1.Image, txtNombre.Text, txtPrecio.Text, txtPrecioOferta.Text, txtStock.Text, txtStockComprometido.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        

        
        
    }
}