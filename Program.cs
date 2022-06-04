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

                NuevoPersonaje = Funcion.CargarDatos(NuevoPersonaje);
                NuevoPersonaje = Funcion.CargarCaracteristicas(NuevoPersonaje);

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

        }
    }
}