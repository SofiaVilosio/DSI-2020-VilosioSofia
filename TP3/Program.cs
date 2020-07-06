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
                    Console.WriteLine($"¿Que desea hacer?: \n 1- Inscribirte a un cruso \n 2- Registrar una persona \n 3- Agregar un curso nuevo \n 4-Agregar docente a curso \n 5- Salir");
                    decision = System.Console.ReadLine();
                }

                if (decision == "5")
                {
                    break;
                }

                if (decision == "1")
                {
                    //Elegir persona que quiere inscribirse
                    Console.WriteLine("La persona que quiere inscribirse es: \n 1-Alumno \n 2-Docente \n 3- Público general");
                    var decisionInscripcion = Console.ReadLine();
                    while (decisionInscripcion != "1" && decisionInscripcion != "2" && decisionInscripcion != "3")
                    {
                        Console.WriteLine("La persona que quiere inscribirse es: \n 1-Alumno \n 2-Docente \n 3- Público generla");
                        decisionInscripcion = Console.ReadLine();
                    }
                    Persona personaInscripta = null;
                    if (decisionInscripcion == "1")
                    {

                        if (RegistroAlumno.alumnos.Count() > 0)
                        {
                            //Mostrar alumnos
                            Console.WriteLine("Seleccione al alumno que quiere inscribir:");
                            MostrarAlumnos();
                            string alumnoElegido = Console.ReadLine();
                            int opcionalumnoElegido;
                            while (int.TryParse(alumnoElegido, out opcionalumnoElegido) == false)
                            {
                                Console.WriteLine("Marque una opción válida");
                            }
                            personaInscripta = RegistroAlumno.alumnos.ElementAt(opcionalumnoElegido - 1);
                            //FIN 

                        }
                        else
                        //NO HAY ALUMNOS...
                        {
                            RegistrarAlumno();
                            personaInscripta = RegistroAlumno.alumnos.ElementAt(0);
                        }
                        //FIN
                    }
                    if (decisionInscripcion == "2")
                    {

                        if (RegistroDocente.docentes.Count() > 0)
                        {
                            //MOSTRAR DOCENTES
                            Console.WriteLine("Seleccione al docente que quiere inscribir:");
                            MostrarDocentes();
                            string docenteElegido = Console.ReadLine();
                            int opciondocenteElegido;
                            while (int.TryParse(docenteElegido, out opciondocenteElegido) == false)
                            {
                                Console.WriteLine("Marque una opción válida");
                            }
                            personaInscripta = RegistroDocente.docentes.ElementAt(opciondocenteElegido - 1);
                            //FIN
                        }
                        else
                        //NO HAY DOCENTE...
                        {
                            RegistrarDocente();
                            personaInscripta = RegistroDocente.docentes.ElementAt(0);
                        }
                    }
                    if (decisionInscripcion == "3")
                    {
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
                            RegistrarPublico();
                            personaInscripta = RegistroPersona.personas.ElementAt(0);
                        }
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

                if (decision == "2")
                {
                    Console.WriteLine("Seleccione la condición de la persona: \n 1-Alumno \n 2-Docente \n 3- Público generla");
                    var decisionRegistro = Console.ReadLine();
                    while (decisionRegistro != "1" && decisionRegistro != "2" && decisionRegistro != "3")
                    {
                        Console.WriteLine("Seleccione la condición de la persona: \n 1-Alumno \n 2-Docente \n 3- Público generla");
                        decisionRegistro = Console.ReadLine();
                    }
                    //REGISTRO ALUMNO
                    if (decisionRegistro == "1")
                    {
                        RegistrarAlumno();
                    }
                    //REGISTRO DOCENTE
                    if (decisionRegistro == "2")
                    {
                        RegistrarDocente();
                    }
                    //REGISTRO PUBLICO GENERAL
                    if (decisionRegistro == "3")
                    {
                        RegistrarPublico();
                    }

                }
                if (decision == "3")
                {

                    //NOMBRE
                    Console.WriteLine("¿Nombre Del curso?");
                    string nombre = Console.ReadLine();
                    //DESCRIPCION
                    Console.WriteLine("¿Para quien está dirigido?");
                    string descripcion = Console.ReadLine();
                    Console.WriteLine("Ingrese el día, mes y hora de comienzo del curso (Ej: 01/03/2020 19:30)");
                    string formato = "dd/MM/yyyy";
                    List<DateTime> FechasDictado = new List<DateTime>();
                    DateTime fecha;
                    string fechaIngresada = Console.ReadLine();
                    bool cargarFechas = false;
                    do
                    {
                        while(DateTime.TryParseExact(fechaIngresada, formato, null,
                        DateTimeStyles.None, out fecha)==false)
                        {
                            Console.WriteLine("Ingrese el día, mes y hora de comienzo del curso (Ej: 01/03/2020)");
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
                        }
                        else
                        {
                            cargarFechas = false;
                        }
                    }while(cargarFechas == true);
                    
                    List<Docente> docentesDelCurso = new List<Docente>();
                    Docente docente;
                    bool cargarDocentes = true;
                    while (cargarDocentes == true)
                    {
                        //DOCENTE                        
                        if (RegistroDocente.docentes.Count() > 0)
                        {
                            //MOSTRAR DOCENTES
                            Console.WriteLine("Seleccione al docente que quiere inscribir:");
                            MostrarDocentes();
                            string docenteElegido = Console.ReadLine();
                            int opciondocenteElegido;
                            while (int.TryParse(docenteElegido, out opciondocenteElegido) == false)
                            {
                                Console.WriteLine("Marque una opción válida");
                            }
                            docente = RegistroDocente.docentes.ElementAt(opciondocenteElegido - 1);
                            docentesDelCurso.Add(docente);
                            //FIN
                        }
                        else
                        //NO HAY DOCENTE...
                        {
                            RegistrarDocente();
                            docente = RegistroDocente.docentes.ElementAt(0);
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
            }
        }
        public static void RegistrarAlumno()
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
            Console.WriteLine("¿Legajo?");
            var legajoElegido = Console.ReadLine();
            int legajo;
            while (int.TryParse(legajoElegido, out legajo) == false)
            {
                Console.WriteLine("Ingrese un numero");
            }
            Console.WriteLine("¿Carrera?");
            string carrera = Console.ReadLine();
            Console.WriteLine("Numero de telefono:");
            string telefono = Console.ReadLine();
            Console.WriteLine("¿Cual es su email?");
            string email = Console.ReadLine();

            Alumno alumno = new Alumno(nombre, dni, legajo, carrera, telefono, email);
            RegistroAlumno.alumnos.Add(alumno);
        }
        public static void RegistrarDocente()
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
            Console.WriteLine("¿Legajo Docente?");
            var legajoElegido = Console.ReadLine();
            int legajo;
            while (int.TryParse(legajoElegido, out legajo) == false)
            {
                Console.WriteLine("Ingrese un numero");
            }
            Console.WriteLine("¿Título?");
            string titulo = Console.ReadLine();
            Console.WriteLine("Numero de telefono:");
            string telefono = Console.ReadLine();
            Console.WriteLine("¿Cual es su email?");
            string email = Console.ReadLine();

            Docente docente = new Docente(nombre, dni, legajo, titulo, telefono, email);
            RegistroDocente.docentes.Add(docente);
        }
        public static void RegistrarPublico()
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

        static void MostrarAlumnos()
        {
            int id = 1;
            foreach (var alumno in RegistroAlumno.alumnos)
            {
                System.Console.WriteLine($"{id}- Nombre: {alumno.Nombre}, legajo {alumno.Legajo}");
                id = id + 1;
            }
        }

        static void MostrarDocentes()
        {
            int id = 1;
            foreach (var docente in RegistroDocente.docentes)
            {
                System.Console.WriteLine($"{id}- Nombre: {docente.Nombre}, legajo {docente.Legajo}");
                id = id + 1;
            }
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
                System.Console.WriteLine($"{id}- Nombre: {curso.Nombre}, Descripción {curso.Descripcion}, Fechas de dictado: {curso.FechasDictado}, Fecha limite de inscripción {curso.FechaLimite} Dictado por: {curso.Docentes}");
                id = id + 1;
            }
        }
    }

    public class Curso
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<DateTime> FechasDictado { get; set; }
        public List<Docente> Docentes { get; set; }
        public int CupoMax { get; set; }
        public int CupoMin { get; set; }
        public DateTime FechaLimite { get; set; }

        public Curso(string nombre, string descripcion, List<DateTime> fechasDictado, List<Docente> docentes, int cupoMax, int cupoMin, DateTime fechaLimite)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            fechasDictado = FechasDictado;
            Docentes = docentes;
            CupoMax = cupoMax;
            CupoMin = cupoMin;
            FechaLimite = fechaLimite;
        }
    }

    public class RegistroCurso
    {
        public static List<Curso> Cursos = new List<Curso>();

        static RegistroCurso()
        {
            List<DateTime> fechasDictado = new List<DateTime>();
            List<Docente> docentes = new List<Docente>();
            fechasDictado.Add(new DateTime(2020, 03, 20, 19, 00, 00));
            fechasDictado.Add(new DateTime(2020, 03, 27, 19, 00, 00));
            fechasDictado.Add(new DateTime(2020, 004, 04, 19, 00, 00));
            docentes.Add(new Docente("JP Ferreyra", 20256965, 45854, "Ing. En Sistemas de Información", "3564585654", "jpferreyra@gmail.com"));
            DateTime fechaLimite1 = new DateTime(2020, 03, 15);
            Cursos.Add(new Curso("Excel Basico", "Todo Publico", fechasDictado, docentes, 10, 30, fechaLimite1));
            fechasDictado.Clear();
            docentes.Clear();

            fechasDictado.Add(new DateTime(2020, 04, 10, 20, 30, 00));
            fechasDictado.Add(new DateTime(2020, 03, 17, 20, 30, 00));
            fechasDictado.Add(new DateTime(2020, 04, 24, 20, 30, 00));
            fechasDictado.Add(new DateTime(2020, 11, 24, 20, 30, 00));
            docentes.Add(new Docente("Pedro Perez", 14589658, 45869, "Ing. Electromecánico", "3564574585", "pedroperez@gmail.com"));
            DateTime fechaLimite2 = new DateTime(2020, 04, 05);
            Cursos.Add(new Curso("Electricidad industrial", "Todo Publico", fechasDictado, docentes, 5, 15, fechaLimite2));
            fechasDictado.Clear();
            docentes.Clear();

            fechasDictado.Add(new DateTime(2020, 07, 01, 19, 30, 00));
            fechasDictado.Add(new DateTime(2020, 07, 07, 19, 30, 00));
            fechasDictado.Add(new DateTime(2020, 07, 14, 19, 30, 00));
            docentes.Add(new Docente("Laura Alvarez", 28569856, 41256, "Contadora", "3564857545", "lauraalvarez@gmail.com"));
            DateTime fechaLimite3 = new DateTime(2020, 04, 05);
            Cursos.Add(new Curso("Asistente Administrativo", "Todo Publico", fechasDictado, docentes, 15, 40, fechaLimite3));
            fechasDictado.Clear();
            docentes.Clear();
        }
    }

    public class Docente : Persona
    {
        public int Legajo { get; set; }
        public string Titulo { get; set; }


        public Docente(string nombre, int dni, int legajo, string titulo, string telefono, string email) : base(nombre, dni, telefono, email)
        {
            Legajo = legajo;
            Titulo = titulo;
        }

    }

    public class RegistroDocente
    {
        public static List<Docente> docentes = new List<Docente>();
    }

    public class Alumno : Persona
    {

        public int Legajo { get; set; }
        public string Carrera { get; set; }



        public Alumno(string nombre, int dni, int legajo, string carrera, string telefono, string email) : base(nombre, dni, telefono, email)
        {
            Legajo = legajo;
            Carrera = carrera;
        }

    }

    class RegistroAlumno
    {
        public static List<Alumno> alumnos = new List<Alumno>();
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

