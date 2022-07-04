using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_SH_JoseArmando
{
    public partial class Medida : Form
    {
        public string id_Medida_jaba;

        public Medida()
        {
            InitializeComponent();
        }

        private void Medida_Load(object sender, EventArgs e)
        {
            IniciarDatos();
           
        }
        public void IniciarDatos()
        {
            // TODO: esta línea de código carga datos en la tabla 'jArmando_RestauranteSHDataSet.medida_jarmado' Puede moverla o quitarla según sea necesario.
            //this.medida_jarmadoTableAdapter.Fill(this.jArmando_RestauranteSHDataSet.medida_jarmado);
            string consultaSQL = "execute MostrarMedida_JArmando";

            DataTable dt = ConexioMaestra_Jarmando.ObtenerTablas(consultaSQL);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedCellCount = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                int s = 0;
                for (int i = 0; i < selectedCellCount; i++)
                {
                    s = dataGridView1.SelectedCells[i].RowIndex;
                }

                id_Medida_jaba = dataGridView1.Rows[s].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[s].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[s].Cells[2].Value.ToString();

                checkBox2.Checked = (bool)dataGridView1.Rows[s].Cells[3].Value;

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string estado = checkBox2.Checked ? "1" : "0";
            if (VerificarDatos())
            {
                string str = "ingresarMedida_JArmando '" + textBox1.Text + "', '" + textBox2.Text + "', " + estado + "";

                ConexioMaestra_Jarmando.Ejecutar(str);
                MessageBox.Show(Mensajes_JArmando.mnsjAgregarnExito(textBox1.Text));
                IniciarDatos();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string estado = checkBox2.Checked ? "1" : "0";
            if (VerificarDatos())
            {
                string str = "update medida_jarmado set nombre_medida_jarmado = " +
                "'" + textBox1.Text + "', abreviatura_medida_jarmado = '" + textBox2.Text
                + "', status_medida_jarmado =" + estado + "" +
                   "where id_medida_jarmado = " + id_Medida_jaba;

                ConexioMaestra_Jarmando.Ejecutar(str);
                MessageBox.Show(Mensajes_JArmando.mnsjActualizarExito(textBox1.Text, id_Medida_jaba));
                IniciarDatos();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (VerificarDatos())
            {
                string str = "delete medida_jarmado where id_medida_jarmado= " + id_Medida_jaba;

                ConexioMaestra_Jarmando.Ejecutar(str);
                MessageBox.Show(Mensajes_JArmando.mnsjBorrarExito(textBox1.Text, id_Medida_jaba));
                IniciarDatos();
            }
        }

        private bool VerificarDatos()
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("No ingreso correctamente los datos");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
