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

namespace Restaurante_SH_JoseArmando.FTNR
{
    public partial class Mesero : Form
    {
        public string id_categoria_jaba;
        public Mesero()
        {
            InitializeComponent();
        }

        private void Mesero_Load(object sender, EventArgs e)
        {
            IniciarDatos();
        }
        public void IniciarDatos()
        {
            string consultaSQL = "exec mostrarEmpleados_2 'mesero' ";

            DataTable dt = ConexioMaestra_Jarmando.ObtenerTablas(consultaSQL);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (VerificarDatos())
            {
                string str = "execute ingresarCategoria_JArmando '" + textBox1.Text + "', '" + textBox2.Text + "'";

                ConexioMaestra_Jarmando.Ejecutar(str);
                MessageBox.Show(Mensajes_JArmando.mnsjAgregarnExito(textBox1.Text));
                IniciarDatos();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] imagen = ImageToByteArray(pictureBox1.Image);
            if (VerificarDatos())
            {
                //
                string str = "update empleado_jarmado set imagen_empleado_jarmado= @imagen where clave_empleado_jarmado='" + id_categoria_jaba + "';";

                ConexioMaestra_Jarmando.agregarImagen(str, imagen);
                MessageBox.Show(Mensajes_JArmando.mnsjAgregarnExito(textBox1.Text));
                IniciarDatos();
            }
        }

        public byte[] ImageToByteArray(Image imagen)
        {
            if (pictureBox1.Image == null)
            {
                return null;
            }
            MemoryStream ms = new MemoryStream();
            imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = "BorrarCategoria_JArmando " + id_categoria_jaba;

            ConexioMaestra_Jarmando.Ejecutar(str);
            MessageBox.Show(Mensajes_JArmando.mnsjBorrarExito(textBox1.Text, id_categoria_jaba));
            IniciarDatos();
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


        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG(*.png)|*.png";
            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);

            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedCellCount = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                int s = 0;
                for (int i = 0; i < selectedCellCount; i++)
                {
                    s = dataGridView1.SelectedCells[i].RowIndex;
                }
                id_categoria_jaba = dataGridView1.Rows[s].Cells[0].Value.ToString();
                //textBox1.Text = dataGridView1.Rows[s].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[s].Cells[2].Value.ToString();

            }
        }
    }
}