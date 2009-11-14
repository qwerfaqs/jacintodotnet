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
    public partial class AdministracionOrdenesdeCompraDetalles : Form
    {
        Session Session;
        public AdministracionOrdenesdeCompraDetalles(Session oSession)
        {
            if (oSession.Loged == true)
            {
                this.Session = oSession;
                this.Text =Session.username + " - Detalles Orden de Compra";
            }
            else
            {
                throw new ArgumentException("Sesion no valida");
            }

            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AdministracionOrdenesdeCompraDetalles_Load(object sender, EventArgs e)
        {

        }
    }
}