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

namespace Restaurante_SH_JoseArmando.FTR.PedidosCarpeta
{
    public partial class EyMItem : UserControl
    {

        #region  confglobales 
        private byte[] _imagen;
        public byte[] imagen
        {
            get { return _imagen; }
            set { _imagen = value; pictureBox1.Image = Image.FromStream(new MemoryStream(value)); }
        }
        private string _texto;
        public string texto
        {
            get { return _texto; }
            set { _texto = value; label1.Text = value; }
        }
        public int identificador
        {
            get;
            set;
        }
        #endregion

        #region Empleado
        public string claveemp
        {
            get;
            set;
        }
        #endregion

        #region

        private string _status;
        public string status
        {
            get { return _status; }
            set { 
                _status = value;
                if (value=="False")
                {
                    flowLayoutPanel1.BackColor = Color.Lime;
                }else if (value == "True")
                {
                    flowLayoutPanel1.BackColor = Color.Yellow;
                }
            }
        }
        public string folioVent
        {
            get;
            set;
        }
        #endregion
        public EyMItem()
        {
            InitializeComponent();
        }

        private void EmpleadoItem_MouseEnter(object sender, EventArgs e)
        {
            flowLayoutPanel1.BackColor = Color.Silver;
        }

        private void EmpleadoItem_MouseLeave(object sender, EventArgs e)
        {
            flowLayoutPanel1.BackColor = Color.White;
        }

        private void EmpleadoItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

    }
}
