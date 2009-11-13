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
    public partial class Principal : Form
    {
        Session session = null;
        public Principal()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    AdministracionCategorias ABM = new AdministracionCategorias();
        //    ABM.Show();
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            CargaInicial();
            mtxtPass.UseSystemPasswordChar = true;
        }

        public void CargaInicial()
        {
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            Control.ControlCategorias Controladora = new Control.ControlCategorias();
            Control.ControlCategorias CC = new Control.ControlCategorias();
            Control.ControlUsuarios ControladoraU = new Control.ControlUsuarios();
            ControladoraU.AgregarNuevoUsuario("Gustavo Emmanuel", "Sanchez Figueroa", "emmanuel.sf@hotmail.com", "admin", "1234", "14 de Julio 2182 6º B", 32395520,2);
            ControladoraU.AgregarNuevoUsuario("Gustavo Emmanuel", "Sanchez Figueroa", "emmanuel.sf@hotmail.com", "user", "1234", "14 de Julio 2182 6º B", 32395520, 1);
            

            Controladora.InsertarCategoria("Lacteos", "1");
            Controladora.InsertarCategoria("Fiambres", "2");
            Controladora.InsertarCategoria("Limpieza", "3");
            Controladora.InsertarCategoria("Supercongelados", "4");
            Controladora.InsertarCategoria("Panaderia", "5");

            Control.ControlProductos ControladoraP = new Control.ControlProductos();
            Categoria oCategoria = new Categoria();
            CC.CargarCategorias(false);
            oCategoria = CC.ObtenerUnaCategoria(1);
            ControladoraP.AgregarProducto(oCategoria, "1", Image.FromFile(path + "\\Imagenes\\PortSalut.jpg"), "Queso Port Salut Sancor", "100", "90", "4", "1");
            ControladoraP.AgregarProducto(oCategoria, "2", Image.FromFile(path + "\\Imagenes\\LecheConHierro.jpg"), "Leche con Hierro La Serenisima", "3", "2", "4", "1");
            ControladoraP.AgregarProducto(oCategoria, "3", Image.FromFile(path + "\\Imagenes\\Yogur.jpg"), "Yogurisimo Vainilla", "2", "2", "4", "1");
            oCategoria = CC.ObtenerUnaCategoria(2);
            ControladoraP.AgregarProducto(oCategoria, "4", Image.FromFile(path + "\\Imagenes\\Mortadela.jpg"), "Mortadela Paladini", "70", "66", "4", "1");
            ControladoraP.AgregarProducto(oCategoria, "5", Image.FromFile(path + "\\Imagenes\\JamonCocido.jpg"), "Jamon Cocido Paladini", "70", "66", "4", "1");
            oCategoria = CC.ObtenerUnaCategoria(3);
            ControladoraP.AgregarProducto(oCategoria, "6", Image.FromFile(path + "\\Imagenes\\Crema.jpg"), "Cif Crema", "7", "6", "4", "1");
            ControladoraP.AgregarProducto(oCategoria, "7", Image.FromFile(path + "\\Imagenes\\JabonEnPolvo.jpg"), "Javon en Polvo Ace", "10", "8", "4", "1");
            oCategoria = CC.ObtenerUnaCategoria(4);
            ControladoraP.AgregarProducto(oCategoria, "8", Image.FromFile(path + "\\Imagenes\\Patitas.jpg"), "Patitas", "10", "8", "4", "1");
            ControladoraP.AgregarProducto(oCategoria, "9", Image.FromFile(path + "\\Imagenes\\HamburguesasPollo.jpg"), "Supremas con Jamon y queso Granja del Sol", "15", "13", "4", "1");
            ControladoraP.AgregarProducto(oCategoria, "10", Image.FromFile(path + "\\Imagenes\\Pizza.jpg"), "Pizza Especial Sivarita", "22", "19", "4", "1");
            oCategoria = CC.ObtenerUnaCategoria(5);
            ControladoraP.AgregarProducto(oCategoria, "11", Image.FromFile(path + "\\Imagenes\\PanLactal.jpg"), "Pan Lactal Fargo", "5", "4", "4", "1");
            ControladoraP.AgregarProducto(oCategoria, "12", Image.FromFile(path + "\\Imagenes\\PanHamburguesas.jpg"), "Pan Hamburguesas Bimbo", "5", "4", "6", "1");
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    AdministracionProductos AP = new AdministracionProductos();
        //    AP.Show();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    AdministracionABMProductos AABMP = new AdministracionABMProductos();
        //    AABMP.Show();
        //}

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                label3.Text = "";
                Control.ControlUsuarios CU = new Control.ControlUsuarios();
                this.session = CU.LogIn(txtUser.Text, mtxtPass.Text);
            }
            catch 
            {
                
            }

            if ( this.session==null || this.session.Loged == false)
            {
                label3.Text = "Nombre de usuario o contraseña incorrectos!";
                panel1.Visible = true;
                button3.Hide();
                button4.Hide();
            }
            else
            {
                label3.Text = "";
                if (this.session.tipo.Equals("CLIENT"))
                {
                    Principal___Usuario PU = new Principal___Usuario(this.session);
                    PU.Show();
                }
                else if(this.session.tipo.Equals("ADMIN"))
                {
                    Principal___Administracion PA = new Principal___Administracion(this.session);
                    PA.Show();
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            //Principal___Administracion PA = new Principal___Administracion();
            //PA.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = false;
            txtUser.Clear();
            mtxtPass.Clear();
            button4.Show();
            button3.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("NO TE HAGAS EL VIVO Y PONE BIEN EL USER Y PASS", "KERNEL PANIC", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification, true);
           // Principal___Administracion PA = new Principal___Administracion();
           // PA.Show();
        }

       
    }
}