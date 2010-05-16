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
            //CargaInicial();
            //mtxtPass.UseSystemPasswordChar = true;
            cerrarSesionToolStripMenuItem.Enabled = false;
            productosToolStripMenuItem.Enabled = false;
            comprasToolStripMenuItem.Enabled = false;
            //herramientasToolStripMenuItem.Enabled = false;
            toolStripStatusLabel1.Text = "Jacinto Dot Net Carrito de Compras";
        }

        public void CargaInicial()
        {
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            Control.ControlCategorias ControladoraCategorias = new Control.ControlCategorias();
            Control.ControlUsuarios ControladoraUser = new Control.ControlUsuarios();
            Control.ControlCarritos COntroladoraCarrito = new Control.ControlCarritos();
            Control.ControlProductos ControladoraProductos = new Control.ControlProductos();

            ControladoraUser.AgregarNuevoUsuario("Gustavo Emmanuel", "Sanchez Figueroa", "emmanuel.sf@hotmail.com", "admin", "1234", "14 de Julio 2182 6º B - Mar del Plata", 32395520, 2);
            ControladoraUser.AgregarNuevoUsuario("Gustavo Emmanuel", "Sanchez Figueroa", "emmanuel.sf@hotmail.com", "user", "1234", "14 de Julio 2182 6º B - Mar del Plata", 32395520, 1);
            ControladoraUser.AgregarNuevoUsuario("Francisco", "Pane", "qwerfaqs@hotmail.com", "user2", "1234", "Alem 234 - Mar del Plata", 00000000, 1);
            ControladoraUser.AgregarNuevoUsuario("Cristina", "Kirchner", "kk@hotmail.com", "user3", "1234", "Edison 1948 - Mar Chiquita", 00000000, 1);

            ControladoraCategorias.InsertarCategoria("Lacteos", "1");
            ControladoraCategorias.InsertarCategoria("Fiambres", "2");
            ControladoraCategorias.InsertarCategoria("Limpieza", "3");
            ControladoraCategorias.InsertarCategoria("Supercongelados", "4");
            ControladoraCategorias.InsertarCategoria("Panaderia", "5");


            Categoria oCategoria = new Categoria();
            ControladoraCategorias.CargarCategorias(false);
            oCategoria = ControladoraCategorias.ObtenerUnaCategoria(1);
            ControladoraProductos.AgregarProducto(oCategoria, "1", Image.FromFile(path + "\\Imagenes\\PortSalut.jpg"), "Queso Port Salut Sancor", "100", "90", "10", "0");
            ControladoraProductos.AgregarProducto(oCategoria, "2", Image.FromFile(path + "\\Imagenes\\LecheConHierro.jpg"), "Leche con Hierro La Serenisima", "3", "2", "10", "0");
            ControladoraProductos.AgregarProducto(oCategoria, "3", Image.FromFile(path + "\\Imagenes\\Yogur.jpg"), "Yogurisimo Vainilla", "2", "2", "10", "0");
            oCategoria = ControladoraCategorias.ObtenerUnaCategoria(2);
            ControladoraProductos.AgregarProducto(oCategoria, "4", Image.FromFile(path + "\\Imagenes\\Mortadela.jpg"), "Mortadela Paladini", "70", "66", "10", "0");
            ControladoraProductos.AgregarProducto(oCategoria, "5", Image.FromFile(path + "\\Imagenes\\JamonCocido.jpg"), "Jamon Cocido Paladini", "70", "66", "10", "0");
            oCategoria = ControladoraCategorias.ObtenerUnaCategoria(3);
            ControladoraProductos.AgregarProducto(oCategoria, "6", Image.FromFile(path + "\\Imagenes\\Crema.jpg"), "Cif Crema", "7", "6", "10", "0");
            ControladoraProductos.AgregarProducto(oCategoria, "7", Image.FromFile(path + "\\Imagenes\\JabonEnPolvo.jpg"), "Javon en Polvo Ace", "10", "8", "10", "0");
            oCategoria = ControladoraCategorias.ObtenerUnaCategoria(4);
            ControladoraProductos.AgregarProducto(oCategoria, "8", Image.FromFile(path + "\\Imagenes\\Patitas.jpg"), "Patitas", "10", "8", "10", "0");
            ControladoraProductos.AgregarProducto(oCategoria, "9", Image.FromFile(path + "\\Imagenes\\HamburguesasPollo.jpg"), "Supremas con Jamon y queso Granja del Sol", "15", "13", "10", "0");
            ControladoraProductos.AgregarProducto(oCategoria, "10", Image.FromFile(path + "\\Imagenes\\Pizza.jpg"), "Pizza Especial Sivarita", "22", "19", "10", "0");
            oCategoria = ControladoraCategorias.ObtenerUnaCategoria(5);
            ControladoraProductos.AgregarProducto(oCategoria, "11", Image.FromFile(path + "\\Imagenes\\PanLactal.jpg"), "Pan Lactal Fargo", "5", "4", "10", "0");
            ControladoraProductos.AgregarProducto(oCategoria, "12", Image.FromFile(path + "\\Imagenes\\PanHamburguesas.jpg"), "Pan Hamburguesas Bimbo", "5", "4", "10", "0");

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
            COntroladoraCarrito2.AgregarItem(10, 10);
            COntroladoraCarrito2.AgregarItem(6, 6);
            COntroladoraCarrito2.GenerarOrden(this.session);

            //this.session = null;
            //this.session = ControladoraUser.LogIn("user3", "1234");

            //Control.ControlCarritos COntroladoraCarrito3 = new Control.ControlCarritos();
            //COntroladoraCarrito3.AgregarItem(7, 7);
            //COntroladoraCarrito3.AgregarItem(8, 8);
            //COntroladoraCarrito3.AgregarItem(9, 9);
            //COntroladoraCarrito3.AgregarItem(10, 10);
            //COntroladoraCarrito3.AgregarItem(6, 6);
            //OrdenCompra OC = COntroladoraCarrito3.GenerarOrden2(this.session);
            //OC.Estado = "CONFIRMADO";
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            //Principal___Administracion PA = new Principal___Administracion();
            //PA.Show();
        }
        
        public void iniciar_sesion()
        {
            Principal___Logueo PL = new Principal___Logueo(this.session);
            //PL.MdiParent = this;
            PL.ShowDialog();
            
            if(PL.DialogResult==DialogResult.Yes)
            {
                DateTime f = DateTime.Now;
                string minutos = f.Minute.ToString();
                if ((int)f.Minute < 10)
                {
                    minutos = "0" + minutos;
                }
                this.session = PL.session;
                this.Text = "Carrito de Compras - " + this.session.username;
                iniciarSesionToolStripMenuItem.Enabled = false;
                cerrarSesionToolStripMenuItem.Enabled = true;
                if (this.session.tipo == "CLIENT")
                {
                    productosToolStripMenuItem.Enabled = false;
                    //herramientasToolStripMenuItem.Enabled = false;
                    ordenesDeCompraToolStripMenuItem.Enabled = false;
                    comprasToolStripMenuItem.Enabled = true;
                    nuevaToolStripMenuItem.Enabled = true;
                    toolStripStatusLabel1.Text = "Sesion Iniciada el " + f.Day + "/" + f.Month + "/" + f.Year + " a las " + Convert.ToString(f.Hour) + ":" + minutos; 
                }
                else
                {
                    nuevaToolStripMenuItem.Enabled = false;
                    ordenesDeCompraToolStripMenuItem.Enabled = true;
                    productosToolStripMenuItem.Enabled = true;
                    //herramientasToolStripMenuItem.Enabled = true;
                    comprasToolStripMenuItem.Enabled = true;
                    toolStripStatusLabel1.Text = "Sesion Iniciada el " + f.Day + "/" + f.Month + "/" + f.Year + " a las " + Convert.ToString(f.Hour) + ":" + minutos; 
                }
            }
        }

        private void iniciarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciar_sesion();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciarSesionToolStripMenuItem.Enabled = true;
            this.Text = "Carrito de Compras - Sesion no iniciada";
            this.session = null;
            iniciarSesionToolStripMenuItem.Enabled = true;
            cerrarSesionToolStripMenuItem.Enabled = false;
            productosToolStripMenuItem.Enabled = false;
            comprasToolStripMenuItem.Enabled = false;
            //herramientasToolStripMenuItem.Enabled = false;
            toolStripStatusLabel1.Text = "";
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministracionProductos AP = new AdministracionProductos(this.session);
            AP.Show();
        }

        private void listadoDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministracionABMProductos AABMP = new AdministracionABMProductos(this.session);
            AABMP.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministracionCategorias AC = new AdministracionCategorias(this.session);
            AC.Show();
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Principal___Usuario PU = new Principal___Usuario(this.session);
            PU.Show();
        }

        private void ordenesDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministracionOrdenesdeCompra AOC = new AdministracionOrdenesdeCompra(this.session);
            AOC.Show();
        }

        private void temasDeAyudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Llama al 911");
        }

        private void acercaDeJacintoDotNetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe AD = new AcercaDe();
            AD.Show();
        }

        

        

        

        

        

        

        

       
    }
}