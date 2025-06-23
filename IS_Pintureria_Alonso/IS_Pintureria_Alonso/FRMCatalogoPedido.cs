using Aplicacion;
using Dominio;
using Servicios;
using Servicios.Login;
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
    public partial class FRMCatalogoPedido : Form
    {
        private StockBLL stockBLL;
        public List<Stock> listaStock;
        private ProductoBLL productoBLL;
        private CategoriaBLL categoriaBLL;
        private PedidoBLL pedidoBLL;

        public Pedido pedidoActual;

        Regex regexHex = new Regex(@"#(?:[0-9a-fA-F]{6})");
        public FRMCatalogoPedido()
        {
            InitializeComponent();
            stockBLL = new StockBLL();
            productoBLL = new ProductoBLL();
            categoriaBLL = new CategoriaBLL();
            pedidoBLL = new PedidoBLL();
            pedidoActual = null;
            listaStock = stockBLL.ListarStockPorSucursal(1); // Asumiendo que 1 es el ID de la sucursal actual
            dgvCatalogo.MultiSelect = false;
            dgvCatalogo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public FRMCatalogoPedido(int idSucursal)
        {
            InitializeComponent();
            stockBLL = new StockBLL();
            productoBLL = new ProductoBLL();
            categoriaBLL = new CategoriaBLL();
            pedidoBLL = new PedidoBLL();
            pedidoActual = null;
            listaStock = stockBLL.ListarStockPorSucursal(idSucursal); // Asumiendo que idSucursal es el ID de la sucursal actual
            dgvCatalogo.MultiSelect = false;
            dgvCatalogo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void FRMCatalogoPedido_Load(object sender, EventArgs e)
        {
            foreach (var stock in listaStock)
            {
                dgvCatalogo.Rows.Add(productoBLL.ObtenerProductoPorId(stock.IdProducto).Nombre, stock.IdProducto, productoBLL.ObtenerProductoPorId(stock.IdProducto).Precio, productoBLL.ObtenerProductoPorId(stock.IdProducto).Descripcion, categoriaBLL.ObtenerCategoriaPorId(productoBLL.ObtenerProductoPorId(stock.IdProducto).IdCategoria).Nombre);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = "#" + txtHexa.Text.Trim().ToLower();
            var filtro = listaStock.Where(p => regexHex.IsMatch(productoBLL.ObtenerProductoPorId(p.IdProducto).Descripcion ?? "") && (productoBLL.ObtenerProductoPorId(p.IdProducto).Descripcion.ToLower().Contains(textoBusqueda))).ToList();
            dgvCatalogo.Rows.Clear();
            foreach (var stock in filtro)
            {
                var producto = productoBLL.ObtenerProductoPorId(stock.IdProducto);
                var categoria = categoriaBLL.ObtenerCategoriaPorId(producto.IdCategoria);
                dgvCatalogo.Rows.Add(producto.Nombre, stock.IdProducto, producto.Precio, producto.Descripcion, categoria.Nombre);
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = txtNombre.Text.Trim().ToLower();
            if (listaStock == null) return;
            var filtro = listaStock.Where(p => productoBLL.ObtenerProductoPorId(p.IdProducto).Nombre.ToLower().Contains(textoBusqueda)).ToList();
            dgvCatalogo.Rows.Clear();
            foreach (var stock in filtro)
            {
                var producto = productoBLL.ObtenerProductoPorId(stock.IdProducto);
                var categoria = categoriaBLL.ObtenerCategoriaPorId(producto.IdCategoria);
                dgvCatalogo.Rows.Add(producto.Nombre, stock.IdProducto, producto.Precio, producto.Descripcion, categoria.Nombre);
            }

        }

        public void ActualizarCatalogo()
        {
            dgvCatalogo.Rows.Clear();
            foreach (var stock in listaStock)
            {
                var producto = productoBLL.ObtenerProductoPorId(stock.IdProducto);
                var categoria = categoriaBLL.ObtenerCategoriaPorId(producto.IdCategoria);
                dgvCatalogo.Rows.Add(producto.Nombre, stock.IdProducto, producto.Precio, producto.Descripcion, categoria.Nombre);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = textBox1.Text.Trim().ToLower();
            if (listaStock == null) return;
            var filtro = listaStock.Where(p => p.IdProducto.ToString().Contains(textoBusqueda));
            dgvCatalogo.Rows.Clear();
            foreach (var stock in filtro)
            {
                var producto = productoBLL.ObtenerProductoPorId(stock.IdProducto);
                var categoria = categoriaBLL.ObtenerCategoriaPorId(producto.IdCategoria);
                dgvCatalogo.Rows.Add(producto.Nombre, stock.IdProducto, producto.Precio, producto.Descripcion, categoria.Nombre);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarCatalogo();
        }

        private void dgvCatalogo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           var id =  dgvCatalogo.SelectedCells[1].Value.ToString().Trim();
            var categoria = dgvCatalogo.SelectedCells[4].Value.ToString().Trim();
            CrearPedido();
            FRMDatosProducto fRMDatosProducto = new FRMDatosProducto(id,categoria,pedidoActual);
            fRMDatosProducto.FormClosed += (s, args) => ActualizarCatalogo();
            fRMDatosProducto.FormClosed += (s, args) => this.Show();

            this.Hide();
            fRMDatosProducto.Show();
        }
        public Pedido CrearPedido()
        {
            if(pedidoActual == null)
            {
                pedidoActual = new Pedido
                {
                    Fecha = DateTime.Now,
                    Estado = 0,
                    Detalles = new List<DetallePedido>(),
                    IdUsuario = SessionManager.GetInstance.GetUsuario.GetID(),
                    Cliente = SessionManager.GetInstance.GetUsuario,
                    IdPedido = 0
                };
                return pedidoActual;
            }
            else
            {
                return pedidoActual;
            }

        }
    }
}
