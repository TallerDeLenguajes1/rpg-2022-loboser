// See https://aka.ms/new-console-template for more information
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace RPG
{
    public class Program {
        public static void Main(string[] args)
        {
            int Opcion = 0;
            do
            {
                Console.WriteLine("Seleccionar modo de juego:");
                Console.WriteLine("1. Aventura");
                Console.WriteLine("2. Todos Contra Todos");
                Opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (Opcion)
                {
                    case 1:
                        ModoAventura();
                    break;
                    case 2:
                        ModoTodosContraTodos();
                    break;
                    default:
                    break;
                }
            } while (Opcion<1 || Opcion>2);
        }

        public static void ModoAventura(){
            int salir = 1;
            int piso = 0;
            int opcion = 0;
            var Funcion = new Funcion();
            bool carga = false;
            int bandera = 0;

            var PersonajePrincipal = new Personaje();
            var Enemigo = new Personaje();

            do
            {
                Console.WriteLine("1. Crear Personaje");
                Console.WriteLine("2. Cargar Personajes Guardados");
                opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
    
                switch (opcion)
                {
                    case 1:
                        bandera = 0;
                        PersonajePrincipal.Datos = Funcion.CargarDatos();
                        PersonajePrincipal.Caracteristicas = Funcion.CargarCaracteristicas();
                        carga = false;
                    break;
                    case 2:
                        if (File.Exists("Aventura.json") && new FileInfo("Aventura.json").Length > 0)
                        {
                            bandera = 0;
                            var StreamReader = new StreamReader("Aventura.json");
                            var jsonString = StreamReader.ReadToEnd();
                            StreamReader.Close();

                            var ListaDeAventuraGuardada = JsonSerializer.Deserialize<List<AventuraGuardada>>(jsonString);
                            Funcion.MostrarPersonajesGuardados(ListaDeAventuraGuardada);

                            int seleccion = 0;
                            Console.Write("Ingresar numero de indice del personaje a cargar: ");
                            do
                            {
                                seleccion = Convert.ToInt32(Console.ReadLine());
                            } while (seleccion<1 || seleccion>ListaDeAventuraGuardada.Count);
                            
                            PersonajePrincipal = ListaDeAventuraGuardada[seleccion-1].PersonajePrincipal;
                            Enemigo = ListaDeAventuraGuardada[seleccion-1].Enemigo;
                            piso = ListaDeAventuraGuardada[seleccion-1].Piso;
                            carga = true;
                        }else
                        {
                            bandera = 1;
                            Console.WriteLine("El archivo Aventura.json no existe o esta vacio!");
                            Console.WriteLine("\nPresiona ENTER para volver a ingresar una opcion...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    break;
                }
            } while (opcion < 1 || opcion >2 || bandera == 1);

            do
            {
                if (!carga)
                {
                    Enemigo.Datos = Funcion.CargarDatosAleatorios();
                    Enemigo.Caracteristicas = Funcion.CargarCaracteristicasAleatorias(piso);
                }
                do
                {
                    Console.WriteLine("COMBATE EN EL PISO NUMERO " + piso + " CONTRA\n");
                    Console.WriteLine(Funcion.MostrarDatos(Enemigo));
                    Console.WriteLine(Funcion.MostrarCaracteristicas(Enemigo));
                    Console.WriteLine("\n1. Enfrentarlo\n2. Guardar y Salir");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                } while (opcion<1 || opcion > 2);

                if (opcion == 1)
                {
                    int i = 3;
                    while (PersonajePrincipal.Datos.Salud > 0 && Enemigo.Datos.Salud > 0 && i > 0)
                    {
                        Thread.Sleep(1000);
                        Funcion.Combate(PersonajePrincipal, Enemigo);
                        Thread.Sleep(1000);
                        Funcion.Combate(Enemigo, PersonajePrincipal);
                        i--;
                    }
                    
                    bool Ganador = Funcion.GanadorAventura(PersonajePrincipal, Enemigo);
                    if (Ganador)
                    {
                        carga = false;
                        Console.WriteLine("\nHas ganado y podras elegir tu recompensa!");
                        Thread.Sleep(1000);
                        Funcion.ElegirRecompensa(PersonajePrincipal);
                        Thread.Sleep(1000);
                    }else
                    {
                        Console.WriteLine("\nDerrota, podras intentarlo nuevamente en otra ocasion, podras guardar tu progreso a continuacion.");
                        Thread.Sleep(1000);
                        Funcion.GuardarYSalir(PersonajePrincipal, Enemigo, piso);
                        salir = 0;
                    }
                }else
                {
                    Funcion.GuardarYSalir(PersonajePrincipal, Enemigo, piso);
                    Console.WriteLine("\nGuardado con Exito!");
                    Thread.Sleep(1000);

                    salir = 0;
                }
                piso++;
            } while (salir != 0);
        }
        public static void ModoTodosContraTodos(){
            var ListaDePersonajes = new List<Personaje>();
            var Funcion = new Funcion();
            int cantidadDePersonajes = 0;
            string jsonString;
            int bandera = 0;
            int opcion = 0;

            do
            {
                Console.WriteLine("1. Crear Personajes Aleatoriamente");
                Console.WriteLine("2. Cargar Personajes desde Archivo Json");
                opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        bandera = 0;
                        Console.Write("Ingresar la Cantidad de Personajes que lucharan: ");
                        cantidadDePersonajes = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < cantidadDePersonajes; i++)
                        {
                            Personaje NuevoPersonaje = new Personaje();

                            NuevoPersonaje.Datos = Funcion.CargarDatosAleatorios();
                            NuevoPersonaje.Caracteristicas = Funcion.CargarCaracteristicasAleatorias(0);

                            ListaDePersonajes.Add(NuevoPersonaje);
                        }

                        using(var Archivo = new FileStream("Personajes.json", FileMode.Create)){
                            jsonString = JsonSerializer.Serialize(ListaDePersonajes);
                            using(var StreamWriter = new StreamWriter(Archivo)){
                                StreamWriter.Write(jsonString);
                            }
                        }
                    break;
                    case 2:
                        if (File.Exists("Personajes.json") && new FileInfo("Personajes.json").Length > 0)
                        {
                            bandera = 0;
                            using(var StreamReader = new StreamReader("personajes.json")){
                                jsonString = StreamReader.ReadToEnd();
                                ListaDePersonajes = JsonSerializer.Deserialize<List<Personaje>>(jsonString);
                            }
                        }else
                        {
                            bandera = 1;
                            Console.WriteLine("El archivo Personajes.json no existe o esta vacio!");
                            Console.WriteLine("\nPresiona ENTER para volver a ingresar una opcion...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    break;
                    default:
                    bandera = 0;
                    break;
                } 
            } while (opcion<1 || opcion>2 || bandera == 1);

            cantidadDePersonajes = ListaDePersonajes.Count;

            foreach (var personaje in ListaDePersonajes)
            {
                Console.WriteLine(Funcion.MostrarDatos(personaje));
                Console.WriteLine(Funcion.MostrarCaracteristicas(personaje));
            }
        

            Console.WriteLine("\nPresiona ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
            
            int rand1=0,rand2=0;
            Personaje Ganador, Luchador1, Luchador2;
            
            do
            {
                do
                {
                    rand1 = new Random().Next(cantidadDePersonajes);
                    rand2 = new Random().Next(cantidadDePersonajes);
                } while (rand1==rand2);

                Luchador1 = ListaDePersonajes[rand1];
                Luchador2 = ListaDePersonajes[rand2];

                int i = 3;
                while (Luchador1.Datos.Salud > 0 && Luchador2.Datos.Salud > 0 && i > 0)
                {
                    Thread.Sleep(1000);
                    Funcion.Combate(Luchador1, Luchador2);
                    Thread.Sleep(1000);
                    Funcion.Combate(Luchador2, Luchador1);
                    i--;
                }

                Console.WriteLine("\nEl Ganador del combate es...");
                Thread.Sleep(1000);


                Ganador = Funcion.Ganador(Luchador1, Luchador2, ListaDePersonajes);
                Funcion.EscribirGanadorEnArchivoCSV(Ganador);
                cantidadDePersonajes--;
                if (cantidadDePersonajes != 1)
                {
                    Console.WriteLine(Funcion.RecompensaAleatoria(Ganador));
                    Console.ReadLine();
                }
                Console.Clear();

            } while (cantidadDePersonajes>1);
            Funcion.GanadorDelTronoDeHierro(Ganador);
        }
    }
}