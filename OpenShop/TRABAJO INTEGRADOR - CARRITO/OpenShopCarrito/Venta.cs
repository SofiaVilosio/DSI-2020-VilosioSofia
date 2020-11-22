using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenShopCarrito
{
    public class Venta
    {
        public Cliente Cliente { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaVenta { get; set; }
        public List<ItemCarrito> ItemsCarritos { get; set; }

        public Venta(Cliente cliente, decimal monto, DateTime fechaVenta, List<ItemCarrito> itemsCarritos)
        {
            Cliente = cliente;
            Monto = monto;
            FechaVenta = fechaVenta;
            ItemsCarritos = itemsCarritos;
        }
    }

}
