using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenShopCarrito
{
    public class Carrito
    {
        public Guid IdCarrito { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public Carrito(Guid idCarrito, DateTime fechaCreacion, DateTime fechaModificacion)
        {
            IdCarrito = idCarrito;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
        }
    }
}
