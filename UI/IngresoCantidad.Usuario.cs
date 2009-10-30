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
        public IngresoCantidad()
        {
            InitializeComponent();
        }
        public int Cantidad;

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
    }
}