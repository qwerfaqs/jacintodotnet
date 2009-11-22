using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class IngresoCantidad : Form
    {
        public int Cantidad;
        public string Nombre;
        public IngresoCantidad()
        {
            InitializeComponent();
            button1.Visible = true;
            btn_modificar.Visible = false;
        }
        public IngresoCantidad(int cant, string nombre)
            : this()
        {
            Nombre = nombre;
            this.textBox1.Text = cant.ToString();
            button1.Visible = false;
            btn_modificar.Visible = true;
            this.Text = "MODIFICAR CANTIDAD DE ITEMS";
            this.AcceptButton = btn_modificar;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cantidad = Convert.ToInt16(this.textBox1.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            this.Cantidad = Convert.ToInt16(this.textBox1.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void IngresoCantidad_Load(object sender, EventArgs e)
        {
            label3.Text = Nombre;
        }
    }
}