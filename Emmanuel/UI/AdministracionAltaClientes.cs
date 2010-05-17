using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class AdministracionAltaClientes : Form
    {
        Control.ControlUsuarios CU = new Control.ControlUsuarios();
        public AdministracionAltaClientes()
        {
            InitializeComponent();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {

                CU.AgregarNuevoUsuario(txtNombres.Text, txtApellido.Text, txtEmail.Text, txtPass.Text, txtPass.Text, txtDireccion.Text, 0, 1);
                MessageBox.Show("Usuario Agregado con exito");
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}