// See https://aka.ms/new-console-template for more information
using System;

namespace RPG
{
    public class Program {
        public static void Main(string[] args)
        {
            var ListaDePersonajes = new List<Personaje>();
            var Funcion = new Funcion();
            int CantidadDePersonajes = 0;
            
            Console.WriteLine("Ingresar la Cantidad de Personajes que lucharan: ");
            CantidadDePersonajes = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < CantidadDePersonajes; i++)
            {
                Personaje NuevoPersonaje = new Personaje();

                NuevoPersonaje.Datos = Funcion.CargarDatos(NuevoPersonaje.Datos);
                NuevoPersonaje.Caracteristicas = Funcion.CargarCaracteristicas(NuevoPersonaje.Caracteristicas);

                ListaDePersonajes.Add(NuevoPersonaje);
            }

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

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(Funcion.Combate(Luchador1, Luchador2));
                    Console.WriteLine(Funcion.Combate(Luchador2, Luchador1));
                }

                Console.WriteLine("\nEl Ganador del combate es...");
                Console.ReadLine();

                Ganador = Funcion.Ganador(Luchador1, Luchador2, ListaDePersonajes);
                CantidadDePersonajes--;
                if (CantidadDePersonajes != 1)
                {
                    Console.WriteLine(Funcion.RecompensaAleatoria(Ganador));
                    Console.ReadLine();
                }
                Console.Clear();

            } while (CantidadDePersonajes>1);
            Console.WriteLine("\nEl Ganador y merecedor del Trono de Hierro es...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\nEs un " + Ganador.Datos.Tipo + " de " + Ganador.Datos.Edad + " años de edad!!...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(Ganador.Datos.Nombre.ToUpper() + " " + Ganador.Datos.Apodo.ToUpper() + " FELICIDADES!!!...");
        }
    }
}