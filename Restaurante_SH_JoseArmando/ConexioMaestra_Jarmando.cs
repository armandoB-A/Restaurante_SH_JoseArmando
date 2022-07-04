using Restaurante_SH_JoseArmando.FTR;
using Restaurante_SH_JoseArmando.FTR.PedidosCarpeta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_SH_JoseArmando
{
    internal class ConexioMaestra_Jarmando
    {
        //static String servidor_jarmando = "LAPTOP-25AIBIN4";
        //static String user_jarmando = "sa";
        //static String contrasenia = "201923412";
        //static String dataBaseName = "JArmando_RestauranteSH";
        //static String cadenaConexion_jarmando ="data source="
        //    +servidor_jarmando+"; initial catalog= "
        //    +dataBaseName+"; user id="
        //    +user_jarmando+"; password="+contrasenia+";";
        public static SqlConnection conectar_JArmando = new SqlConnection(Properties.Settings.Default.JArmando_RestauranteSHConnectionString);
        public static SqlCommand OrdenSql;
        public static SqlDataReader leer_jarmando;
        public static SqlDataAdapter da;

        public static void Abrir_JArmando()
        {
            conectar_JArmando.Open();
        }

        public static void Ejecutar(string strSQL)
        {
            try
            {
                SqlCommand OrdenSql = new SqlCommand(strSQL, conectar_JArmando);
                // Abrir la conexión con la base de datos 
                // ExecuteReader hace la consulta y devuelve un SqlDataReader 
                SqlDataReader leer_jarmando = OrdenSql.ExecuteReader();
                while (leer_jarmando.Read())
                {
                    MessageBox.Show(leer_jarmando["mensaje"].ToString());
                }
                leer_jarmando.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la accion");
            }
        }
        public static string ObtenerFolio(string strSQL)
        {
            try
            {
                OrdenSql = new SqlCommand(strSQL, conectar_JArmando);
                // Abrir la conexión con la base de datos 
                // ExecuteReader hace la consulta y devuelve un SqlDataReader 
                leer_jarmando = OrdenSql.ExecuteReader();
                string folio = "";
                while (leer_jarmando.Read())
                {
                    folio = leer_jarmando[0].ToString();
                }
                leer_jarmando.Close();

                return folio;
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la accion");
                return "";
            }
        }
        public static DataGridView llenarGrid(DataGridView tabla, string strSQL)
        {
            OrdenSql = new SqlCommand(strSQL, conectar_JArmando);
            leer_jarmando = OrdenSql.ExecuteReader();
            while (leer_jarmando.Read())
            {
                tabla.Rows.Add();
                tabla.Rows[tabla.Rows.Count - 2].Cells[1].Value = leer_jarmando[0];
            }
            leer_jarmando.Close();
            return tabla;
        }
        public static List<Categorias> llenarCategorias(string strSQL)
        {
            List<Categorias> categorias = new List<Categorias>();
            OrdenSql = new SqlCommand(strSQL, conectar_JArmando);
            leer_jarmando = OrdenSql.ExecuteReader();

            while (leer_jarmando.Read())
            {
                categorias.Add(new Categorias() { imagenesCat = ((byte[])leer_jarmando[0]), nombre = leer_jarmando[1].ToString() });
            }
            leer_jarmando.Close();
            return categorias;
        }


        public static List<Productos> llenarProductos(string strSQL)
        {
            List<Productos> prductos = new List<Productos>();

            OrdenSql = new SqlCommand(strSQL, conectar_JArmando);
            leer_jarmando = OrdenSql.ExecuteReader();

            int i = 0;
            while (leer_jarmando.Read())
            {
                prductos.Add(new Productos() { imagen = ((byte[])leer_jarmando[0]), nombre = leer_jarmando[1].ToString(), precio = "$" + leer_jarmando[2].ToString(), posicion = i });
                i++;
            }
            leer_jarmando.Close();
            return prductos;
        }
        public static List<EyMItem> llenarEyM(string strSQL)
        {
            List<EyMItem> leym = new List<EyMItem>();

            OrdenSql = new SqlCommand(strSQL, conectar_JArmando);
            leer_jarmando = OrdenSql.ExecuteReader();

            int i = 0;
            while (leer_jarmando.Read())
            {
                leym.Add(new EyMItem() { claveemp = leer_jarmando[0].ToString(), imagen = ((byte[])leer_jarmando[1]), texto = leer_jarmando[2].ToString(), identificador = i });
                i++;
            }
            leer_jarmando.Close();
            return leym;
        }

        public static List<EyMItem> llenarMesas(string strSQL)
        {
            List<EyMItem> leym = new List<EyMItem>();

            OrdenSql = new SqlCommand(strSQL, conectar_JArmando);
            leer_jarmando = OrdenSql.ExecuteReader();

            int i = 0;
            while (leer_jarmando.Read())
            {
                
                leym.Add(new EyMItem() { status = leer_jarmando[0].ToString(), imagen = ((byte[])leer_jarmando[1]), texto = leer_jarmando[2].ToString(), folioVent = leer_jarmando[3].ToString(), identificador = i });
                i++;
            }
            leer_jarmando.Close();
            return leym;
        }
        public static List<string> llenarClaveP(string strSQL)
        {
            List<string> clave = new List<string>();

            OrdenSql = new SqlCommand(strSQL, conectar_JArmando);
            leer_jarmando = OrdenSql.ExecuteReader();

            int i = 0;
            while (leer_jarmando.Read())
            {
                clave.Add(leer_jarmando[0].ToString());
                i++;
            }
            leer_jarmando.Close();
            return clave;
        }

        public static DataGridView llenarGrid2(DataGridView tabla, string strSQL)
        {
            OrdenSql = new SqlCommand(strSQL, conectar_JArmando);
            leer_jarmando = OrdenSql.ExecuteReader();
            while (leer_jarmando.Read())
            {
                tabla.Rows.Add();
                tabla.Rows[tabla.Rows.Count - 2].Cells[1].Value = leer_jarmando[0];
                tabla.Rows[tabla.Rows.Count - 2].Cells[2].Value = "$" + leer_jarmando[1];
            }
            leer_jarmando.Close();
            return tabla;
        }
        public static DataGridView llenarGrid3(DataGridView tabla, string strSQL)
        {
            OrdenSql = new SqlCommand(strSQL, conectar_JArmando);

            leer_jarmando = OrdenSql.ExecuteReader();
            while (leer_jarmando.Read())
            {
                tabla.Rows.Add();
                tabla.Rows[tabla.Rows.Count - 2].Cells[0].Value = leer_jarmando[1].ToString() == "" ? false : true;
                tabla.Rows[tabla.Rows.Count - 2].Cells[1].Value = leer_jarmando[0];
                tabla.Rows[tabla.Rows.Count - 2].Cells[2].Value = leer_jarmando[1];
                tabla.Rows[tabla.Rows.Count - 2].Cells[3].Value = leer_jarmando[2];
            }
            leer_jarmando.Close();
            return tabla;
        }
        public static DataGridView llenarGrid4(DataGridView tabla, string strSQL)
        {
            OrdenSql = new SqlCommand(strSQL, conectar_JArmando);

            leer_jarmando = OrdenSql.ExecuteReader();
            while (leer_jarmando.Read())
            {
                tabla.Rows.Add();
                tabla.Rows[tabla.Rows.Count - 2].Cells[1].Value = leer_jarmando[0];
                tabla.Rows[tabla.Rows.Count - 2].Cells[2].Value = leer_jarmando[1];
                tabla.Rows[tabla.Rows.Count - 2].Cells[3].Value = leer_jarmando[2];
                tabla.Rows[tabla.Rows.Count - 2].Cells[4].Value = leer_jarmando[3];
            }
            leer_jarmando.Close();
            return tabla;
        }
        public static DataTable ObtenerTablas(string st)
        {
            da = new SqlDataAdapter(st, conectar_JArmando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static void agregarImagen(string prod, byte[] img)
        {
            SqlCommand command = new SqlCommand(prod, conectar_JArmando);
            command.Parameters.AddWithValue("@imagen", img);
            command.ExecuteNonQuery();
        }
    }
}