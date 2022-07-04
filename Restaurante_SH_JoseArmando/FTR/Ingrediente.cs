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
    public partial class Ingrediente : Form
    {
        private string id_Ingrediente_jaba;
        public Ingrediente()
        {
            InitializeComponent();
        }

        private void Ingrediente_Load(object sender, EventArgs e)
        {
            IniciarDatos();
        }

        private void IniciarDatos()
        {
            // TODO: esta línea de código carga datos en la tabla 'jArmando_RestauranteSHDataSet.ingredientes_jarmado' Puede moverla o quitarla según sea necesario.
            //this.ingredientes_jarmadoTableAdapter.Fill(this.jArmando_RestauranteSHDataSet.ingredientes_jarmado);
            string consultaSQL = "execute MostrarIngrediente_JArmando";

            DataTable dt = ConexioMaestra_Jarmando.ObtenerTablas(consultaSQL);
            dataGridView1.DataSource = dt;

            //medida
            consultaSQL = "select nombre_medida_jarmado from medida_jarmado where status_medida_jarmado=1";

            dt = ConexioMaestra_Jarmando.ObtenerTablas(consultaSQL);

            dt.Rows.Add("--Agregar nueva marca--");

            comboBox1.ValueMember = "nombre_medida_jarmado";
            comboBox1.DisplayMember = "nombre_medida_jarmado";
            comboBox1.DataSource = dt;
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

                id_Ingrediente_jaba = dataGridView1.Rows[s].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[s].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[s].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[s].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[s].Cells[4].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[s].Cells[5].Value.ToString();

                checkBox2.Checked = (bool)dataGridView1.Rows[s].Cells[6].Value;

            }
        }

        private void Agregar_Click_1(object sender, EventArgs e)
        {
            string estado = checkBox2.Checked ? "1" : "0";

            if (VerificarDatos())
            {
                string str = "insert ingredientes_jarmado values('" + textBox1.Text + "', " + textBox2.Text + ","
                + textBox3.Text + ", " + textBox4.Text + ", (select top 1 id_medida_jarmado from medida_jarmado" +
                " where nombre_medida_jarmado = '" + comboBox1.GetItemText(comboBox1.SelectedItem) + "'), " + estado + ")";

                ConexioMaestra_Jarmando.Ejecutar(str);
                MessageBox.Show(Mensajes_JArmando.mnsjAgregarnExito(textBox1.Text));
                IniciarDatos();
            }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            string estado = checkBox2.Checked ? "1" : "0";

            if (VerificarDatos())
            {
                string str = "update ingredientes_jarmado set nombre_ingrediente_jarmado = " +
                    "'" + textBox1.Text + "', existencias_jarmado = " +
                   textBox2.Text + ", stock_min_jarmado = " + textBox3.Text + ", " +
                   "stock_max_jarmado = " + textBox4.Text + ", id_medida_jarmado = (select top 1 id_medida_jarmado" +
                   " from medida_jarmado where nombre_medida_jarmado = '" + comboBox1.GetItemText(comboBox1.SelectedItem) + "'), " +
                   "status_ingrediente_jarmado = " + estado + "" +
                   "where id_ingrediente_jarmado = " + id_Ingrediente_jaba;

                ConexioMaestra_Jarmando.Ejecutar(str);
                MessageBox.Show(Mensajes_JArmando.mnsjActualizarExito(textBox1.Text, id_Ingrediente_jaba));
                IniciarDatos();
            }
        }

        private void Borrar_Click(object sender, EventArgs e)
        {
            if (VerificarDatos())
            {
                string str = "delete ingredientes_jarmado where id_ingrediente_jarmado= " + id_Ingrediente_jaba;
                ConexioMaestra_Jarmando.Ejecutar(str);
                MessageBox.Show(Mensajes_JArmando.mnsjBorrarExito(textBox1.Text, id_Ingrediente_jaba));
                IniciarDatos();
            }
        }

        private void AgregarPA_Click(object sender, EventArgs e)
        {
            string estado = checkBox2.Checked ? "1" : "0";
            if (VerificarDatos())
            {
                string procedsql = "execute ingresarIngredientes_JArmando '" + textBox1.Text + "', " + textBox2.Text +
                "," + textBox3.Text + ", " + textBox4.Text + ", " + comboBox1.GetItemText(comboBox1.SelectedItem) + ", " + estado;
                ConexioMaestra_Jarmando.Ejecutar(procedsql);
                MessageBox.Show(Mensajes_JArmando.mnsjAgregarnExito(textBox1.Text));
                IniciarDatos();
            }
        }

        private bool VerificarDatos()
        {
            int n;
            bool result = Int32.TryParse(textBox2.Text, out n);
            bool result2 = Int32.TryParse(textBox3.Text, out n);
            bool result3 = Int32.TryParse(textBox4.Text, out n);
            if (textBox1.Text == "" || result == false || result2 == false || result3 == false || comboBox1.SelectedIndex == comboBox1.Items.Count - 1)
            {
                MessageBox.Show("No ingreso correctamente los datos");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == comboBox1.Items.Count - 1)
            {
                if (MessageBox.Show("¿Desea agregar una nueva medida??", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Medida medida = new Medida();
                    medida.Show();
                    IniciarDatos();
                }
                else
                {
                    MessageBox.Show("ni modo master");
                }
            }
        }
    }
}

