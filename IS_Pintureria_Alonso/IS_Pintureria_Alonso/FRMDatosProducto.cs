using Aplicacion;
using Dominio;
using IS_Pintureria_Alonso.ControlesUsuario;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_Pintureria_Alonso
{
    public partial class FRMDatosProducto : Form
    {
        ProductoBLL productoBLL;
        CategoriaBLL categoriaBLL;
        LataPinturaBLL lataPinturaBLL;
        DetallePedidoBLL detallePedidoBLL;
        PedidoBLL pedidoBLL;
        string codigoProducto;
        string categoriaProducto;
        Pedido pedidoactual;

        public FRMDatosProducto(string codigo, string categoria, Pedido pedido)
        {
            InitializeComponent();
            pedidoBLL = new PedidoBLL();
            productoBLL = new ProductoBLL();
            categoriaBLL = new CategoriaBLL();
            lataPinturaBLL = new LataPinturaBLL();
            detallePedidoBLL = new DetallePedidoBLL();
            codigoProducto = codigo;
            categoriaProducto = categoria;
            pedidoactual = pedido;
        }

        private void FRMDatosProducto_Load(object sender, EventArgs e)
        {
            if (categoriaProducto.ToLower() == "pinturas")
            {
                LataPintura lata = lataPinturaBLL.ObtenerLataPinturaPorId(Convert.ToInt32(codigoProducto));
                lblNombreProd.Text = lata.Nombre;
                lblPrecioProd.Text = lata.Precio.ToString("C2");
                lblDescripcion.Text = lata.Descripcion ?? "No disponible";
                lblColor.Text = lata.Color;
                lblCapacidad.Text = lata.CapacidadL.ToString() + " L";
                lblMarca.Text = lata.Marca;
                lblTipoPintura.Text = lata.TipoBase ?? "No disponible";
                lblCategoria.Text = categoriaBLL.ObtenerCategoriaPorId(lata.IdCategoria).Nombre;
                Color color = HexAColor(ObtenerCodigoHex(lata.Descripcion));
                pnlColor.BackColor = color;

            }
            else
            {
                Producto producto = productoBLL.ObtenerProductoPorId(Convert.ToInt32(codigoProducto));
                lblNombreProd.Text = producto.Nombre;
                lblPrecioProd.Text = producto.Precio.ToString("C2");
                lblDescripcion.Text = producto.Descripcion ?? "No disponible";
                lblCategoria.Text = categoriaBLL.ObtenerCategoriaPorId(producto.IdCategoria).Nombre;
                lblTipoTipo.Visible = false;
                lblColorColor.Visible = false;
                lblCapacidadCapacidad.Visible = false;
                lblMarcaMarca.Visible = false;
                lblLitros.Visible = false;
                lblLitrosResultado.Visible = false;
                textBox1.Visible = false;
                lblRendimiento.Visible = false;
                lblM2.Visible = false;

            }
        }
        public string ObtenerCodigoHex(string descripcion)
        {
            if (string.IsNullOrEmpty(descripcion))
                return null;

            var match = Regex.Match(descripcion, @"#[0-9a-fA-F]{6}");
            return match.Success ? match.Value : null;
        }
        public Color HexAColor(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                return Color.Transparent;

            return ColorTranslator.FromHtml(hex);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out decimal metros) && metros > 0)
            {
                decimal metrosValidos = metros;
                decimal rendimiento;
                decimal litrosnecesarios;


                switch (lblTipoPintura.Text)
                {

                    case "Sintética":

                        rendimiento = 11; // Rendimiento en m² por litro
                        litrosnecesarios = metrosValidos / rendimiento;
                        lblLitrosResultado.Text = litrosnecesarios.ToString("N2") + "Lts";


                        break;

                    case "Latex":

                        rendimiento = 13; // Rendimiento en m² por litro
                        litrosnecesarios = metros / rendimiento;
                        lblLitrosResultado.Text = litrosnecesarios.ToString("N2") + "Lts";


                        break;

                    case "Antimoho":


                        rendimiento = 10; // Rendimiento en m² por litro
                        litrosnecesarios = metros / rendimiento;
                        lblLitrosResultado.Text = litrosnecesarios.ToString("N2") + "Lts";


                        break;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DetallePedido detalle = new DetallePedido
            {
                IdProducto = Convert.ToInt32(codigoProducto),
                Cantidad = Convert.ToInt32(InputHelper.PedirCantidadProducto(lblNombreProd.Text)),
                PrecioUnitario = Convert.ToDecimal(productoBLL.ObtenerProductoPorId(Convert.ToInt32(codigoProducto)).Precio),
                IdPedido = pedidoactual.IdPedido,
                Producto = productoBLL.ObtenerProductoPorId(Convert.ToInt32(codigoProducto)),
            };
            pedidoactual.Detalles.Add(detalle);
            this.Close();
        }
    }
}
