using System;
using System.Collections.Generic;

namespace Ejemplo_Patrón_Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            Remera r1 = new Remera("Modal Urbana", "L", "Rojo", 41813725, DateTime.Now, 20);
            Remera r2 = new Remera("Algodon Sport", "M", "Amarillo", 38452000, DateTime.Now, 25);
            Remera r3 = new Remera("Algodon Sport", "M", "Amarillo", 14589658, DateTime.Now, 50);
            Remera r4 = new Remera("Modal Urbana", "L", "Verde", 56856965, DateTime.Now, 21);
            Remera r5 = new Remera("Modal Urbana", "L", "Rojo", 45125854, DateTime.Now, 35);

            r1.MostrarInformacionRemera();
            r2.MostrarInformacionRemera();
            r3.MostrarInformacionRemera();
            r4.MostrarInformacionRemera();
            r5.MostrarInformacionRemera();

            Console.ReadLine();
        }
    }

    //Clase que contiene propiedades en común, datos intrinsecos 
    public class ModeloRemera
    {
        public string Modelo { get; set; }
        public string Talle { get; set; }
        public string Color { get; set; }

        public ModeloRemera(string modelo, string talle, string color)
        {
            Modelo = modelo;
            Talle = talle;
            Color = color;
        }

        public virtual void MostrarCaracteristicas(String datosExtra)
        {
            Console.WriteLine(Modelo + " " + "Talle:" + Talle + " Color: " + Color + " " + "\n" + datosExtra + "\n");
        }
    }


    public class RemeraFactory
    {
        // El pool se encargará de almacenar las instancias de los objetos reutilizables
        private static Dictionary<string, ModeloRemera> pool = new Dictionary<string, ModeloRemera>();

        public static ModeloRemera GetRemera(string modelo, string talle, string color)
        {
            ModeloRemera v = null;

            // Si el modelo ya ha sido creado anteriormente, se recupera del pool
            if (pool.ContainsKey(modelo  + " " + talle + " " + color))
            {
                v = pool[modelo + " " + talle + " " + color];
                Console.WriteLine("\t* Recuperando del pool la remera " + modelo + " " + talle + " " + color);
            }
            else
            {
                v = new ModeloRemera(modelo, talle, color);
                // Se añade el objeto al pool: las sucesivas llamadas usarán este objeto en lugar de
                // instanciar uno nuevo
                pool.Add(modelo + " " + talle + " " + color, v);
            }
            
            Console.WriteLine("\t* Insertando en el pool la remera " + modelo + " " + talle + " " + color);            

            return v;
        }
    }

    public class Remera
    {
        // Los datos intrinsecos estarán encapsulados dentro de la clase ModeloRemera
        private ModeloRemera datosImplicitos;

        // Datos extrinsecos, son los que identifican a cada instancia de remera,
        // y no se comparten
        public int DniComprador { get; set; }
        public DateTime FechaDeCompra { get; set; }
        public int Edad { get; set; }

        // Propiedades de acceso a los elementos implícitos.
        // Recordemos que estos datos no deberían variar con el tiempo (son comunes a todas las
        // instancias) y, si lo hicieran, afectarían a todas las instancias.
        public string Modelo { get { return datosImplicitos.Modelo; } }
        public string Talle { get { return datosImplicitos.Talle; } }
        public string Color { get { return datosImplicitos.Color; } }

        // Constructor de la remera
        // Hace uso de la factoría para obtener (o generar, en caso de que no exista) la parte implícita de
        // los datos de la remera (modelo, talle y color)
        public Remera (string modelo, string talle, string color,                  // Datos implícitos
            int dniComprador, DateTime fechaDeCompra, int edad)       // Datos explícitos
        {
            // Instanciamos o referenciamos los datos implícitos a través de la factoría
            this.datosImplicitos = RemeraFactory.GetRemera(modelo, talle, color);

            // Asignamos los datos propios, exclusivos de este objeto
            DniComprador = dniComprador;
            FechaDeCompra = fechaDeCompra;
            Edad = edad;
        }

        // Método que accede tanto a datos implícitos como a datos explícitos
        public void MostrarInformacionRemera()
        {
            datosImplicitos.MostrarCaracteristicas(" Comprado por DNI: " + DniComprador +
                " (" + FechaDeCompra.ToShortDateString() +
                ") edad del comprador: " + Edad);
        }
    }


}
