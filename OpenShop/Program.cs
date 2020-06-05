using System;
using System.Collections.Generic;

namespace OpenShop
{
    class GestorVenta
    {
        static Carrito Carrito = new Carrito();
        static List<Venta> ventas = new List<Venta>();

        static void Main(string[] args)
        {
        while (true)
         {
            System.Console.WriteLine("¿Que desea hacer?\n 1-Vender \n 2-Preparar pedido");
            var eleccion = System.Console.ReadLine();
            while (eleccion != "1" && eleccion !="2")
                {
                    System.Console.WriteLine("¿Que desea hacer?\n 1-Vender \n 2-Preparar pedido");
                    eleccion = System.Console.ReadLine();
                }   
                if (eleccion == "1")
                {
                    while (true)
                    {
                        MostrarProductos();

                        var resultado = AgregarAlCarrito();
                        if (!resultado)
                        {
                            break;
                        }
                        System.Console.WriteLine("¿Que desea hacer?\n 1-Seguir agregando productos al carrito \n 2-Pagar");
                        var decision = System.Console.ReadLine();
                        while (decision != "1" && decision !="2")
                        {
                            System.Console.WriteLine("¿Que desea hacer?\n 1-Seguir agregando productos al carrito \n 2-Pagar");
                            decision = System.Console.ReadLine();
                        }
                        
                        if (decision == "2")
                        {
                            break;
                        }   
                    }

                    decimal total= Carrito.precioTotalCarrito();
                    var Venta= new Venta(total, Carrito.Productos);
                    Venta.metodoDePago();
                    Carrito.VaciarCarrito();
                    ventas.Add(Venta);

                    System.Console.WriteLine("Gracias por comprar"); 
                }   
                else 
                {
                    Console.Clear();
                    bool PedidosSinPreparar = false;
                    foreach(var venta in ventas)
                    {
                        if(venta.Preparado==false)
                        {
                            PedidosSinPreparar=true;
                            venta.MostrarPreparacionDeLaVenta();
                            venta.Preparado=true; 
                        }   
                    }
                    if(PedidosSinPreparar==false)
                    {
                        System.Console.WriteLine("No hay pedidos sin preparar");
                    }  
                    else 
                    {
                        System.Console.WriteLine("Se prepararon todos los pedidos");
                    }                 
                }  
         }
            
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
            var itemProducto = new ItemProducto(producto,cantidad);
            Carrito.Agregar(itemProducto);
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
    

        public Producto(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
    }
    class ItemProducto
    {
        public Producto Producto{get;set;}
        public int Cantidad {get;set;}

        public ItemProducto(Producto producto, int cantidad)
        {
            Producto = producto; 
            Cantidad = cantidad;
        }
    }

    class Carrito
    {
        public List<ItemProducto> Productos = new List<ItemProducto>();

        public void Agregar(ItemProducto itemProducto)
        {
            bool productoYaComprado = false;
            foreach (var productoEnCarrito in Productos)
            {
                if(productoEnCarrito.Producto.Nombre==itemProducto.Producto.Nombre)
                {
                    productoEnCarrito.Cantidad = productoEnCarrito.Cantidad + itemProducto.Cantidad;
                    productoYaComprado=true;
                } 
            }
            if(productoYaComprado == false)
            {                
                Productos.Add(itemProducto);
            }
        }

        public void MostrarCarrito()
        {
            System.Console.WriteLine("Tienes en tu carrito: ");

            foreach (var productoEnCarrito in Productos)
            {
                decimal precioTotal = productoEnCarrito.Producto.Precio*productoEnCarrito.Cantidad;
                System.Console.WriteLine($" {productoEnCarrito.Cantidad} x {productoEnCarrito.Producto.Nombre} {precioTotal}");
            }
        }

        public decimal precioTotalCarrito()
        {
            decimal total = 0;
            foreach (var productoEnCarrito in Productos)
            {
                decimal precioTotal = productoEnCarrito.Producto.Precio*productoEnCarrito.Cantidad;
                total = total + precioTotal;
            }
            return total;
        }

        public void VaciarCarrito()
        {
            Productos = new List<ItemProducto>();
        }
    }

    class Venta
    {
        public decimal Precio{get;set;}
        public List<ItemProducto> Productos {get;set;}
        public bool Preparado{get;set;}
        public int FormaDePago{get;set;}

        public Venta(decimal precio, List<ItemProducto> productos)
        {
           Precio = precio;
           Productos = productos;
           Preparado = false; 
        }

        public void metodoDePago()
        {
            System.Console.WriteLine("¿Que desea hacer?\n 1-Pagar con Debito \n 2-Pagar con tarjeta de credito (6 cuotas)");
            var decision2 = System.Console.ReadLine();
            while (decision2 != "1" && decision2 !="2")
                {
                    System.Console.WriteLine("¿Que desea hacer?\n 1-Pagar con Debito \n 2-Pagar con tarjeta de credito (6 cuotas)");
                    decision2 = System.Console.ReadLine();
                }
            var total = Precio;
            if(decision2=="1")
            {
                System.Console.WriteLine($"Se le debitaron ${total}  de tu tarjeta");
                FormaDePago=1;
            }
             if(decision2=="2")
            {
                decimal totalcuota;
                totalcuota= total/6;
                System.Console.WriteLine($"Su pago se efectuará en 6 cuotas de {totalcuota} a parti del proximo mes");
                FormaDePago=2;
            }
        }

        public void MostrarPreparacionDeLaVenta()
        {
            foreach(var item in Productos)
            {
                System.Console.WriteLine($"Preparando {item.Cantidad} {item.Producto.Nombre}");
            }
        }
    }
}