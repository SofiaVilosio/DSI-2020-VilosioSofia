using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.CodeDom.Compiler;

namespace OpenShopCarrito
{
    public partial class CarritoVisualizacion : Form
    {
        public decimal montoTotal;

        public CarritoVisualizacion()
        {
            InitializeComponent();
            RellenarDataGrid();
            montoTotal = CalculoPrecioTotal();
            PatronDTO.RegistroDatosCobranza.CargarDatosExistentes();
            buttonBorrarProducto.Enabled = false;
            buttonAgregarCantidad.Enabled = false;
        }
        public void RellenarDataGrid()
        {
            var itemCarritoSeleccionado = RegistroItemCarrito.itemsCarrito.Where(x => x.Carrito.IdCarrito == RegistroCliente.clienteLogueado.Carrito.IdCarrito).ToList();
            dataGridViewCarrito.DataSource = itemCarritoSeleccionado.Select(x => new
            {
                x.Producto.Id,
                x.Cantidad,
                x.Producto.Nombre,
                x.Producto.Marca,
                x.Producto.Precio,
                x.Producto.Descripcion
            }).ToList();

        }

        public decimal CalculoPrecioTotalProductos()
        {
            decimal precioTotalProductos = RegistroItemCarrito.itemsCarrito.Sum(x => x.Producto.Precio);
            labelPrecioTotalProductos.Text = $"$ {precioTotalProductos}";
            return precioTotalProductos;
        }

        public decimal CalculoPrecioEnvio()
        {
            decimal PRECIO_ENVIO = 400;
            labelPrecioEnvio.Text = $"$ {PRECIO_ENVIO}";
            return PRECIO_ENVIO;
        }

        public decimal CalculoPrecioTotal()
        {
            decimal precioProductos = CalculoPrecioTotalProductos();
            decimal precioEnvio = CalculoPrecioEnvio();
            decimal montoTotal = precioProductos + precioEnvio;
            labelTotalConEnvio.Text = $"$ {montoTotal}";

            return montoTotal;
        }

        private void buttonBorrarProducto_Click(object sender, EventArgs e)
        {

            int cantidadABorrar = 0;
            cantidadABorrar = ControlarCantidadABorrar();


            var seleccion = dataGridViewCarrito.SelectedRows[0];
            var idSeleccionado = seleccion.Cells[0].Value.ToString();
            var productoSeleccionado = RegistroItemCarrito.itemsCarrito.First(x => x.Producto.Id == idSeleccionado);

            if (cantidadABorrar == productoSeleccionado.Cantidad)
            {
                RegistroItemCarrito.itemsCarrito.Remove(productoSeleccionado);
            }
            else
            {
                productoSeleccionado.Cantidad = productoSeleccionado.Cantidad - cantidadABorrar;
            }


            RellenarDataGrid();
            dataGridViewCarrito.Update();
            dataGridViewCarrito.Refresh();
            RegistroItemCarrito.GuardarDatosEnJson();

            ICatalogoCarrito ventanaCatalogo = this.Owner as ICatalogoCarrito;
            if (ventanaCatalogo != null)
            {
                ventanaCatalogo.CalculoCantidadProductos();
            }
        }

        private void textBoxCantidadABorrar_TextChanged(object sender, EventArgs e)
        {
            ControlarCantidadABorrar();
        }

        public int ControlarCantidadABorrar()
        {

            int cantidadIngresada = 0;
            if (dataGridViewCarrito.SelectedRows.Count == 0)
            {
                errorProviderCantidadABorrar.SetError(textBoxCantidadABorrar, "Debe seleccionar un producto");
            }
            else
            {
                var seleccion = dataGridViewCarrito.SelectedRows[0];
                var idSeleccionado = seleccion.Cells[0].Value.ToString();
                var productoSeleccionado = RegistroItemCarrito.itemsCarrito.First(x => x.Producto.Id == idSeleccionado);
                buttonBorrarProducto.Enabled = false;
                if (string.IsNullOrWhiteSpace(textBoxCantidadABorrar.Text))
                {
                    errorProviderCantidadABorrar.SetError(textBoxCantidadABorrar, "Debe introducir cantidad");
                }
                else
                {
                    bool esNumero = int.TryParse(textBoxCantidadABorrar.Text.Trim(), out cantidadIngresada);
                    if (!esNumero)
                    {
                        errorProviderCantidadABorrar.SetError(textBoxCantidadABorrar, "Deben ser solo numeros");
                    }
                    else
                    {
                        if (productoSeleccionado.Cantidad < cantidadIngresada)
                        {
                            errorProviderCantidadABorrar.SetError(textBoxCantidadABorrar, "Usted tiene menos cantidad en el carrito");
                        }

                        else
                        {
                            buttonBorrarProducto.Enabled = true;
                            errorProviderCantidadABorrar.SetError(textBoxCantidadABorrar, "");
                        }

                    }
                }

            }
            return cantidadIngresada;
        }

        private void textBoxCambiarCantidad_TextChanged(object sender, EventArgs e)
        {
            ControlarCantidadAAgregar();
        }

        public int ControlarCantidadAAgregar()
        {
            int cantidadIngresada = 0;
            if (dataGridViewCarrito.SelectedRows.Count == 0)
            {
                errorProviderCantidadAAgregar.SetError(textBoxCantidadAAgregar, "Debe seleccionar un producto");
            }
            else
            {
                var seleccion = dataGridViewCarrito.SelectedRows[0];
                var idSeleccionado = seleccion.Cells[0].Value.ToString();
                var productoSeleccionado = RegistroItemCarrito.itemsCarrito.First(x => x.Producto.Id == idSeleccionado);
                buttonAgregarCantidad.Enabled = false;
                if (string.IsNullOrWhiteSpace(textBoxCantidadAAgregar.Text))
                {
                    errorProviderCantidadAAgregar.SetError(textBoxCantidadAAgregar, "Debe introducir cantidad");
                }
                else
                {
                    bool esNumero = int.TryParse(textBoxCantidadAAgregar.Text.Trim(), out cantidadIngresada);
                    if (!esNumero)
                    {
                        errorProviderCantidadAAgregar.SetError(textBoxCantidadAAgregar, "Deben ser solo numeros");
                    }
                    else
                    {
                        var cantidadEnItemCarrito = RegistroItemCarrito.itemsCarrito.Where(x => x.Producto.Id == productoSeleccionado.Producto.Id).Select(x => x.Cantidad).Sum();
                        if ((cantidadEnItemCarrito + cantidadIngresada) > productoSeleccionado.Producto.Stock)
                        {
                            errorProviderCantidadAAgregar.SetError(textBoxCantidadAAgregar, "No hay suficiente stock");
                        }
                        else
                        {
                            buttonAgregarCantidad.Enabled = true;
                            errorProviderCantidadAAgregar.SetError(textBoxCantidadAAgregar, "");
                        }

                    }
                }

            }
            return cantidadIngresada;
        }

        private void buttonCambiarCantidad_Click(object sender, EventArgs e)
        {
            int cantidadAAgregar = 0;
            cantidadAAgregar = ControlarCantidadAAgregar();


            var seleccion = dataGridViewCarrito.SelectedRows[0];
            var idSeleccionado = seleccion.Cells[0].Value.ToString();
            var productoSeleccionado = RegistroItemCarrito.itemsCarrito.First(x => x.Producto.Id == idSeleccionado);

            productoSeleccionado.Cantidad = productoSeleccionado.Cantidad + cantidadAAgregar;
            
            RellenarDataGrid();
            dataGridViewCarrito.Update();
            dataGridViewCarrito.Refresh();

            RegistroItemCarrito.GuardarDatosEnJson();

            ICatalogoCarrito ventanaCatalogo = this.Owner as ICatalogoCarrito;
            if (ventanaCatalogo != null)
            {
                ventanaCatalogo.CalculoCantidadProductos();

            }

        }
        private void buttonAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            GestorVenta();
            EnvioDatosACobranza();
            VaciarCarrito();
            RellenarDataGrid();
            dataGridViewCarrito.Update();
            dataGridViewCarrito.Refresh();

        }

        public void GestorVenta()
        {
            var clienteComprador = new Cliente();

            clienteComprador.Nombre = RegistroCliente.clienteLogueado.Nombre;
            clienteComprador.Apellido = RegistroCliente.clienteLogueado.Apellido;
            clienteComprador.Email = RegistroCliente.clienteLogueado.Email;
            clienteComprador.DNI = RegistroCliente.clienteLogueado.DNI;
            clienteComprador.Domicilio = RegistroCliente.clienteLogueado.Domicilio;
            clienteComprador.Provincia = RegistroCliente.clienteLogueado.Provincia;


            DateTime fechaVenta = DateTime.Now;
            decimal monto = CalculoPrecioTotal();
            var productosAComprar = new List<ItemCarrito>();
            var itemCarritoARecorrer = RegistroItemCarrito.itemsCarrito.Where(x => x.Carrito.IdCarrito == RegistroCliente.clienteLogueado.Carrito.IdCarrito).ToList();

            foreach (var itemsCarrito in itemCarritoARecorrer)
            {
                var productoitemCarrito = new ItemCarrito();
                productoitemCarrito.Producto = new Producto();
                productoitemCarrito.Producto.Id = itemsCarrito.Producto.Id;
                productoitemCarrito.Producto.Nombre = itemsCarrito.Producto.Nombre;
                productoitemCarrito.Producto.Descripcion = itemsCarrito.Producto.Descripcion;
                productoitemCarrito.Producto.Marca = itemsCarrito.Producto.Marca;
                productoitemCarrito.Producto.Precio = itemsCarrito.Producto.Precio;
                productoitemCarrito.Cantidad = itemsCarrito.Cantidad;

                productosAComprar.Add(productoitemCarrito);
            }

            Venta venta = new Venta(clienteComprador, monto, fechaVenta, productosAComprar);
            RegistroVenta.ventas.Add(venta);

        }

        public void EnvioDatosACobranza()
        {
            var clientes = RegistroCliente.clientes;

            var datosAExportar = new List<PatronDTO.DatosCobranza>();
            var productos = new List<PatronDTO.Producto>();

            foreach (var venta in RegistroVenta.ventas)
            {
                var datosCobranza = new PatronDTO.DatosCobranza();

                datosCobranza.Cliente = new PatronDTO.Cliente();
                datosCobranza.Cliente.Nombre = venta.Cliente.Nombre;
                datosCobranza.Cliente.Apellido = venta.Cliente.Apellido;
                datosCobranza.Cliente.Email = venta.Cliente.Email;
                datosCobranza.Cliente.Dni = venta.Cliente.DNI;
                datosCobranza.Cliente.Domicilio = venta.Cliente.Domicilio;
                datosCobranza.Cliente.Provincia = venta.Cliente.Provincia;

                datosCobranza.FechaVenta = venta.FechaVenta;
                datosCobranza.Monto = venta.Monto;


                var itemCarritoARecorrer = RegistroItemCarrito.itemsCarrito.Where(x => x.Carrito.IdCarrito == RegistroCliente.clienteLogueado.Carrito.IdCarrito).ToList();

                foreach (var itemsCarrito in itemCarritoARecorrer)
                {
                    var productosDatosCobranza = new PatronDTO.Producto();
                    productosDatosCobranza.IdProducto = itemsCarrito.Producto.Id;
                    productosDatosCobranza.Nombre = itemsCarrito.Producto.Nombre;
                    productosDatosCobranza.Descripción = itemsCarrito.Producto.Descripcion;
                    productosDatosCobranza.Marca = itemsCarrito.Producto.Marca;
                    productosDatosCobranza.Precio = itemsCarrito.Producto.Precio;
                    productosDatosCobranza.Cantidad = itemsCarrito.Cantidad;
                    productos.Add(productosDatosCobranza);
                }


                datosCobranza.Producto = productos;

                datosAExportar.Add(datosCobranza);
                PatronDTO.RegistroDatosCobranza.datosCobranzas.Add(datosCobranza);
            }

            var json = JsonConvert.SerializeObject(datosAExportar);

            PatronDTO.RegistroDatosCobranza.GuardarDatosEnJson();

            ConfirmacionCompra ventanaConfirmacionCompra = new ConfirmacionCompra();
            ventanaConfirmacionCompra.ShowDialog();
        }

        public void VaciarCarrito()
        {
            RegistroItemCarrito.itemsCarrito = RegistroItemCarrito.itemsCarrito.Where(x => x.Carrito.IdCarrito != RegistroCliente.clienteLogueado.Carrito.IdCarrito).ToList();
            RegistroItemCarrito.GuardarDatosEnJson();
        }


    }
}


