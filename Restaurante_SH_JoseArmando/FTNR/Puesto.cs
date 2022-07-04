using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_SH_JoseArmando.FTNR
{
    public partial class Puesto : Form
    {
        public Puesto()
        {
            InitializeComponent();
        }

        private void Puesto_Load(object sender, EventArgs e)
        {
            IniciarDatos();
        }
        public void IniciarDatos()
        {
            string consultaSQL = "execute MostrarPuesto_JArmando";

            DataTable dt = ConexioMaestra_Jarmando.ObtenerTablas(consultaSQL);
            dataGridView1.DataSource = dt;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string estado = checkBox2.Checked ? "1" : "0";
            if (VerificarDatos())
            {
                string str = "execute ingresarPuesto_JArmando '" + textBox1.Text + "', " + estado + "";
                ConexioMaestra_Jarmando.Ejecutar(str);
                IniciarDatos();
            }
        }

        private bool VerificarDatos()
        {
            if (textBox1.Text == "")
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
            Int32 selectedCellCount = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                int s = 0;
                for (int i = 0; i < selectedCellCount; i++)
                {
                    s = dataGridView1.SelectedCells[i].RowIndex;
                }

                textBox1.Text = dataGridView1.Rows[s].Cells[0].Value.ToString();
                checkBox2.Checked = (bool)dataGridView1.Rows[s].Cells[1].Value;

            }
        }

        
    }
}
