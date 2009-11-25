using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BO;

namespace UI
{
    public partial class Principal___Usuario : Form
    {
        Control.ControlProductos CP = new Control.ControlProductos();
        Control.ControlCategorias CC = new Control.ControlCategorias();
        Control.ControlCarritos Carromato = new Control.ControlCarritos();
        Control.ControlOrdenCompra COC = new Control.ControlOrdenCompra();
        ArrayList Categorias;
        int x;//producto seleccionado
        Session session = null;


        BindingSource BS = new BindingSource();
        BindingSource BScarrito = new BindingSource();

        public Principal___Usuario(Session session)
        {
            InitializeComponent();
            if (session.Loged == true)
            {
                this.session = session;
                this.Text = "Bienvenido, " + this.session.username;
            }
            else
            {
                throw new Exception("SESSION NO VALIDA");
            }

            //int x;//producto seleccionado


            BindingSource BS = new BindingSource();
            BindingSource BScarrito = new BindingSource();
        }

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
        private void RecargarCarretilla()
        {
            /*try
            {*/
                //se le carga por un milisegundo la grilla de ´productos para que se actualize (Problema a resolver bien)
                dataGridView2.DataSource = BS;

                //BScarrito.ResetBindings(false);
                ArrayList arreglo = Carromato.CargarCarrito();
                BScarrito.DataSource = arreglo;
                dataGridView2.DataSource = BScarrito;

                if (dataGridView2.Rows.Count > 0)
                {
                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView2.Columns["Codigo"].Width = 50;
                    
                    dataGridView2.Columns["Nombre"].Width = 200;
                    dataGridView2.Columns["Total"].Width = 60;
                    dataGridView2.Columns["Total"].HeaderText = "Subtotal";
                    dataGridView2.Columns["PrecioUnitario"].Width = 60;
                    dataGridView2.Columns["PrecioUnitario"].HeaderText = "Precio Unitario";
                    dataGridView2.Columns["Cantidad"].Width = 80;
                    dataGridView2.Columns["Cantidad"].HeaderText = "Cantidad";
                    //dataGridView2.Columns["FotoPath"].Width = 135;
                    //dataGridView2.Columns["FotoPath"].HeaderText = "Imagen";



                }
                string x = Carromato.DameTotal();
                label1.Text = x;
            /*}
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }*/
        }
        

        private void Principal___Usuario_Load(object sender, EventArgs e)
        {
            Categorias = CC.CargarCategorias(false);
            //Categorias.Add("Todas");
            cmb_categorias.DataSource = Categorias;
            //cmb_categorias.Text = "Todas";
            RecargarGrilla(-1);
            RecargarCarretilla();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            x = -1;
            Categoria cat = (Categoria)CC.CargarCategorias(true)[cmb_categorias.SelectedIndex];
            RecargarGrilla(cat.Codigo);  
        }

        private void dataGridView2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))

                e.Effect = DragDropEffects.Copy;

            else

                e.Effect = DragDropEffects.None;

        }
        /// <summary>
        /// Trata el evento mousedown para el drag and drop,
        /// envia el Codigo de la fila, sobre la que se presiono el mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            dataGridView1.Update();
            if (dataGridView1.Rows.Count > 0)
            {
                DataGridView.HitTestInfo info;
                info = dataGridView1.HitTest(e.X, e.Y);
                DoDragDrop(dataGridView1.Rows[info.RowIndex].Cells["Codigo"].Value.ToString(), DragDropEffects.Copy);
            }          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            x = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Codigo"].Value);
        }
        private void AgregarACarrito(int codigo, int cant)
        {
            //llamada al control del carrito
            //MessageBox.Show("Ingresastes" + cant.ToString() + " Articulos del Producto con Codigo: " + codigo.ToString());
            try
            {
                Carromato.AgregarItem(codigo, cant);
            }
            catch (Exception ex)
            {
                if (ex.Message == "STOCK")
                {
                    MessageBox.Show("NO HAY STOCK DISPONIBLE");
                }
            }
            RecargarCarretilla();
        }
        private void dataGridView2_DragDrop(object sender, DragEventArgs e)
        {
            int codigo = int.Parse(e.Data.GetData(DataFormats.Text).ToString());


            IngresoCantidad form_cantidad = new IngresoCantidad(1,dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString());
            form_cantidad.ShowDialog();
            if (form_cantidad.DialogResult == DialogResult.OK)
            {
                this.AgregarACarrito(codigo, form_cantidad.Cantidad);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            BScarrito.ResetBindings(false);
            ArrayList arreglo = Carromato.CargarCarrito();
            BScarrito.DataSource = arreglo;
            dataGridView2.DataSource = BScarrito;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BS.ResetBindings(false);
            BS.DataSource = CP.CargarProductos(cmb_categorias.SelectedIndex);
            dataGridView2.DataSource = BS;
        }

        private void btn_EliminarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(dataGridView2.CurrentRow.Cells["Codigo"].Value.ToString());
                Carromato.EliminarItem(codigo);
                RecargarCarretilla();
            }
            catch(Exception exepcion)
            {
                MessageBox.Show("Error al Eliminar un Item : "+exepcion.Message);
            }
        }

        private void bt_modificarItem_Click(object sender, EventArgs e)
        {
            try
            {

                int codigo = int.Parse(dataGridView2.CurrentRow.Cells["Codigo"].Value.ToString());
                int cantidad = int.Parse(dataGridView2.CurrentRow.Cells["Cantidad"].Value.ToString());
                IngresoCantidad form_cantidad = new IngresoCantidad(cantidad, dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString());
                form_cantidad.ShowDialog();

                    if (form_cantidad.DialogResult == DialogResult.OK)
                    {
                        try
                        {
                            Carromato.ModificarItem(codigo, form_cantidad.Cantidad);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message == "STOCK")
                            {
                                MessageBox.Show("NO HAY STOCK DISPONIBLE");
                            }
                            else
                            {
                                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
                            }
                        }
                        RecargarCarretilla();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

        }

        private void btn_vaciarCarrito_Click(object sender, EventArgs e)
        {
            Carromato.VaciarCarrito();
            RecargarCarretilla();
        }
        /// <summary>
        /// Tiene que generar la Orden y Mandarle El Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_generarorden_Click(object sender, EventArgs e)
        {
            try
            {
                Carromato.GenerarOrden(this.session);
                MessageBox.Show("Orden de compra generada con exito", "Orden de compra");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                RecargarGrilla(-1);
                cmb_categorias.Enabled = false; 
                cmb_categorias.Text = "Seleccione Categoria";
            }
            else
            {
                cmb_categorias.Enabled = true; 
                cmb_categorias.Text = "Seleccione Categoria";
                RecargarGrilla(-1);
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //es una prueba para hacer un mejor drag and drop
           //dataGridView1.
        }

    }
}