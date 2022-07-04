using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_SH_JoseArmando.FTNR
{
    public partial class RecetaV1 : Form
    {
        private string consultaSQL;
        private DataTable dt;
        public RecetaV1()
        {
            InitializeComponent();
        }

        private void RecetaV1_Load(object sender, EventArgs e)
        {
            IniciarCmbProducto();
        }
        private void IniciarCmbProducto()
        {
            consultaSQL = "select nombre_producto_jarmado from productos_jarmando where estatus_jarmado = 1";
            dt = ConexioMaestra_Jarmando.ObtenerTablas(consultaSQL);
            dt.Rows.Add("--Agregar nuevo platillo--");
            comboBox1.ValueMember = "nombre_producto_jarmado";
            comboBox1.DisplayMember = "nombre_producto_jarmado";
            comboBox1.DataSource = dt;

        }
        private void IniciarTabla()
        {
            consultaSQL = "execute mostrarReseta_JArmando '" + comboBox1.GetItemText(comboBox1.SelectedItem) + "';";
            dataGridView1 = ConexioMaestra_Jarmando.llenarGrid3(dataGridView1, consultaSQL);

            consultaSQL = "select descripcion_jarmado from presentacion_jarmado where status_jarmado=1";
            dt = ConexioMaestra_Jarmando.ObtenerTablas(consultaSQL);
            CmbPresentacion.ValueMember = "descripcion_jarmado";
            CmbPresentacion.DisplayMember = "descripcion_jarmado";
            CmbPresentacion.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int filas=dataGridView1.RowCount-2;
            string sql="";
            int fila;
            for (fila = 0; fila <= filas; fila++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[fila].Cells[0].Value))
                {
                    if (dataGridView1.Rows[fila].Cells[2].Value!=null)
                    {
                        string s;
                        s = dataGridView1.Rows[fila].Cells[2].Value.ToString();

                        if (float.TryParse(s, out float f))
                        {
                            sql = "execute ingresarReseta1_JArmando '" + comboBox1.GetItemText(comboBox1.SelectedItem) + "', " +
                                "'"+ dataGridView1.Rows[fila].Cells[1].Value.ToString() + "', "+ dataGridView1.Rows[fila].Cells[2].Value.ToString() + ",'"+ 
                                dataGridView1.Rows[fila].Cells[3].Value.ToString() + "' ";

                            listBox1.Items.Add(dataGridView1.Rows[fila].Cells[1].Value.ToString());
                            ConexioMaestra_Jarmando.Ejecutar(sql);
                        }
                        else
                        {
                            MessageBox.Show("No ingreso un valor aceptable en la cantidad");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("No ingreso cantidad");
                    }
                }
            }
            VaciarElementos();
            IniciarTabla();
        }
        private void VaciarElementos()
        {
            dataGridView1.Rows.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VaciarElementos();
            IniciarTabla();
        }
    }
}
