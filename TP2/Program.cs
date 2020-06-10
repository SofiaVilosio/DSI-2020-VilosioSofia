using System;
using System.Collections.Generic;
using System.Linq;
namespace TP2
{
    class GestorCotizacion
    {
        static List<Cotizacion> Cotizaciones = new List<Cotizacion>();
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("¿Que desea hacer?: \n 1- Crear Cotizacion \n 2- Registrar un cliente \n 3- Salir");
                var decision= Console.ReadLine();
                while (decision != "1" && decision !="2" && decision !="3")
                {
                    Console.WriteLine("¿Que desea hacer?: \n 1- Crear Cotizacion \n 2- Registrar un cliente \n 3- Salir");
                    decision= System.Console.ReadLine();
                }   

                if(decision=="3")
                {
                    break;
                }

                if(decision=="2")
                {
                    //Pedir datos del cliente
                    Console.WriteLine("¿Nombre y Apellido?");
                    string nombre=Console.ReadLine();
                    Console.WriteLine("A que empresa pertenece?");
                    string empresa=Console.ReadLine();
                    Console.WriteLine("¿Cual es el domicilio de la obra?");
                    string domicilio=Console.ReadLine();
                    Console.WriteLine("¿Cual es su email?");
                    string email=Console.ReadLine();
                    Console.WriteLine("Numero de telefono:");
                    string telefono= Console.ReadLine();

                    Cliente cliente= new Cliente(nombre,empresa,domicilio,email,telefono);  
                    RegistroCliente.clientes.Add(cliente);
                }

                if(decision=="1")
                {
                    if(RegistroCliente.clientes.Count()==0)
                    {
                        Console.WriteLine("No hay ningun cliente cargado, registre uno manualmente");                        Console.WriteLine("¿Nombre y Apellido?");
                        string nombre=Console.ReadLine();
                        Console.WriteLine("A que empresa pertenece?");
                        string empresa=Console.ReadLine();
                        Console.WriteLine("¿Cual es el domicilio de la obra?");
                        string domicilio=Console.ReadLine();
                        Console.WriteLine("¿Cual es su email?");
                        string email=Console.ReadLine();
                        Console.WriteLine("Numero de telefono:");
                        string telefono= Console.ReadLine();

                        Cliente nuevoCliente= new Cliente(nombre,empresa,domicilio,email,telefono);  
                        RegistroCliente.clientes.Add(nuevoCliente);
                    }
                    //Pedir cliente
                    Console.WriteLine("Seleccione cliente que quiere realizarle la cotizacion:");
                    MostrarClientes();
                    string clienteElegido = Console.ReadLine();
                    int opcionClienteElegido;
                    while(int.TryParse(clienteElegido, out opcionClienteElegido)==false)
                    {
                        Console.WriteLine("Marque una opción válida");
                    }
                    var cliente=RegistroCliente.clientes.ElementAt(opcionClienteElegido-1);
                    //FIN 
                    //Pedir material
                    Console.WriteLine("¿Qué material desea?");
                    MostrarMateriales();
                    string materialElegido= Console.ReadLine();
                    int opcionMaterialElegida;
                    while(int.TryParse(materialElegido, out opcionMaterialElegida)==false)
                    {
                        Console.WriteLine("Marque una opción válida");
                    }
                    var material=RegistroMaterial.Materiales.ElementAt(opcionMaterialElegida-1);
                    //Fin Pedir Material
                    //Pedir Metros Cuadrados
                    Console.WriteLine("Cuantos metros cuadrados desea cubrir?");
                    var metrosCuadradosElegidos= Console.ReadLine();
                    double cantMetrosCuadrados;
                    while(double.TryParse(metrosCuadradosElegidos, out cantMetrosCuadrados)==false)
                    {
                        Console.WriteLine("Ingrese un numero");
                    }
                    //Fin
                    //Pedir Espesor
                    Console.WriteLine("¿Que espesor desea?");
                    MostrarEspesores();
                    var espesorElegido= Console.ReadLine();
                    int opcionEspesorElegido;
                    while(int.TryParse(espesorElegido, out opcionEspesorElegido)==false)
                    {
                        Console.WriteLine("Marque una opción válida");
                    }
                    var espesor=RegistroEspesor.Espesores.ElementAt(opcionEspesorElegido-1);
                    //Fin
                    
                    //Creo cotizacion
                    Cotizacion cotizacion= new Cotizacion(DateTime.Now,material,cantMetrosCuadrados,espesor,cliente);
                    cotizacion.MostrarCotización();
                    Cotizaciones.Add(cotizacion);
                }

            }
        }

        static void MostrarMateriales()
        {
            int id=1;
            foreach (var material in RegistroMaterial.Materiales)
            {
              System.Console.WriteLine($"{id}- {material.Descripcion} $Precio por Bolsa: {material.PrecioBolsa}");
                id=id+1;
            }
        }

        static void MostrarEspesores()
        {
            int id=1;
            foreach (var espesor in RegistroEspesor.Espesores)
            {
              System.Console.WriteLine($"{id}- {espesor.Descripcion} $Precio por metro Cuadrado: {espesor.PrecioMetroCuadrado}, Rendimiento por Bolsa: {espesor.RendimiendoPorBolsa}");
              id=id+1;
            }
        }

        static void MostrarClientes()
        {
            int id=1;
            foreach (var cliente in RegistroCliente.clientes)
            {
              System.Console.WriteLine($"{id}- Nombre: {cliente.Nombre}, de la empresa {cliente.Empresa}");
              id=id+1;
            }
        }
    }

    class Cotizacion
    {
        public DateTime Fecha{get;set;}
        public Material Material{get;set;}
        public double MetrosCuadrados{get;set;}
        public Espesor Espesor{get;set;}
        public Cliente Cliente {get;set;}
        public double Importe{
            get
            {
                double importe=0;
                importe= MetrosCuadrados*Espesor.PrecioMetroCuadrado + (MetrosCuadrados/Espesor.RendimiendoPorBolsa)*Material.PrecioBolsa;
                return importe;
            }
        }

        public Cotizacion (DateTime fecha, Material material, double metrosCuadrados,Espesor espesor, Cliente cliente)
        {
            Fecha=fecha;
            Material=material;
            MetrosCuadrados=metrosCuadrados;
            Espesor=espesor;
            Cliente=cliente;

        }

        public void MostrarCotización ()
        {
           Console.WriteLine($"Cliente {Cliente.Nombre}, perteneciente a {Cliente.Empresa}");
           Console.WriteLine($"su cotización es:\n Metros cuadrados: {MetrosCuadrados}. \n Material {Material.Descripcion}, de ${Material.PrecioBolsa} el precio de bolsa. \n Espesor: {Espesor.Descripcion}, de $ {Espesor.PrecioMetroCuadrado} cada metro cuadrado y un rendimiento de {Espesor.RendimiendoPorBolsa} bolsas. \n TOTAL A PAGAR {Importe}");
        }
    }

    class Material
    {
        public string Descripcion{get;set;}
        public double PrecioBolsa{get;set;}

        public Material(string descripcion, double precioBolsa)
        {
            Descripcion=descripcion;
            PrecioBolsa=precioBolsa;
        } 

    }

    class RegistroMaterial
    {
        public static List<Material> Materiales = new List<Material>();

        static RegistroMaterial()
        {
            Materiales.Add(new Material("Espuma de Poliuretano", 500));
            Materiales.Add(new Material("Poliestireno expandido", 550));
            Materiales.Add(new Material("Poliestireno extruido", 600));
        }
    }

    class Espesor
    {
        public string Descripcion{get;set;}
        public double PrecioMetroCuadrado{get;set;}
        public double RendimiendoPorBolsa{get;set;}

        public Espesor(string descripcion, double precioMetroCuadrado, double rendimientoPorBolsa)
        {
            Descripcion=descripcion;
            PrecioMetroCuadrado=precioMetroCuadrado;
            RendimiendoPorBolsa=rendimientoPorBolsa;
        } 

    }

    class RegistroEspesor
    {
        public static List<Espesor> Espesores= new List<Espesor>();

        static RegistroEspesor()
        {
            Espesores.Add(new Espesor("Aplicado en Pared 50 mm ", 53.60, 2.25));
            Espesores.Add(new Espesor("Aplicado en Pared 70 mm", 87.00, 3.15));
            Espesores.Add(new Espesor("Aplicado en Pared 100 mm", 117.49, 4.5));
            Espesores.Add(new Espesor("Aplicado en Pared 120 mm", 128.48, 5.4));
            Espesores.Add(new Espesor("Aplicado en Pared 160 mm", 143.05, 7.2));
            Espesores.Add(new Espesor("Aplicado en Pared 200 mm",180.79, 9.00));
        }
    }

    class Cliente
    {
        public string Nombre{get;set;}
        public string Empresa{get;set;}
        public string DomicilioObra{get;set;}
        public string Email{get;set;}
        public string Telefono{get;set;}

        public Cliente(string nombre, string empresa, string domicilioObra, string email, string telefono)
        {
            Nombre=nombre;
            Empresa=empresa;
            DomicilioObra=domicilioObra;
            Email=email;
            Telefono=telefono;
        }
    }

    class RegistroCliente
    {
        public static List<Cliente> clientes= new List<Cliente>();
    }

}
