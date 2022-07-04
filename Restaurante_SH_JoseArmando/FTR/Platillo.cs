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

namespace Restaurante_SH_JoseArmando
{
    public partial class Platillo : Form
    {
        public Platillo()
        {
            InitializeComponent();
        }
        private void Platillo_Load(object sender, EventArgs e)
        {
            IniciarDatos();
        }
        private void IniciarDatos()
        {
            // TODO: esta línea de código carga datos en la tabla 'jArmando_RestauranteSHDataSet.productos_jarmando' Puede moverla o quitarla según sea necesario.
            //this.productos_jarmandoTableAdapter.Fill(this.jArmando_RestauranteSHDataSet.productos_jarmando);
            string consultaSQL = "execute MostrarProducto_JArmando";
            DataTable dt = ConexioMaestra_Jarmando.ObtenerTablas(consultaSQL);
            productos_jarmandoDataGridView.DataSource = dt;
            
            //
            consultaSQL = "select nombre_categoria from categoria_jarmando ";
            dt = ConexioMaestra_Jarmando.ObtenerTablas(consultaSQL);
            dt.Rows.Add("--Agregar nueva categoria--");
            comboBox1.ValueMember = "nombre_categoria";
            comboBox1.DisplayMember = "nombre_categoria";
            comboBox1.DataSource = dt;
        }
        private void AbrirImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();  
            ofd.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG(*.png)|*.png";
            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);

            }
        }
        private void Agregar_Click(object sender, EventArgs e)
        {
            byte[] imagen = ImageToByteArray(pictureBox1.Image);

            string estado = checkBox2.Checked ? "1" : "0";
            if (VerificarDatos())
            {
                string procedsql = "execute ingresarPoducto_JArmando '" + textBox1.Text + "', '" + textBox2.Text +
                "' , '" + textBox3.Text + "' , @imagen, '" + textBox4.Text + "', '" + comboBox1.GetItemText(comboBox1.SelectedItem) + "', " + estado;
                ConexioMaestra_Jarmando.agregarImagen(procedsql, imagen);
                MessageBox.Show(Mensajes_JArmando.mnsjAgregarnExito(textBox1.Text));
                IniciarDatos();
            }
        }
        private void Actualizar_Click(object sender, EventArgs e)
        {
            byte[] imagen = ImageToByteArray(pictureBox1.Image);

            string cmb = comboBox1.GetItemText(comboBox1.SelectedItem);
            string estado = checkBox2.Checked ? "1" : "0";
            if (VerificarDatos())
            {
                string procedsql = "execute ingresarPoducto_JArmando '" + textBox1.Text + "', '" + textBox2.Text +
                "' , '" + textBox3.Text + "' , @imagen, '" + textBox4.Text + "', '" + comboBox1.GetItemText(comboBox1.SelectedItem) + "', " + estado;
                ConexioMaestra_Jarmando.agregarImagen(procedsql, imagen);
                MessageBox.Show(Mensajes_JArmando.mnsjAgregarnExito(textBox1.Text));
                IniciarDatos();
            }
        }

        private void Borrar_Click(object sender, EventArgs e)
        {

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
        
        private bool VerificarDatos()
        {
            int n;
            bool result = Int32.TryParse(textBox3.Text, out n);
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || result == false || 
                comboBox1.SelectedIndex == comboBox1.Items.Count - 1 || pictureBox1.Image == null)
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
                if (MessageBox.Show("¿Desea agregar una nueva categoria??", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
