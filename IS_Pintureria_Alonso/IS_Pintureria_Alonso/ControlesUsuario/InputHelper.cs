using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Pintureria_Alonso.ControlesUsuario
{
    public static class InputHelper
    {
        public static int? PedirCantidadProducto(string nombreProducto)
        {
            int cantidad;
            string input;
            do
            {
                input = Interaction.InputBox($"Ingrese la cantidad de '{nombreProducto}' que desea agregar:", "Cantidad de Producto", "1");
                if (string.IsNullOrWhiteSpace(input))
                {
                    return null; // Cancelado o vacío
                }
                if (int.TryParse(input, out cantidad) && cantidad > 0)
                {
                    return cantidad; // Cantidad válida
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Por favor, ingrese un número válido mayor que cero.", "Entrada Inválida", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }
            }
            while (true);

        }
    }
}
