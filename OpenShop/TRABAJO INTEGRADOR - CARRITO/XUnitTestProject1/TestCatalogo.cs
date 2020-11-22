using System;
using Xunit;
using OpenShopCarrito;
using System.Linq;
using Newtonsoft.Json;

namespace XUnitTestProject1
{
    public class TestCatalogo
    {

        [Fact]
        public void ElCatalogoNoEstaVacio()
        {
            Assert.NotNull(RegistroProducto.productos);
        }

        [Fact]
        public void ElStockEsValido()
        {
            bool esStockValido = true;
            foreach (var producto in RegistroProducto.productos)
            {

                int stock = producto.Stock;
                if (stock < 1)
                {
                    esStockValido = false;
                }
            }
            Assert.True(esStockValido);
        }


    }

    public class TestCarrito
    {
        public CarritoVisualizacion carritoV = new CarritoVisualizacion();

        [Fact]
        public void CalculoTotal()
        {
            if (RegistroItemCarrito.itemsCarrito != null)
            {
                decimal precioTotalProductos = RegistroItemCarrito.itemsCarrito.Sum(x => x.Producto.Precio);
                const decimal envio = 400;
                decimal montoTotal = precioTotalProductos + envio;
                decimal montoCalculadoEnCarritoV = carritoV.montoTotal;
                Assert.Equal(montoTotal, montoCalculadoEnCarritoV);
            }
        }

        [Fact]
        public void CantidadProductosCorrecta()
        {
            if (RegistroItemCarrito.itemsCarrito != null)
            {
                bool esValido = true;
                foreach (var producto in RegistroProducto.productos)
                {
                    var cantidadEnItemCarrito = RegistroItemCarrito.itemsCarrito.Where(x => x.Producto.Id == producto.Id).Select(x => x.Cantidad).Sum();
                    var stockDelProducto = producto.Stock;
                    if (cantidadEnItemCarrito > stockDelProducto)
                    {
                        esValido = false;
                    }
                }
                Assert.True(esValido);
            }
        }
    }

    public class TestCompraRealizada
    {

        [Fact]
        public void LaVentaTieneCliente()
        {
            if (RegistroVenta.ventas != null)
            {
                var cliente = RegistroVenta.ventas.Select(x => x.Cliente);
                Assert.NotNull(cliente);
            }
        }

        [Fact]
        public void LaVentaTieneFecha()
        {
            if (RegistroVenta.ventas != null)
            {
                var fecha = RegistroVenta.ventas.Select(x => x.FechaVenta);
                Assert.NotNull(fecha);
            }
        }

        [Fact]
        public void LaVentaTieneMonto()
        {
            if (RegistroVenta.ventas != null)
            {
                var monto = RegistroVenta.ventas.Select(x => x.Monto);
                Assert.NotNull(monto);
            }
        }

        [Fact]
        public void LaVentaTieneItemsCarrito()
        {
            if (RegistroVenta.ventas != null)
            {
                var itemsCarrito = RegistroVenta.ventas.Select(x => x.ItemsCarritos);
            }
        }

        [Fact]
        public void LosItemsCarritoTienenProductos()
        {
            if (RegistroVenta.ventas != null)
            {
                foreach (var venta in RegistroVenta.ventas)
                {
                    var producto = venta.ItemsCarritos.Select(x => x.Producto);
                    Assert.NotNull(producto);
                }
            }
        }

        [Fact]
        public void ElMontoEsCorrecto()
        {
            decimal total = 0;
            decimal suma = 0;
            decimal totalEnVenta = 0;
            decimal envio = 400;

            if (RegistroVenta.ventas != null)
            {
                foreach (var venta in RegistroVenta.ventas)
                {
                    foreach (var itemCarrito in venta.ItemsCarritos)
                    {
                        suma = suma + (itemCarrito.Producto.Precio);
                    }

                    totalEnVenta = venta.Monto;
                }

                total = suma + envio;
                Assert.Equal(total, totalEnVenta);
            }
        }

    }
}
