using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenShopCarrito
{
    public class ItemCarrito
    {
        public Carrito Carrito { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public ItemCarrito(Carrito carrito, Producto producto, int cantidad)
        {
            Carrito = carrito;
            Producto = producto;
            Cantidad = cantidad;
        }

        public ItemCarrito()
        {

        }

    }
}
