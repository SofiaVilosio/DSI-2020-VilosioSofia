using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenShopCarrito
{
    public class Producto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public string NombreCategoria { get; set; }
        public string NombreTipoProducto { get; set; }


        public Producto(string idProducto, string nombre, string marca, decimal precio, string descripcion, int stock, string categoria, string tipoProducto)
        {
            Id = idProducto;
            Nombre = nombre;
            Marca = marca;
            Precio = precio;
            Descripcion = descripcion;
            Stock = stock;
            NombreCategoria = categoria;
            NombreTipoProducto = tipoProducto;
        }

        public Producto()
        {

        }
    }
}
