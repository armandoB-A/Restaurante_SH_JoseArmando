using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_SH_JoseArmando.FTR
{
    public partial class PedidoDef : Form
    {
        private Button currentButton;
        private List<Categorias> listaCategorias;
        private DataTable dt;
        private string sql;
        private List<Productos> lista;
        private string folioVenta;
        private string claveemp;
        private List<string> mesa;

        //private DlgCantidadProducto dlgCantidadProducto;

        public PedidoDef()
        {
            InitializeComponent();
            //dlgCantidadProducto = new DlgCantidadProducto();
        }

        public PedidoDef(string folio, string claveemp, List<string> mesa)
        {
            folioVenta = folio;
            this.claveemp = claveemp;
            this.mesa = mesa;
            InitializeComponent();
        }

        private void PedidoDef_Load(object sender, EventArgs e)
        {
            button4.BackColor = Color.SteelBlue;

            iniciarCategoria();

            iniciarTool();
        }
        
        private void iniciarTool()
        {
            string s= "select clave_empleado_jarmado from empleado_jarmado where id_puesto_jarmado =" +
                "(select top 1 id_puesto_jarmado from puesto_jarmando where nombre_puesto_jarmado = 'mesero'); ";
            
            toolStripStatusLabel2.Text = folioVenta;
            toolStripStatusLabel4.Text = mesa.ElementAt(1);
            toolStripStatusLabel6.Text = claveemp;
        }

        private void IniciarFolio()
        {
            sql = "execute MostrarProducto_p_JArmando";
            iniciarProductos(sql);
            string folio = ConexioMaestra_Jarmando.ObtenerFolio("SELECT TOP(1) folio_venta_jarmado FROM venta_jarmado ORDER BY folio_venta_jarmado DESC");
            int aux = Int32.Parse(folio.Substring(4));
            aux += 1;
            folio = folio.Remove(folio.IndexOf("T") + 1);
            folio += aux;
        }

        private void iniciarProductos(string sql)
        {
            lista = ConexioMaestra_Jarmando.llenarProductos(sql);
            int i = 0;
            foreach (Productos p in lista)
            {
                FlowLayoutPanel panelProductos = new FlowLayoutPanel();
                panelProductos.BorderStyle = BorderStyle.Fixed3D;
                // pictureBox1
                PictureBox pb = new PictureBox();
                pb.Image = Image.FromStream(new MemoryStream(p.imagen));
                pb.Margin = new Padding(10);
                pb.Name = "pictureBox" + i;
                pb.Size = new Size(124, 84);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                //
                panelProductos.Controls.Add(pb);
                //label 1
                Label etiquetaNprod = new Label();
                etiquetaNprod.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                etiquetaNprod.Margin = new Padding(5, 5, 0, 5);
                etiquetaNprod.Name = "nProd" + i;
                etiquetaNprod.Text = p.nombre;
                //
                panelProductos.Controls.Add(etiquetaNprod);
                //
                //label 2
                etiquetaNprod = new Label();
                etiquetaNprod.Margin = new Padding(5, 5, 0, 5);
                etiquetaNprod.Name = "nPrecioP" + i;
                etiquetaNprod.Text = p.precio;
                //
                panelProductos.Controls.Add(etiquetaNprod);
                //
                //Boton 
                Button botonProd = new Button();
                botonProd.Location = new Point(9, 185);
                botonProd.Margin = new Padding(9, 3, 3, 3);
                botonProd.Name = "botonPRod" + i;
                botonProd.Size = new Size(131, 23);
                botonProd.Text = "agregar";
                botonProd.TabIndex = i;
                botonProd.UseVisualStyleBackColor = true;
                botonProd.Click += productoClick;
                panelProductos.Controls.Add(botonProd);

                panelProductos.Margin = new Padding(20);
                panelProductos.Name = "flowLayoutPanel" + i;
                panelProductos.Size = new Size(150, 219);
                flowLayoutPanel3.Controls.Add(panelProductos);

                i++;
            }
        }


        private void productoClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            DlgCantidadProducto cantidadProducto = new DlgCantidadProducto();

            if (cantidadProducto.ShowDialog() == DialogResult.OK)
            {
                Productos p = lista.ElementAt(b.TabIndex);

                string cantidad = cantidadProducto.textBox1.Text;
                AgregarDVenta(p.nombre, p.precio, cantidad);
                listBox1.Items.Add("- " + cantidad + " " + p.nombre);
                panel3.Visible = true;
            }
            else
            {
                MessageBox.Show("unos pedillos");
            }
        }
        private void iniciarCategoria()
        {
            //AgregarVenta();
            sql = "select imagen_c_jarmando,nombre_categoria from categoria_jarmando";
            listaCategorias = ConexioMaestra_Jarmando.llenarCategorias(sql);
            int i = 0;
            foreach (Categorias str in listaCategorias)
            {
                FlowLayoutPanel flowLayoutPanel5 = new FlowLayoutPanel();
               
                //this.flowLayoutPanel5.Controls.Add(this.button4);
                //
                PictureBox pb = new PictureBox();
                pb.Image = Image.FromStream(new MemoryStream(str.imagenesCat));
                pb.Name = "pictureBox" + i;
                pb.Size = new Size(30, 30);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                //
                Button button2 = new Button();
                button2.BackColor = Color.DarkSlateBlue;
                button2.FlatAppearance.BorderSize = 0;
                button2.FlatAppearance.MouseOverBackColor = Color.SteelBlue;
                button2.FlatStyle = FlatStyle.Flat;
                button2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                button2.ForeColor = Color.White;
                button2.Name = "botonCat" + i;
                button2.Size = new Size(flowLayoutPanel5.Width - 30, 30);
                button2.Text = str.nombre;
                button2.Click += ActivateButton;
                flowLayoutPanel5.Height = 40;
                flowLayoutPanel5.Width = flowLayoutPanel1.Width;
                flowLayoutPanel5.Controls.Add(pb);
                flowLayoutPanel5.Controls.Add(button2);

                flowLayoutPanel1.Controls.Add(flowLayoutPanel5);
                i++;
            }
        }

        private void AgregarDVenta(string nombre, string precio, string cantU)
        {
            sql = "execute ingresarDVenta_JArmando '" + folioVenta + "', " +
                                "'" + nombre + "', " + cantU + ", " + precio.Substring(1) + ";";
            MessageBox.Show(sql);
            ConexioMaestra_Jarmando.Ejecutar(sql);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Pedidosxd pedidosxd = new Pedidosxd();
            pedidosxd.Show();
        }
        private void finalizarCompra_Click(object sender, EventArgs e)
        {
            sql = "execute FilnalizarVenta_JArmando '" + folioVenta + "', "+mesa.ElementAt(1)+";";
            MessageBox.Show(sql);
            ConexioMaestra_Jarmando.Ejecutar(sql);
            this.Close();
        }
        private void ActivateButton(object btnSender, EventArgs e)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.SteelBlue;
                    flowLayoutPanel3.Controls.Clear();
                    if (currentButton.Text == "Productos Relevantes")
                    {
                        iniciarProductos("execute MostrarProducto_p_JArmando");
                    }
                    else
                    {
                        iniciarProductos("execute MostrarProducto_pct_JArmando '" + currentButton.Text + "'");
                    }
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in flowLayoutPanel1.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.DarkSlateBlue;
                    MessageBox.Show("");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            iniciarTool();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            iniciarTool();
        }
    }
}
