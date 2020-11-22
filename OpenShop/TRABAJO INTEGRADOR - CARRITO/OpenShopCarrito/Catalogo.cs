using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenShopCarrito
{
    public partial class Catalogo : Form, ICatalogoCarrito
    {
        Carrito carrito;
        public Catalogo()
        {
            InitializeComponent();
            RegistroProducto.CargarDatosExistentes();
            dataGridViewCatalogo.DataSource = RegistroProducto.productos.Select(x=> new { x.Id, x.Nombre, x.Marca, x.Precio, x.Descripcion, x.Stock}).ToList();
            RegistroItemCarrito.CargarDatosExistentes();
            RellenarComboBox();
            buttonAgregarACarrito.Enabled = false;
            CalculoCantidadProductos();

        }

        public void textBoxPrecio1_TextChanged(object sender, EventArgs e)
        {
            controlarBotonFiltrarPrecio1();
        }

        public void textBoxPrecio2_TextChanged(object sender, EventArgs e)
        {
            controlarBotonFiltrarPrecio2();
        }

        public void controlarBotonFiltrarPrecio1()
        {
            if (checkBoxPrecio.Checked)
            {
                buttonFiltrar.Enabled = false;
                if (string.IsNullOrWhiteSpace(textBoxPrecio1.Text))
                {
                    errorProviderPrecio1.SetError(textBoxPrecio1, "Debe introducir un numero");
                }
                else
                {
                    double precio1Ingresado;
                    bool esNumero = double.TryParse(textBoxPrecio1.Text.Trim(), out precio1Ingresado);
                    if (!esNumero)
                    {
                        errorProviderPrecio1.SetError(textBoxPrecio1, "Deben ser solo numeros");
                    }
                    else
                    {
                        buttonFiltrar.Enabled = true;
                        errorProviderPrecio1.SetError(textBoxPrecio1, "");
                    }
                }
            }
        }

        public void controlarBotonFiltrarPrecio2()
        {
            if (checkBoxPrecio.Checked)
            {
                buttonFiltrar.Enabled = false;
                if (string.IsNullOrWhiteSpace(textBoxPrecio2.Text))
                {
                    errorProviderPrecio2.SetError(textBoxPrecio2, "Debe introducir un numero");
                }
                else
                {
                    double precio2Ingresado;
                    bool esNumero = double.TryParse(textBoxPrecio2.Text.Trim(), out precio2Ingresado);
                    if (!esNumero)
                    {
                        errorProviderPrecio2.SetError(textBoxPrecio2, "Deben ser solo numeros");
                    }
                    else
                    {
                        buttonFiltrar.Enabled = true;
                        errorProviderPrecio2.SetError(textBoxPrecio2, "");
                    }
                }
            }
        }

        public void RellenarComboBox()
        {
            var marcas = RegistroProducto.productos.Select(x => x.Marca).Distinct();
            comboBoxMarca.DataSource = marcas.ToArray();

            var tipoProductos = RegistroProducto.productos.Select(x => x.NombreTipoProducto).Distinct();
            comboBoxTipoProducto.DataSource = tipoProductos.ToArray();

            var categorias = RegistroProducto.productos.Select(x => x.NombreCategoria).Distinct();
            comboBoxCategoria.DataSource = categorias.ToArray();
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            if (checkBoxMarca.Checked || checkBoxTipoProducto.Checked || checkBoxCategoria.Checked || checkBoxPrecio.Checked)
            {
                string categoriaAFiltrar = string.Empty;
                string marcaAFiltrar = string.Empty;
                string TipoProductoAFiltrar = string.Empty;
                decimal precioDesde = 0;
                decimal precioHasta = 0;

                if (checkBoxMarca.Checked)
                {
                    marcaAFiltrar = comboBoxMarca.SelectedItem.ToString();
                }

                if (checkBoxTipoProducto.Checked)
                {
                    TipoProductoAFiltrar = comboBoxTipoProducto.SelectedItem.ToString();
                }

                if (checkBoxCategoria.Checked)
                {
                    categoriaAFiltrar = comboBoxCategoria.SelectedItem.ToString();
                }

                if (checkBoxPrecio.Checked)
                {
                    decimal precioUno = Convert.ToDecimal(textBoxPrecio1.Text);
                    decimal precioDos = Convert.ToDecimal(textBoxPrecio2.Text);

                    if (precioUno > precioDos)
                    {
                        precioDesde = precioDos;
                        precioHasta = precioUno;

                    }
                    else
                    {
                        precioDesde = precioUno;
                        precioHasta = precioDos;
                    }

                }

                var productosFiltrados = RegistroProducto.productos.Where(
                    x => (!checkBoxCategoria.Checked || (checkBoxCategoria.Checked && x.NombreCategoria == categoriaAFiltrar)) &&
                         (!checkBoxMarca.Checked || (checkBoxMarca.Checked && x.Marca == marcaAFiltrar)) &&
                        (!checkBoxTipoProducto.Checked || (checkBoxTipoProducto.Checked && x.NombreTipoProducto == TipoProductoAFiltrar)) &&
                         (!checkBoxPrecio.Checked || (x.Precio >= precioDesde && x.Precio <= precioHasta))).ToList();

                dataGridViewCatalogo.DataSource = productosFiltrados;
            }
        }

        private void buttonAgregarACarrito_Click(object sender, EventArgs e)
        {
            int cantidad=0;

            cantidad=controlarCantidad();

            carrito = RegistroCliente.clienteLogueado.Carrito;

            var seleccion = dataGridViewCatalogo.SelectedRows[0];
            var idSeleccionado= seleccion.Cells[0].Value.ToString();
            var productoSeleccionado = RegistroProducto.productos.First(x => x.Id == idSeleccionado);

            ItemCarrito itemCarrito = new ItemCarrito(carrito, productoSeleccionado, cantidad);
            RegistroItemCarrito.itemsCarrito.Add(itemCarrito);
            RegistroItemCarrito.GuardarDatosEnJson();

            CalculoCantidadProductos();

        }

        private void pictureBoxIrACarrito_Click(object sender, EventArgs e)
        {
            CarritoVisualizacion ventanaCarritoInterfaz = new CarritoVisualizacion();
            ventanaCarritoInterfaz.Show(this);
        }
        private void textBoxCantidadProducto_TextChanged(object sender, EventArgs e)
        {
            controlarCantidad();
        }

        public int controlarCantidad()
        {
            int cantidadIngresada = 0;
            
            if (dataGridViewCatalogo.SelectedRows.Count == 0)
            {
                errorProviderCantidad.SetError(textBoxCantidadProducto, "Debe seleccionar un producto");
            }
            else
            {  
                var seleccion = dataGridViewCatalogo.SelectedRows[0];
                var idSeleccionado = seleccion.Cells[0].Value.ToString();
                var productoSeleccionado = RegistroProducto.productos.First(x => x.Id == idSeleccionado);
                buttonAgregarACarrito.Enabled = false;
                if (string.IsNullOrWhiteSpace(textBoxCantidadProducto.Text))
                {
                    errorProviderCantidad.SetError(textBoxCantidadProducto, "Debe introducir cantidad");
                }
                else
                {
                    bool esNumero = int.TryParse(textBoxCantidadProducto.Text.Trim(), out cantidadIngresada);
                    if (!esNumero)
                    {
                        errorProviderCantidad.SetError(textBoxCantidadProducto, "Deben ser solo numeros");
                    }
                    else
                    {
                        if (productoSeleccionado.Stock < cantidadIngresada)
                        {
                            errorProviderCantidad.SetError(textBoxCantidadProducto, "No hay suficiente stock");
                        }
                        else
                        {
                            var itemCarritoSeleccionado = RegistroItemCarrito.itemsCarrito.Where(x => x.Carrito.IdCarrito == RegistroCliente.clienteLogueado.Carrito.IdCarrito).ToList();
                            var cantidadEnItemCarrito = itemCarritoSeleccionado.Where(x => x.Producto.Id == productoSeleccionado.Id).Select(x => x.Cantidad).Sum();
                            if ((cantidadEnItemCarrito + cantidadIngresada) > productoSeleccionado.Stock)
                            {
                                errorProviderCantidad.SetError(textBoxCantidadProducto, "No hay suficiente stock");
                            }
                            else
                            {
                                buttonAgregarACarrito.Enabled = true;
                                  errorProviderCantidad.SetError(textBoxCantidadProducto, "");
                            }
                        }

                    }
                }   
            }
            return cantidadIngresada;
        }

        public void CalculoCantidadProductos()
        {
            var itemCarritoSeleccionado = RegistroItemCarrito.itemsCarrito.Where(x => x.Carrito.IdCarrito == RegistroCliente.clienteLogueado.Carrito.IdCarrito).ToList();
            int cantidadProductos = itemCarritoSeleccionado.Sum(x => x.Cantidad);
            labelCantidadProductos.Text = $"{cantidadProductos}";
        }

        private void buttonAtrás_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
