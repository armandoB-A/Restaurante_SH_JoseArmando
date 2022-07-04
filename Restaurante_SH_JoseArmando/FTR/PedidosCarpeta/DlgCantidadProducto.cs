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
    public partial class DlgCantidadProducto : Form
    {
        public DlgCantidadProducto()
        {
            InitializeComponent();
        }
        private void tcantidad(string s)
        {
            if (Int16.TryParse(textBox1.Text, out short re))
            {
                int aux = int.Parse(textBox1.Text);
                if (s.Equals("suma"))
                {
                    aux++;
                }
                else if (s.Equals("resta"))
                {
                    if (aux > 1)
                    {
                        aux--;
                    }
                }
                textBox1.Text = aux.ToString();
            }
            else
            {
                MessageBox.Show("");
                DialogResult = DialogResult.Cancel;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tcantidad("resta");

        }
        private void button2_Click(object sender, EventArgs e)
        {
            tcantidad("suma");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void DlgCantidadProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
