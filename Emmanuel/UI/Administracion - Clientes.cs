using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class Administracion___Clientes : Form
    {
        Control.ControlUsuarios CU = new Control.ControlUsuarios();
        int ClienteABorrar;

        public Administracion___Clientes()
        {
            InitializeComponent();
        }

        private void Reload_grilla() 
        {
            dgvUsuarios.DataSource = CU.TodosLosUsuarios();
        }

        private void Administracion___Clientes_Load(object sender, EventArgs e)
        {
            Reload_grilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                CU.EliminarUsuario(ClienteABorrar);
                Reload_grilla();
                MessageBox.Show("Cliente borrado con exito!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClienteABorrar = (int)dgvUsuarios.CurrentRow.Cells["Id"].Value;            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}