// See https://aka.ms/new-console-template for more information
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace RPG
{
    public class Program {
        public static void Main(string[] args)
        {
            var ListaDePersonajes = new List<Personaje>();
            var Funcion = new Funcion();
            int CantidadDePersonajes = 0;
            int Opcion = 0;

            string jsonString;
            int bandera = 0;

            do
            {
                Console.WriteLine("1. Crear Personajes Aleatoriamente");
                Console.WriteLine("2. Cargar Personajes desde Archivo json");
                Opcion = Convert.ToInt32(Console.ReadLine());

                switch (Opcion)
                {
                    case 1:
                        bandera = 1;
                        Console.Write("Ingresar la Cantidad de Personajes que lucharan: ");
                        CantidadDePersonajes = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < CantidadDePersonajes; i++)
                        {
                            Personaje NuevoPersonaje = new Personaje();

                            NuevoPersonaje.Datos = Funcion.CargarDatos();
                            NuevoPersonaje.Caracteristicas = Funcion.CargarCaracteristicas();

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
                            bandera = 1;
                            using(var StreamReader = new StreamReader("personajes.json")){
                                jsonString = StreamReader.ReadToEnd();
                                ListaDePersonajes = JsonSerializer.Deserialize<List<Personaje>>(jsonString);
                            }
                        }else
                        {
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
            } while (Opcion<1 || Opcion>2 || bandera == 0);

            CantidadDePersonajes = ListaDePersonajes.Count;

            for(int i = 0; i < CantidadDePersonajes; i++)
            {
                Console.WriteLine(Funcion.MostrarDatos(ListaDePersonajes[i]));
                Console.WriteLine(Funcion.MostrarCaracteristicas(ListaDePersonajes[i]));
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
                    rand1 = new Random().Next(CantidadDePersonajes);
                    rand2 = new Random().Next(CantidadDePersonajes);
                } while (rand1==rand2);

                Luchador1 = ListaDePersonajes[rand1];
                Luchador2 = ListaDePersonajes[rand2];

                int i = 3;
                while (Luchador1.Datos.Salud > 0 && Luchador2.Datos.Salud > 0 && i > 0)
                {
                    Funcion.Combate(Luchador1, Luchador2);
                    Funcion.Combate(Luchador2, Luchador1);
                    i--;
                }

                Console.WriteLine("\nEl Ganador del combate es...");
                Console.ReadLine();

                Ganador = Funcion.Ganador(Luchador1, Luchador2, ListaDePersonajes);
                Funcion.EscribirGanadorEnArchivoCSV(Ganador);
                CantidadDePersonajes--;
                if (CantidadDePersonajes != 1)
                {
                    Console.WriteLine(Funcion.RecompensaAleatoria(Ganador));
                    Console.ReadLine();
                }
                Console.Clear();

            } while (CantidadDePersonajes>1);
            Funcion.GanadorDelTronoDeHierro(Ganador);
        }
    }
}