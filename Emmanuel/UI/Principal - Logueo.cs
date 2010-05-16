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

    public partial class Principal___Logueo : Form
    {
        int x = 0;
        
        public Session session;
        public Principal___Logueo(Session Sesion)
        {
            this.session = Sesion;
            InitializeComponent();
        }

        private void Principal___Logueo_Load(object sender, EventArgs e)
        {
            
            //mtxtPass.UseSystemPasswordChar = false;
            //mtxtPass.Text = "Contraseña";
            //mtxtPass.Focus();
            //txtUser.Text = "Usuario";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Reintentar")
            {
                button1.Text = "Iniciar Sesion";
                panel1.Visible = false;
            }
            else
            {
                try
                {
                    Control.ControlUsuarios CU = new Control.ControlUsuarios();
                    this.session = CU.LogIn(txtUser.Text, mtxtPass.Text);
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                catch (Exception ex)
                {
                    panel1.Visible = true;
                    label2.Text = ex.Message;
                    label3.Text = ex.InnerException.Message;
                    button1.Text = "Reintentar";
                }
            }        
        }

        private void mtxtPass_Enter(object sender, EventArgs e)
        {
            mtxtPass.Text = "";
            mtxtPass.UseSystemPasswordChar = true;
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario" ||txtUser.Text == "" )
            {
                txtUser.Text = "Usuario"; 
            }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if(x>0)
            {
                txtUser.Clear();                
            }
            x++;
        }

        private void mtxtPass_Leave(object sender, EventArgs e)
        {
            if (mtxtPass.Text == "")
            { 
                mtxtPass.UseSystemPasswordChar=false;
                mtxtPass.Text = "Contraseña";
            }
        }

        
        
    }
}