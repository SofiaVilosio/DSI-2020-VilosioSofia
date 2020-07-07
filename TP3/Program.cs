using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace TP3
{
    class GestorCursos
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("¿Que desea hacer?: \n 1- Inscribir a un curso \n 2- Registrar una persona \n 3- Agregar un curso nuevo \n 4-Agregar docente a curso \n 5- Salir");
                var decision = Console.ReadLine();
                while (decision != "1" && decision != "2" && decision != "3" && decision != "4" && decision != "5")
                {
                    Console.WriteLine($"¿Que desea hacer?: \n 1- Inscribirte a un curso \n 2- Registrar una persona \n 3- Agregar un curso nuevo \n 4-Agregar docente a curso \n 5- Salir");
                    decision = System.Console.ReadLine();
                }
                //salir
                if (decision == "5")
                {
                    break;
                }
                //Inscribirse a un curso
                if (decision == "1")
                {   
                    Persona personaInscripta;
                    //MOSTRAR PUBLICO
                    if (RegistroPersona.personas.Count() > 0)
                    {
                        Console.WriteLine("Seleccione la persona que quiere inscribir:");
                        MostrarPersonas();
                        string personaElegido = Console.ReadLine();
                        int opcionpersonaElegido;
                        while (int.TryParse(personaElegido, out opcionpersonaElegido) == false)
                        {
                            Console.WriteLine("Marque una opción válida");
                        }
                        personaInscripta = RegistroPersona.personas.ElementAt(opcionpersonaElegido - 1);
                        //FIN
                    }
                    else
                    //REGISTRAR PUBLICO
                    {
                        RegistrarPersona();
                        personaInscripta = RegistroPersona.personas.ElementAt(0);
                    }
                
                    //FIN 

                    //ELEGIR CURSO
                    Console.WriteLine("A que curso quiere inscribirse?");
                    MostrarCursos();
                    string cursoElegido = Console.ReadLine();
                    int opcionCursoElegido;
                    while (int.TryParse(cursoElegido, out opcionCursoElegido) == false)
                    {
                        Console.WriteLine("Marque una opción válida");
                    }
                    var curso = RegistroCurso.Cursos.ElementAt(opcionCursoElegido - 1);
                    int cantInscriptos = RegistroInscripcion.Inscripciones.Count(x => x.Curso == curso);
                    if (cantInscriptos < curso.CupoMax)
                    {
                        Inscripcion inscripcion = new Inscripcion(curso, personaInscripta);
                        inscripcion.MostrarInscripcion();
                        RegistroInscripcion.Inscripciones.Add(inscripcion);
                    }
                    else
                    {
                        Console.WriteLine("No hay cupos para inscribirse");
                    }
                }
                //Registrar persona
                if (decision == "2")
                {
                     RegistrarPersona();
                }
                //Crear curso
                if (decision == "3")
                {

                    //NOMBRE
                    Console.WriteLine("¿Nombre Del curso?");
                    string nombre = Console.ReadLine();
                    //DESCRIPCION
                    Console.WriteLine("¿Para quien está dirigido?");
                    string descripcion = Console.ReadLine();
                    Console.WriteLine("Ingrese el día, mes y hora de comienzo del curso (Ej: 01/03/2020 19:30)");
                    string formato = "g";
                    var provider = new CultureInfo("fr-FR");
                    List<DateTime> FechasDictado = new List<DateTime>();
                    DateTime fecha;
                    string fechaIngresada = Console.ReadLine();
                    bool cargarFechas = false;
                    do
                    {
                        while(DateTime.TryParseExact(fechaIngresada, formato, provider,
                                                    DateTimeStyles.None, out fecha)==false)
                        {
                            Console.WriteLine("Ingrese el día, mes de la siguiente clase (Ej: 01/03/2020)");
                            fechaIngresada = Console.ReadLine();
                        }
                        FechasDictado.Add(fecha);
                        Console.WriteLine("¿Quiere ingresar mas fechas? \n 1-Si \n 2-No");
                        var opcionMasFechasIngresada = Console.ReadLine();
                        int opcionMasFechas;
                        do
                        {
                           while (int.TryParse(opcionMasFechasIngresada, out opcionMasFechas) == false)
                            {
                                Console.WriteLine("Ingrese 1 o 2");
                            }     
                        }while(opcionMasFechas != 1 && opcionMasFechas != 2);                        
                        if (opcionMasFechas == 1)
                        {
                            cargarFechas = true;
                            fechaIngresada = "";
                        }
                        else
                        {
                            cargarFechas = false;
                        }
                    }while(cargarFechas != false);
                    
                    List<Persona> docentesDelCurso = new List<Persona>();
                    Persona docente;
                    bool cargarDocentes = true;
                    while (cargarDocentes == true)
                    {
                        //DOCENTE                        
                        if (RegistroPersona.personas.Count() > 0)
                        {
                            //MOSTRAR DOCENTES
                            Console.WriteLine("Seleccione la persona que será docente del curso:");
                            MostrarPersonas();
                            string docenteElegido = Console.ReadLine();
                            int opciondocenteElegido;
                            while (int.TryParse(docenteElegido, out opciondocenteElegido) == false)
                            {
                                Console.WriteLine("Marque una opción válida");
                            }
                            docente = RegistroPersona.personas.ElementAt(opciondocenteElegido - 1);
                            docentesDelCurso.Add(docente);
                            //FIN
                        }
                        else
                        //NO HAY DOCENTE...
                        {
                            Console.WriteLine("Carga los datos del docente del curso");
                            RegistrarPersona();
                            docente = RegistroPersona.personas.ElementAt(0);
                            docentesDelCurso.Add(docente);
                        }
                        Console.WriteLine("¿Quiere ingresar mas docentes? \n 1-Si \n 2-No");
                        var masDocenteElegido = Console.ReadLine();
                        int masDocente;
                        do
                        {
                           while (int.TryParse(masDocenteElegido, out masDocente) == false)
                            {
                                Console.WriteLine("Ingrese 1 o 2");
                            }     
                        }while(masDocente != 1 && masDocente != 2);                        
                        if (masDocente == 1)
                        {
                            cargarDocentes = true;
                        }
                        else
                        {
                            cargarDocentes = false;
                        }
                    }

                    //cupo minimo
                    Console.WriteLine("¿Cupo Minimo?");
                    var cupoMinElegido = Console.ReadLine();
                    int cupoMin;
                    while (int.TryParse(cupoMinElegido, out cupoMin) == false)
                    {
                        Console.WriteLine("Ingrese un numero");
                        cupoMinElegido = Console.ReadLine();
                    }
                    //cupo maximo
                    Console.WriteLine("¿Cupo Maximo?");
                    var cupoMaxElegido = Console.ReadLine();
                    int cupoMax;
                    while (int.TryParse(cupoMaxElegido, out cupoMax) == false)
                    {
                        Console.WriteLine("Ingrese un numero");
                        cupoMaxElegido = Console.ReadLine();
                    }

                    Console.WriteLine("Ingrese la fecha límite de inscripción: (Ej:01/03/2020 )");
                    string fechaLimiteIngresada = Console.ReadLine();
                    string formatoFechaLimite = "dd/MM/yyyy";
                    DateTime fechaLimite;
                    while(DateTime.TryParseExact(fechaLimiteIngresada, formatoFechaLimite, null,
                        DateTimeStyles.None, out fechaLimite)==false)
                        {
                            Console.WriteLine("Ingrese la fecha límite de inscripción: (Ej: 01/03/2020)");
                            fechaLimiteIngresada = Console.ReadLine();
                        }
                    Curso curso = new Curso(nombre, descripcion, FechasDictado, docentesDelCurso, cupoMax, cupoMin, fechaLimite);
                    RegistroCurso.Cursos.Add(curso);
                }
                //Agregar docente suplente
                if (decision== "4")
                {
                    //CURSO
                    Console.WriteLine("A que curso le quiere agregar el docente?");
                    MostrarCursos();
                    string cursoElegido = Console.ReadLine();
                    int opcionCursoElegido;
                    while (int.TryParse(cursoElegido, out opcionCursoElegido) == false)
                    {
                        Console.WriteLine("Marque una opción válida");
                    }
                    var curso = RegistroCurso.Cursos.ElementAt(opcionCursoElegido - 1);

                    //PERSONA DOCENTE
                    Persona docenteSuplente;
                    //MOSTRAR PUBLICO
                    if (RegistroPersona.personas.Count() > 0)
                    {
                        Console.WriteLine("Seleccione la persona que quiere inscribir:");
                        MostrarPersonas();
                        string personaElegido = Console.ReadLine();
                        int opcionpersonaElegido;
                        while (int.TryParse(personaElegido, out opcionpersonaElegido) == false)
                        {
                            Console.WriteLine("Marque una opción válida");
                        }
                        docenteSuplente = RegistroPersona.personas.ElementAt(opcionpersonaElegido - 1);
                        //FIN
                    }
                    else
                    //REGISTRAR PUBLICO
                    {
                        RegistrarPersona();
                        docenteSuplente = RegistroPersona.personas.ElementAt(0);
                    }

                    curso.ActualizarDocente(docenteSuplente);
                    Console.WriteLine("El docente suplente se agregó correctamente");
                }
            }
        }
        
        public static void RegistrarPersona()
        {
            Console.WriteLine("¿Nombre y Apellido?");
            string nombre = Console.ReadLine();
            Console.WriteLine("¿DNI?");
            var dniElegido = Console.ReadLine();
            int dni;
            while (int.TryParse(dniElegido, out dni) == false)
            {
                Console.WriteLine("Ingrese un numero");
            }
            Console.WriteLine("Numero de telefono:");
            string telefono = Console.ReadLine();
            Console.WriteLine("¿Cual es su email?");
            string email = Console.ReadLine();

            Persona persona = new Persona(nombre, dni, telefono, email);
            RegistroPersona.personas.Add(persona);
        }

        static void MostrarPersonas()
        {
            int id = 1;
            foreach (var persona in RegistroPersona.personas)
            {
                System.Console.WriteLine($"{id}- Nombre: {persona.Nombre}, DNI {persona.Dni}");
                id = id + 1;
            }
        }

        static void MostrarCursos()
        {
            int id = 1;
            foreach (var curso in RegistroCurso.Cursos)
            {
                System.Console.WriteLine($"{id}- Curso: {curso.Nombre} , \n \t Dirigido a: {curso.Descripcion}, " +
                    $" \n \t Fecha limite de inscripción: {curso.FechaLimite}");
                Console.WriteLine("\n \t Docentes del curso:");
                foreach (Persona item in curso.Docentes)
                {
                    Console.WriteLine($"\t \t \t {item.Nombre}");
                }
                Console.WriteLine("\n \t Fechas de cursado:");
                foreach (DateTime item in curso.FechasDictado)
                {
                    Console.WriteLine(item.ToString("\t \t \t dd/MM/yyyy hh:mm"));
                }
                id = id + 1;
            }
        }
    }

    public class Curso
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<DateTime> FechasDictado { get; set; }
        public List<Persona> Docentes { get; set; }
        public int CupoMax { get; set; }
        public int CupoMin { get; set; }
        public DateTime FechaLimite { get; set; }

        public Curso(string nombre, string descripcion, List<DateTime> fechasDictado, List<Persona> docentes, int cupoMax, int cupoMin, DateTime fechaLimite)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            FechasDictado = fechasDictado;
            Docentes = docentes;
            CupoMax = cupoMax;
            CupoMin = cupoMin;
            FechaLimite = fechaLimite;
        }

        public void ActualizarDocente( Persona docente)
        {
            Docentes.Add(docente);
        }
    }

    public static class RegistroCurso
    {
        public static List<Curso> Cursos = new List<Curso>();

        static RegistroCurso()
        {
            List<DateTime> fechasDictado = new List<DateTime>();
            List<Persona> docentes = new List<Persona>();
            fechasDictado.Add(new DateTime(2020, 03, 20, 19, 00, 00));
            fechasDictado.Add(new DateTime(2020, 03, 27, 19, 00, 00));
            fechasDictado.Add(new DateTime(2020, 004, 04, 19, 00, 00));
            docentes.Add(new Persona("JP Ferreyra", 20256965, "3564585654", "jpferreyra@gmail.com"));
            DateTime fechaLimite1 = new DateTime(2020, 03, 15);
            Cursos.Add(new Curso("Excel Basico", "Todo Publico", fechasDictado, docentes, 10, 30, fechaLimite1));


            List<DateTime> fechasDictado2 = new List<DateTime>();
            List<Persona> docentes2 = new List<Persona>();
            fechasDictado2.Add(new DateTime(2020, 04, 10, 20, 30, 00));
            fechasDictado2.Add(new DateTime(2020, 03, 17, 20, 30, 00));
            fechasDictado2.Add(new DateTime(2020, 04, 24, 20, 30, 00));
            fechasDictado2.Add(new DateTime(2020, 11, 24, 20, 30, 00));
            docentes2.Add(new Persona("Pedro Perez", 14589658, "3564574585", "pedroperez@gmail.com"));
            DateTime fechaLimite2 = new DateTime(2020, 04, 05);
            Cursos.Add(new Curso("Electricidad industrial", "Todo Publico", fechasDictado2, docentes2, 5, 15, fechaLimite2));

            List<DateTime> fechasDictado3 = new List<DateTime>();
            List<Persona> docentes3 = new List<Persona>();
            fechasDictado3.Add(new DateTime(2020, 07, 01, 19, 30, 00));
            fechasDictado3.Add(new DateTime(2020, 07, 07, 19, 30, 00));
            fechasDictado3.Add(new DateTime(2020, 07, 14, 19, 30, 00));
            docentes3.Add(new Persona("Laura Alvarez", 28569856, "3564857545", "lauraalvarez@gmail.com"));
            DateTime fechaLimite3 = new DateTime(2020, 04, 05);
            Cursos.Add(new Curso("Asistente Administrativo", "Todo Publico", fechasDictado3, docentes3, 15, 40, fechaLimite3));
            
        }
    }

    public class Persona
    {
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }


        public Persona(string nombre, int dni, string telefono, string email)
        {
            Nombre = nombre;
            Dni = dni;
            Telefono = telefono;
            Email = email;
        }

    }

    public class RegistroPersona
    {
        public static List<Persona> personas = new List<Persona>();
    }

    public class Inscripcion
    {
        public Curso Curso { get; set; }
        public Persona Persona { get; set; }

        public Inscripcion(Curso curso, Persona persona)
        {
            Curso = curso;
            Persona = persona;
        }

        public void MostrarInscripcion()
        {
            Console.WriteLine($"Inscripto {Persona.Nombre}, al curso {Curso.Nombre}");
        }

    }

    static class RegistroInscripcion
    {
        public static List<Inscripcion> Inscripciones = new List<Inscripcion>();
    }
}

