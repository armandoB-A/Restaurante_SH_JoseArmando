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
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            IniciarDatos();
        }
        public void IniciarDatos()
        {
            string consultaSQL = "execute MostrarMedida_JArmando";

            DataTable dt = ConexioMaestra_Jarmando.ObtenerTablas(consultaSQL);
            dataGridView1.DataSource = dt;
        }
    }
}
