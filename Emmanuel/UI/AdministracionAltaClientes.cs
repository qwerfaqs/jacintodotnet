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
    public partial class AdministracionAltaClientes : Form
    {
        Control.ControlUsuarios CU = new Control.ControlUsuarios();
        Control.ControlCiudades CC = new Control.ControlCiudades();

        ArrayList Provincias = new ArrayList();
        ArrayList Ciudades = new ArrayList();
        ArrayList Ciudadesb = new ArrayList();
        public AdministracionAltaClientes()
        {
            InitializeComponent();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {

                CU.AgregarNuevoUsuario(txtNombres.Text, txtApellido.Text, txtEmail.Text, txtUser.Text, txtPass.Text, txtCalle.Text + " " + txtNumero.Text + " " + txtPisoDpto.Text + " " + txtmasDatos.Text, 0, 1,(int)cmbCiudad.SelectedValue);
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

        private void AdministracionAltaClientes_Load(object sender, EventArgs e)
        {
            Provincias = CC.CargarProvincias();
            cmbProvincia.DataSource = Provincias;
            cmbProvincia.DisplayMember = "Nombre";
            cmbProvincia.ValueMember = "Id";         
        }

        private void cmbProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Ciudades = CC.CargarCiudadesporProvincia((int)cmbProvincia.SelectedValue);
            cmbCiudad.DataSource = Ciudades;
            cmbCiudad.DisplayMember = "Nombre";
            cmbCiudad.ValueMember = "id";
        }

        private void cmbCiudad_TextChanged(object sender, EventArgs e)
        {
            cmbCiudad.FindString(cmbCiudad.Text);
        }

        private void cmbCiudad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((int)cmbCiudad.SelectedValue > 0)
            {
                Departamento d = CC.CargarDepartamentoporCiudad((int)cmbCiudad.SelectedValue);
                txtDepartamento.Text = d.Nombre;
            }
        }
    }
}