using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BO;
namespace UI
{
    public partial class Principal___Administracion : Form
    {
        private Session session = null;
        public Principal___Administracion(Session session)
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

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            AdministracionCategorias AC = new AdministracionCategorias(this.session);
            AC.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AdministracionABMProductos AP = new AdministracionABMProductos(this.session);
            AP.Show();
        }

        private void btnOrdenesdeCompra_Click(object sender, EventArgs e)
        {
            AdministracionOrdenesdeCompra AOC = new AdministracionOrdenesdeCompra();
            AOC.Show();
        }

        
    }
}