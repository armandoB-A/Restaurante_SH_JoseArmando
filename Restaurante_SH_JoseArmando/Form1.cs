using Restaurante_SH_JoseArmando.FTNR;
using Restaurante_SH_JoseArmando.FTR;
using Restaurante_SH_JoseArmando.FTR.Pedidos;
using Restaurante_SH_JoseArmando.FTR.PedidosCarpeta;
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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConexioMaestra_Jarmando.Abrir_JArmando();
        }

        private void abrirIngrediente(object sender, EventArgs e)
        {
            Ingrediente ingred = new Ingrediente();
            ingred.Show();
        }

        private void abrirPlatillo(object sender, EventArgs e)
        {
            Platillo p = new Platillo();    
            p.Show();  
        }

        private void abrirReceta(object sender, EventArgs e)
        {
            Receta receta = new Receta();   
            receta.Show();
        }

        private void abrirCategorias(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();  
            categoria.Show();   
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Recetaa recetaa= new Recetaa();
            recetaa.Show(); 
        }

        private void abrirMesa(object sender, EventArgs e)
        {
            Mesa2 mesa = new Mesa2(); 
            mesa.Show();
        }

        private void abrirPuesto(object sender, EventArgs e)
        {
            Puesto puesto = new Puesto();   
            puesto.Show();
        }

        private void abrirRecetav(object sender, EventArgs e)
        {
            RecetaV1 recetaV1 = new RecetaV1(); 
            recetaV1.Show();
        }

        private void abrirPedidos(object sender, EventArgs e)
        {
        }

        private void abrir_prueba(object sender, EventArgs e)
        {
            InicioPedidos prueba = new InicioPedidos();   
            prueba.Show();
        }

        private void click_abrirR(object sender, EventArgs e)
        {
            PedidoDef recetaDefinitivo = new PedidoDef();
            recetaDefinitivo.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Mesero mesero = new Mesero();
            mesero.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
