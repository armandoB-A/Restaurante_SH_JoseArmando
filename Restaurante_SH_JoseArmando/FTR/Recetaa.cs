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
    public partial class Recetaa : Form
    {
        public Recetaa()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnAgregar")
            {
                MessageBox.Show("agregar");
                Int32 selectedCellCount = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
                if (selectedCellCount > 0)
                {
                    int s = 0;
                    for (int i = 0; i < selectedCellCount; i++)
                    {
                        s = dataGridView1.SelectedCells[i].RowIndex;
                    }
                    string procedsql = "execute ingresarReseta_JArmando '" + dataGridView1.Rows[s].Cells[0].Value.ToString() + "', '" +
                        dataGridView1.Rows[s].Cells[1].Value.ToString() +  "'," + dataGridView1.Rows[s].Cells[2].Value.ToString() +
                        ", '" + dataGridView1.Rows[s].Cells[3].Value.ToString()+"'";
                    MessageBox.Show(procedsql);
                    ConexioMaestra_Jarmando.Ejecutar(procedsql);
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "BtnEliminar")
            {
                MessageBox.Show("borrar");
            }
        }

        private void Recetaa_Load(object sender, EventArgs e)
        {
            string consultaSQL = "select nombre_jarmado from productos_jarmando";

            DataTable dt = ConexioMaestra_Jarmando.ObtenerTablas(consultaSQL);

            CbxProducto.ValueMember = "nombre_jarmado";
            CbxProducto.DisplayMember = "nombre_jarmado";
            CbxProducto.DataSource = dt;
            

            consultaSQL = "select nombre_ingrediente_jarmado from ingredientes_jarmado where status_ingrediente_jarmado=1";

            dt = ConexioMaestra_Jarmando.ObtenerTablas(consultaSQL);

            CbxIngredientes.ValueMember = "nombre_ingrediente_jarmado";
            CbxIngredientes.DisplayMember = "nombre_ingrediente_jarmado";
            CbxIngredientes.DataSource = dt;


            consultaSQL = "select descripcion_jarmado from presentacion_jarmado where status_jarmado=1";

            dt = ConexioMaestra_Jarmando.ObtenerTablas(consultaSQL);

            CbxPresentacion.ValueMember = "descripcion_jarmado";
            CbxPresentacion.DisplayMember = "descripcion_jarmado";
            CbxPresentacion.DataSource = dt;

            consultaSQL = "select nombre_jarmado from productos_jarmando where estatus_jarmado=1";

            dt = ConexioMaestra_Jarmando.ObtenerTablas(consultaSQL);

        }
    }
}
