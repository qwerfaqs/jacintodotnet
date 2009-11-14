using System;
using System.Collections;//.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class AdministracionOrdenesdeCompra : Form
    {
        //private ArrayList OrdenesdeCompra;
        Control.ControlOrdenCompra COC = new Control.ControlOrdenCompra();
        
        

        public AdministracionOrdenesdeCompra()
        {
            InitializeComponent();
        }

        private void ActualizarGrilla(String Pendiente)
        {
            dgvOrdenes.Rows.Clear();
            dgvOrdenes.DataSource = COC.LeerOdenesdeCompra(Pendiente); 
        }
        private void ActualizarGrilla()
        {
            dgvOrdenes.Rows.Clear();
            dgvOrdenes.DataSource = COC.LeerOdenesdeCompra();
        }

        private void AdministracionOrdenesdeCompra_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
           
        }

        private void chkPendientes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPendientes.Checked)
            {
                ActualizarGrilla("PENDIENTE");
            }
            else
            {
                ActualizarGrilla();
            }
        }
    }
}