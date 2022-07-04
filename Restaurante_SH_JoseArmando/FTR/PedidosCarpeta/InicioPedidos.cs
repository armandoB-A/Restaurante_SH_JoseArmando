using Restaurante_SH_JoseArmando.FTR.PedidosCarpeta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_SH_JoseArmando.FTR.Pedidos
{
    public partial class InicioPedidos : Form
    {
        private List<EyMItem> empleados;
        private List<EyMItem> mesas;
        private string claveemp;
        private List<string> mesa;
        public InicioPedidos()
        {
            InitializeComponent();
        }

        private void InicioPedidos_Load(object sender, EventArgs e)
        {
            empleados = ConexioMaestra_Jarmando.llenarEyM("exec mostrarEmpleados_2 'mesero'");
            crearEyM(empleados, "meseros");
        }
        private void crearEyM(List<EyMItem> empleados, string v)
        {
            foreach (var item in empleados)
            {

                item.flowLayoutPanel1.Tag = item.identificador;
                item.label1.Tag = item.identificador;
                item.pictureBox1.Tag = item.identificador;
                if (v == "meseros")
                {
                    item.flowLayoutPanel1.Click += Item_Click;
                    item.label1.Click += Item_Click;
                    item.pictureBox1.Click += Item_Click;
                }
                if (v == "mesas")
                {
                    item.flowLayoutPanel1.Click += itemMesa_Click;
                    item.label1.Click += itemMesa_Click;
                    item.pictureBox1.Click += itemMesa_Click;
                }
                flowLayoutPanel1.Controls.Add(item);
            }
        }

        private void itemMesa_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            int indice = Int16.Parse(control.Tag.ToString());
            EyMItem item = mesas.ElementAt(indice);
            mesa = new List<string>();
            mesa.Add(item.folioVent);
            mesa.Add(item.texto);
            MessageBox.Show(mesa.ElementAt(1));

            MessageBox.Show(item.status);

            AgregarVenta();
        }

        private void AgregarVenta()
        {
            string folio;
            string sqlV;
            if (mesa.ElementAt(0)=="")
            {
                DateTime dataTime = DateTime.Now;
                folio = dataTime.ToString("ddMMyyyyhhmmssf");
                sqlV = "execute ingresarVenta_JArmando '" + folio + "', " + mesa.ElementAt(1)
                        + ",'" + claveemp + "', 1;";
                MessageBox.Show(sqlV);
                ConexioMaestra_Jarmando.Ejecutar(sqlV);
            }
            else
            {
                folio=mesa.ElementAt(0);
            }

            PedidoDef pedido = new PedidoDef(folio, claveemp, mesa);
            pedido.Show();
        }

        private void Item_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            int indice = Int16.Parse(control.Tag.ToString());
            EyMItem item = empleados.ElementAt(indice);
            claveemp = item.claveemp;


            flowLayoutPanel1.Controls.Clear();
            panel2.Visible = true;
            mesas = ConexioMaestra_Jarmando.llenarMesas("exec mostrarMesasDefinitivo_ ");
            crearEyM(mesas, "mesas");
        }
    }
}
