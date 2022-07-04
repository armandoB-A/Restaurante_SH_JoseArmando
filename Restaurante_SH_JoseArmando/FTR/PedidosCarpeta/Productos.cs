using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_SH_JoseArmando.FTR
{
    internal class Productos
    {
        public int posicion
        {
            get;
            set;
        }
        public byte[] imagen { get; set; }
        public string nombre { get; set; }
        public string precio { get; set; }
    }
}
