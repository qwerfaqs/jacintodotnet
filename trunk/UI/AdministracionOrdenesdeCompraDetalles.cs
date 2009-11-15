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
        OrdenCompra CurrentOrder;
        Session Session;
        int Codigo;
        Control.ControlOrdenCompra COC = new Control.ControlOrdenCompra();

        public AdministracionOrdenesdeCompraDetalles(Session oSession, int oCodigo)
        {
            if (oSession.Loged == true)
            {
                this.Session = oSession;
                this.Codigo = oCodigo;
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

        private void CargarGrilla()
        {
            dgvItems.DataSource = CurrentOrder.Items;
        }

        private void CargarDatosOrden()
        {
            lblNombre.Text = CurrentOrder.Cliente.ToString();
            lblNombre.ForeColor = Color.Blue;
            lblDomicilio.Text = CurrentOrder.Cliente.Domicilio;
            lblEstado.Text = CurrentOrder.Estado;
            lblId.Text = CurrentOrder.Numero.ToString();
            lblMail.Text = CurrentOrder.Cliente.Email;
            lblUser.Text = CurrentOrder.Cliente.NickName;
            lblTotal.Text = COC.TotalUnaOrden(CurrentOrder).ToString();
            if (CurrentOrder.Estado == "PENDIENTE")
            {
                lblEstado.ForeColor = Color.Red;
                btnConfirmar.Enabled = true;
            }
            else
            {
                lblEstado.ForeColor = Color.Green;
                btnConfirmar.Enabled = false;
            }
        }

        private void AdministracionOrdenesdeCompraDetalles_Load(object sender, EventArgs e)
        {
            CurrentOrder = COC.LeerUnaOrden(this.Codigo);
            CargarDatosOrden();
            CargarGrilla();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            CurrentOrder.Estado = "CONFIRMADO";
            COC.ModificarUnaOrden(CurrentOrder);
            CargarDatosOrden();
        }
    }
}