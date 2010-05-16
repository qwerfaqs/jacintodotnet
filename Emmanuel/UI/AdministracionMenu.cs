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
    public partial class AdministracionMenu : Form
    {

        Session session = null;
        public AdministracionMenu()
        {
            InitializeComponent();
        }

        public AdministracionMenu(Session session)
        {
            InitializeComponent();
            if (session.Loged == true)
            {
                this.session = session;
                this.Text = "Bienvenido, " + this.session.username+"  -  ADMINISTRACION DE CATEGORIAS";
            }
            else
            {
                throw new Exception("SESION NO VALIDA");
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            AdministracionABMProductos AABMP = new AdministracionABMProductos(this.session);
            AABMP.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdministracionCategorias AC = new AdministracionCategorias(this.session);
            AC.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Principal___Usuario PU = new Principal___Usuario();
            PU.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdministracionOrdenesdeCompra AOC = new AdministracionOrdenesdeCompra(this.session);
            AOC.Show();
        }

        private void AdministracionMenu_Load(object sender, EventArgs e)
        {

        }
    }
}