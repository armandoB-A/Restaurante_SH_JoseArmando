using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_SH_JoseArmando
{
    internal class Mensajes_JArmando
    {      
        
        public static string mnsjAgregarnExito(string st)
        {
            return "Producto: " + st + ", agregado correctamente";
        }
        public static string mnsjActualizarExito(string st, string id)
        {
            return "Producto: " + st + ", con el ID: " + id + "" +
                        "\nactualizado correctamente";
        }
        public static string mnsjBorrarExito(string st, string id)
        {
            return "Producto: " + st + ", con el ID: " + id + "" +
                         "\nborrado correctamente";
        }
    }
}
