using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_SH_JoseArmando.FTR
{
    public partial class Pedidosxd : Form
    {
        private DataTable dt;
        private string sql;
        public Pedidosxd()
        {
            InitializeComponent();
        }

        private void Pedidosxd_Load(object sender, EventArgs e)
        {
            IniciarCmbFolio();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            IniciarTablaVenta();
        }

        private void IniciarTablaVenta()
        {
            //grid 2
            dt = ConexioMaestra_Jarmando.ObtenerTablas("execute MostrarDVenta_JArmando '" +
                comboBox3.GetItemText(comboBox3.SelectedItem) + "'");
            dataGridView1.DataSource = dt;
        }

        private void IniciarCmbFolio()
        {
            //combo emleado
            dt = ConexioMaestra_Jarmando.ObtenerTablas("execute MostrarFolioVenta_JArmando");
            comboBox3.ValueMember = "folio_venta_jarmado";
            comboBox3.DisplayMember = "folio_venta_jarmado";
            comboBox3.DataSource = dt;
        }

        private void Borrar_Click(object sender, EventArgs e)
        {

        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            int filas = dataGridView1.RowCount - 2;
            int fila;

            for (fila = 0; fila <= filas; fila++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[fila].Cells[0].Value))
                {
                    if (dataGridView1.Rows[fila].Cells[3].Value != null)
                    {
                        string s;
                        s = dataGridView1.Rows[fila].Cells[3].Value.ToString();
                        if (float.TryParse(s, out float f))
                        {
                            float cantU = float.Parse(s);
                            string precio = dataGridView1.Rows[fila].Cells[2].Value.ToString();
                            precio = string.Join("", precio.Split('$'));
                            float precioU = float.Parse(precio);
                            precioU = precioU * cantU;

                            //sql+= "execute ingresarPedido_JArmando '" + comboBox1.GetItemText(comboBox1.SelectedItem) + "', " +
                            //    "'"+ dataGridView1.Rows[fila].Cells[1].Value.ToString() + "', " + cantU+", "+ comboBox2.GetItemText(comboBox2.SelectedItem) + "; \n";
                            //sql = "execute ingresarDVenta_JArmando '" + folioVenta + "', " +
                              //  "'" + dataGridView1.Rows[fila].Cells[1].Value.ToString() + "', " + cantU + ", " + precioU + "; \n";

                            //ConexioMaestra_Jarmando.Ejecutar(sql);
                        }
                        else
                        {
                            MessageBox.Show("No ingreso un valor aceptable en la cantidad");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No ingreso cantidad en la fila " + fila);
                    }
                }
            }
        }
    }
}
