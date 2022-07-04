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
    public partial class Prueba : Form
    {
        private Button button2 = new Button();
        public Prueba()
        {
            InitializeComponent();
            button2.Location = new Point(74, 100);
            button2.Size = new Size(162, 38);
            button2.Text = "button2";
            button2.Click += button2_Click;
            this.Controls.Add(button2);
            button2.Visible = false;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button1.Visible = true;
        }
    }
}
