using System;
using System.Collections.Generic;

namespace OpenShop
{
   
    class GestorVenta
    {
        static Carrito Carrito = new Carrito();

        static void Main(string[] args)
        {
            while (true)
            {
               MostrarProductos();

               var resultado = AgregarAlCarrito();
               if (!resultado)
               {
                   break;
               }
                System.Console.WriteLine("Seleccione 1 si desea seguir agregando productos al carrito o 2 si quiere pagar");
                var decision = System.Console.ReadLine();
                while (decision != "1" && decision !="2")
                {
                    System.Console.WriteLine("Seleccione 1 si desea seguir agregando productos al carrito o 2 si quiere pagar");
                    decision = System.Console.ReadLine();
                }
                
                if (decision == "2")
                {
                    break;
                }
            }

            System.Console.WriteLine("Seleccione 1 si desea pagar con debito o 2 con tarjeta de credito (6 cuotas)");
            var decision2 = System.Console.ReadLine();
            while (decision2 != "1" && decision2 !="2")
                {
                    System.Console.WriteLine("Seleccione 1 si desea pagar con debito o 2 con tarjeta de credito (6 cuotas)");
                    decision2 = System.Console.ReadLine();
                }
            var total = Carrito.precioTotalCarrito();
            if(decision2=="1")
            {
                System.Console.WriteLine($"Se le debitaron ${total}  de tu tarjeta");
            }
             if(decision2=="2")
            {
                decimal totalcuota;
                totalcuota= total/6;
                System.Console.WriteLine($"Su pago se efectuará en 6 cuotas de {totalcuota} a parti del proximo mes");
            }

            System.Console.WriteLine("Gracias por comprar");
        }

       static void MostrarProductos()
       {
           System.Console.WriteLine();
           System.Console.WriteLine();
           System.Console.WriteLine();

          foreach (var producto in RegistroProductos.Productos)
          {
              System.Console.WriteLine(producto.Nombre + "  $ " + producto.Precio);
          }
       }

        static bool AgregarAlCarrito()
        {
            System.Console.WriteLine("Seleccione un producto");
            var seleccion = System.Console.ReadLine();

            if (string.IsNullOrEmpty(seleccion))
            {
                return false;
            }

            var producto = RegistroProductos.Productos[int.Parse(seleccion) - 1];

            System.Console.WriteLine("¿Cantidad?");
            var cant = System.Console.ReadLine();

            if (string.IsNullOrEmpty(cant))
            {
                return false;
            }
            int cantidad = int.Parse(cant);
            Carrito.Agregar(producto, cantidad);
            Carrito.MostrarCarrito();

            return true;
        }
    }

    class RegistroProductos
    {
        public static List<Producto> Productos = new List<Producto>();

        static RegistroProductos()
        {
            Productos.Add(new Producto("Heladera", 50000));
            Productos.Add(new Producto("Celular", 249999.99m));
            Productos.Add(new Producto("Televisor", 22000));
            Productos.Add(new Producto("Microondas", 10000));
        }
    }

    class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad {get;set;}

        public Producto(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        public Producto(string nombre, decimal precio, int cantidad)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }
    }

    class Carrito
    {
        private List<Producto> Productos = new List<Producto>();

        public void Agregar(Producto producto, int cantidad)
        {
            bool productoYaComprado = false;
            foreach (var productoEnCarrito in Productos)
            {
                if(productoEnCarrito.Nombre==producto.Nombre)
                {
                    productoEnCarrito.Cantidad = productoEnCarrito.Cantidad + cantidad;
                    productoYaComprado=true;
                } 
            }
            if(productoYaComprado == false)
            {
                var NuevoProducto = new Producto(producto.Nombre,producto.Precio, cantidad);
                Productos.Add(NuevoProducto);
            }
        }

        public void MostrarCarrito()
        {
            System.Console.WriteLine("Tienes en tu carrito: ");

            foreach (var productoEnCarrito in Productos)
            {
                decimal precioTotal = productoEnCarrito.Precio*productoEnCarrito.Cantidad;
                System.Console.WriteLine($" {productoEnCarrito.Cantidad} x {productoEnCarrito.Nombre} {precioTotal}");
            }
        }

        public decimal precioTotalCarrito()
        {
            decimal total = 0;
            foreach (var productoEnCarrito in Productos)
            {
                decimal precioTotal = productoEnCarrito.Precio*productoEnCarrito.Cantidad;
                total = total + precioTotal;
            }
            return total;
        }
    }
}