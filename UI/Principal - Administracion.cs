using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class Principal___Administracion : Form
    {
        public Principal___Administracion()
        {
            InitializeComponent();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            AdministracionCategorias AC = new AdministracionCategorias();
            AC.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AdministracionABMProductos AP = new AdministracionABMProductos();
            AP.Show();
        }

        
    }
}