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
    public partial class AdministracionOrdenesdeCompra : Form
    {
        //private ArrayList OrdenesdeCompra;
        BindingSource bs;
        Control.ControlOrdenCompra COC = new Control.ControlOrdenCompra();
        Session Session = null;

        public AdministracionOrdenesdeCompra(Session oSession)
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

        private void ActualizarGrilla(String Pendiente)
        {
            bs.ResetBindings(false);
            bs.DataSource = COC.LeerOdenesdeCompra(Pendiente);
            dgvOrdenes.DataSource = bs;//COC.LeerOdenesdeCompra(Pendiente); 
            
        }
        private void ActualizarGrilla()
        {
            //dgvOrdenes.Rows.Clear();
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

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            AdministracionOrdenesdeCompraDetalles AOCD = new AdministracionOrdenesdeCompraDetalles(this.Session, (int)dgvOrdenes.CurrentRow.Cells["Numero"].Value);
            AOCD.Show();   
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}