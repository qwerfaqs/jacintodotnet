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

        private void Form1_Load(object sender, EventArgs e)
        {
            CargaInicial();
            mtxtPass.UseSystemPasswordChar = true;
        }

        public void CargaInicial()
        {
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            Control.ControlCategorias ControladoraCategorias = new Control.ControlCategorias();
            Control.ControlUsuarios ControladoraUser = new Control.ControlUsuarios();
            Control.ControlCarritos COntroladoraCarrito = new Control.ControlCarritos();
            Control.ControlProductos ControladoraProductos = new Control.ControlProductos();

            ControladoraUser.AgregarNuevoUsuario("Gustavo Emmanuel", "Sanchez Figueroa", "emmanuel.sf@hotmail.com", "admin", "1234", "14 de Julio 2182 6º B", 32395520,2);
            ControladoraUser.AgregarNuevoUsuario("Gustavo Emmanuel", "Sanchez Figueroa", "emmanuel.sf@hotmail.com", "user", "1234", "14 de Julio 2182 6º B", 32395520, 1);
            ControladoraUser.AgregarNuevoUsuario("Francisco", "Pane", "qwerfaqs@hotmail.com", "user2", "1234", "Alem 234", 00000000, 1);

            ControladoraCategorias.InsertarCategoria("Lacteos", "1");
            ControladoraCategorias.InsertarCategoria("Fiambres", "2");
            ControladoraCategorias.InsertarCategoria("Limpieza", "3");
            ControladoraCategorias.InsertarCategoria("Supercongelados", "4");
            ControladoraCategorias.InsertarCategoria("Panaderia", "5");

            
            Categoria oCategoria = new Categoria();
            ControladoraCategorias.CargarCategorias(false);
            oCategoria = ControladoraCategorias.ObtenerUnaCategoria(1);
            ControladoraProductos.AgregarProducto(oCategoria, "1", Image.FromFile(path + "\\Imagenes\\PortSalut.jpg"), "Queso Port Salut Sancor", "100", "90", "4", "1");
            ControladoraProductos.AgregarProducto(oCategoria, "2", Image.FromFile(path + "\\Imagenes\\LecheConHierro.jpg"), "Leche con Hierro La Serenisima", "3", "2", "4", "1");
            ControladoraProductos.AgregarProducto(oCategoria, "3", Image.FromFile(path + "\\Imagenes\\Yogur.jpg"), "Yogurisimo Vainilla", "2", "2", "4", "1");
            oCategoria = ControladoraCategorias.ObtenerUnaCategoria(2);
            ControladoraProductos.AgregarProducto(oCategoria, "4", Image.FromFile(path + "\\Imagenes\\Mortadela.jpg"), "Mortadela Paladini", "70", "66", "4", "1");
            ControladoraProductos.AgregarProducto(oCategoria, "5", Image.FromFile(path + "\\Imagenes\\JamonCocido.jpg"), "Jamon Cocido Paladini", "70", "66", "4", "1");
            oCategoria = ControladoraCategorias.ObtenerUnaCategoria(3);
            ControladoraProductos.AgregarProducto(oCategoria, "6", Image.FromFile(path + "\\Imagenes\\Crema.jpg"), "Cif Crema", "7", "6", "4", "1");
            ControladoraProductos.AgregarProducto(oCategoria, "7", Image.FromFile(path + "\\Imagenes\\JabonEnPolvo.jpg"), "Javon en Polvo Ace", "10", "8", "4", "1");
            oCategoria = ControladoraCategorias.ObtenerUnaCategoria(4);
            ControladoraProductos.AgregarProducto(oCategoria, "8", Image.FromFile(path + "\\Imagenes\\Patitas.jpg"), "Patitas", "10", "8", "4", "1");
            ControladoraProductos.AgregarProducto(oCategoria, "9", Image.FromFile(path + "\\Imagenes\\HamburguesasPollo.jpg"), "Supremas con Jamon y queso Granja del Sol", "15", "13", "4", "1");
            ControladoraProductos.AgregarProducto(oCategoria, "10", Image.FromFile(path + "\\Imagenes\\Pizza.jpg"), "Pizza Especial Sivarita", "22", "19", "4", "1");
            oCategoria = ControladoraCategorias.ObtenerUnaCategoria(5);
            ControladoraProductos.AgregarProducto(oCategoria, "11", Image.FromFile(path + "\\Imagenes\\PanLactal.jpg"), "Pan Lactal Fargo", "5", "4", "4", "1");
            ControladoraProductos.AgregarProducto(oCategoria, "12", Image.FromFile(path + "\\Imagenes\\PanHamburguesas.jpg"), "Pan Hamburguesas Bimbo", "5", "4", "6", "1");
            
            this.session = ControladoraUser.LogIn("user", "1234");

            COntroladoraCarrito.AgregarItem(2, 2);
            COntroladoraCarrito.AgregarItem(3, 3);
            COntroladoraCarrito.AgregarItem(4, 4);
            COntroladoraCarrito.AgregarItem(5, 5);
            COntroladoraCarrito.AgregarItem(6, 6);
            COntroladoraCarrito.GenerarOrden(this.session);

            this.session = null;
            this.session = ControladoraUser.LogIn("user2", "1234");

            Control.ControlCarritos COntroladoraCarrito2 = new Control.ControlCarritos();
            COntroladoraCarrito2.AgregarItem(7, 7);
            COntroladoraCarrito2.AgregarItem(8, 8);
            COntroladoraCarrito2.AgregarItem(9, 9);
            COntroladoraCarrito2.AgregarItem(10,10);
            COntroladoraCarrito2.AgregarItem(6, 6);
            COntroladoraCarrito2.GenerarOrden(this.session);
        
        }

        
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

                
                label3.Text = "";
                if (this.session.tipo.Equals("CLIENT"))
                {
                    Principal___Usuario PU = new Principal___Usuario(this.session);
                    PU.Show();
                }
                else if (this.session.tipo.Equals("ADMIN"))
                {
                    AdministracionMenu AM = new AdministracionMenu(this.session);
                    AM.Show();
                }
                
            }
            catch (Exception ex)
            {
                
                label3.Text = ex.Message+" - "+ex.InnerException.Message;
                panel1.Visible = true;
                button3.Hide();
                button4.Hide();
                
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

        
        private void button1_Click(object sender, EventArgs e)
        {
            button4.Show();
            button3.Show();
            panel1.Visible = false;
            //AdministracionMenu AM = new AdministracionMenu();
            //AM.Show();
        }

       
    }
}