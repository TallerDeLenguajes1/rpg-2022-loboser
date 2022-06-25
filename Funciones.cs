using System.Net; 
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RPG
{
    public class Funcion
    {
        public Datos CargarDatos(){
            var Datos = new Datos();
            string[] Tipos = new string[] { "Duende", "Humano", "Orco", "Elfo", "Enano", "Lycan", "Trol", "No-muerto", "Lizzard" };

            //string[] NombresHombre = new string[] { "John", "Mike", "Charlie", "Gabriel", "Patrick", "Arthur", "Smith" };
            //string[] NombresMujer = new string[] { "Ashley", "Nancy", "Abby", "Evie", "Johanna", "Sistine", "Amelia" };

            string[] Apodos = new string[] { "The Wrecker", "The Assassin", "The Stealthy", "The Dominator", "The Destroyer", "The Maniac", "The Ninja", "The Last Samurai", "The King", "The Emperator" };

            Datos.Tipo = Tipos[new Random().Next(9)];

            Datos.Nombre = ObtenerNombreAleatorio();

            /*
            
            if (new Random().Next(1)==0)
            {
                Datos.Nombre = NombresHombre[new Random().Next(6)];
            }else
            {
                Datos.Nombre = NombresMujer[new Random().Next(6)];
            }

            */

            Datos.Apodo = Apodos[new Random().Next(7)];

            Datos.FechaDeNacimiento = GenerarFecha();
            Datos.Edad = CalcularEdad(Datos.FechaDeNacimiento);
            Datos.Salud = (int)Maximos.SaludMax;

            return Datos;
        }

        public Caracteristicas CargarCaracteristicas(){
            var Caracteristicas = new Caracteristicas();

            Caracteristicas.Velocidad = new Random().Next(1, (int)Maximos.VelocidadMax);
            Caracteristicas.Destreza = new Random().Next(1, (int)Maximos.DestrezaMax);
            Caracteristicas.Fuerza = new Random().Next(1, (int)Maximos.FuerzaMax);
            Caracteristicas.Nivel = new Random().Next(1, (int)Maximos.NivelMax);
            Caracteristicas.Armadura = new Random().Next(1, (int)Maximos.ArmaduraMax);

            return Caracteristicas;
        }

        public string MostrarDatos(Personaje Personaje)
        {
            string Datos = "DATOS \n\n" +
            "Tipo: " + Personaje.Datos.Tipo + " \n" +
            "Nombre: " + Personaje.Datos.Nombre + " " +
            Personaje.Datos.Apodo + " \n" +
            "Fecha de Nacimiento: " + Personaje.Datos.FechaDeNacimiento.Day + "/" + Personaje.Datos.FechaDeNacimiento.Month + "/" + Personaje.Datos.FechaDeNacimiento.Year + " \n" +
            "Edad: " + Personaje.Datos.Edad + " \n" +
            "Salud: " + Personaje.Datos.Salud + " \n";

            return Datos;
        }

        public string MostrarCaracteristicas(Personaje Personaje)
        {
            string Caracteristicas = "CARACTERISTICAS \n\n" +
            "Velocidad: " + Personaje.Caracteristicas.Velocidad + " \n" +
            "Destreza: " + Personaje.Caracteristicas.Destreza + " \n" +
            "Fuerza: " + Personaje.Caracteristicas.Fuerza + " \n" +
            "Nivel: " + Personaje.Caracteristicas.Nivel + " \n" +
            "Armadura: " + Personaje.Caracteristicas.Armadura + " \n";

            return Caracteristicas;
        }

        public void Combate(Personaje Atacante, Personaje Defensor)
        {
            if (Atacante.Datos.Salud>0)
            {
                int Daño = Atacante.Atacar(Defensor);
                if(Daño == 0){
                    Console.WriteLine("INCREIBLEE!! " + Defensor.Datos.Nombre + " " + Defensor.Datos.Apodo + " a esquivado el atacaque de " + Atacante.Datos.Nombre + " " + Atacante.Datos.Apodo + "\n");
                }
                else if (Daño <= 5)
                {
                    Console.WriteLine(Atacante.Datos.Nombre + " " + Atacante.Datos.Apodo + " a tocado a " + Defensor.Datos.Nombre + " " + Defensor.Datos.Apodo + " haciendole " + Daño + " de daño" + "\n");
                }
                else if (Daño <= 10)
                {
                    Console.WriteLine(Atacante.Datos.Nombre + " " + Atacante.Datos.Apodo + " le ha hecho un rasguño a " + Defensor.Datos.Nombre + " " + Defensor.Datos.Apodo + " infligiendole " + Daño + " de daño" + "\n");
                }
                else if(Daño <= 20)
                {
                    Console.WriteLine(Atacante.Datos.Nombre + " " + Atacante.Datos.Apodo + " ha cortado a " + Defensor.Datos.Nombre + " " + Defensor.Datos.Apodo + " provocandole " + Daño + " puntos de daño" + "\n");
                }
                else
                {
                    Console.WriteLine("OHH NOOO!! " + Atacante.Datos.Nombre + " " + Atacante.Datos.Apodo + " ha realizado un GOLPE CRITICO!! contra " + Defensor.Datos.Nombre + " " + Defensor.Datos.Apodo + " costandole " + Daño + " puntos de salud" + "\n");
                }
            }
        }

        public Personaje Ganador(Personaje Luchador1,Personaje Luchador2, List<Personaje> ListaDePersonajes){
            if (Luchador1.Datos.Salud > Luchador2.Datos.Salud)
            {
                Luchador1.Datos.Salud = (int)Maximos.SaludMax;
                ListaDePersonajes.Remove(Luchador2);
                return Luchador1;
            }
            else if(Luchador2.Datos.Salud > Luchador1.Datos.Salud)
            {
                Luchador2.Datos.Salud = (int)Maximos.SaludMax;
                ListaDePersonajes.Remove(Luchador1);
                return Luchador2;
            }
            else
            {
                Console.WriteLine("Esto es increibleee!! terminó en un empate!!, para desempatar se realizara un duelo de un golpe!!");

                Luchador1.Datos.Salud = (int)Maximos.SaludMax;
                Luchador2.Datos.Salud = (int)Maximos.SaludMax;

                Combate(Luchador1, Luchador2);
                Combate(Luchador2, Luchador1);

                return Ganador(Luchador1, Luchador2, ListaDePersonajes);
            }
        }

        public string RecompensaAleatoria(Personaje Ganador)
        {
            string recompensa;

            switch (new Random().Next(1,5))
            {
                case 1:
                    Ganador.Caracteristicas.Velocidad += 3;
                    recompensa = " y ha recibido un aumento de 3 puntos de VELOCIDAD como recompensa aleatoria!";
                    break;
                case 2:
                    Ganador.Caracteristicas.Destreza += 2;
                    recompensa = " y ha recibido un aumento de 2 puntos de DESTREZA como recompensa aleatoria!";
                    break;
                case 3:
                    Ganador.Caracteristicas.Fuerza += 3;
                    recompensa = " y ha recibido un aumento de 3 puntos de FUERZA como recompensa aleatoria!";
                    break;
                case 4:
                    Ganador.Caracteristicas.Nivel += 3;
                    recompensa = " y ha recibido un aumento de 3 NIVELES como recompensa aleatoria!";
                    break;
                case 5:
                    Ganador.Caracteristicas.Armadura += 3;
                    recompensa = " y ha recibido un aumento de 3 puntos de ARMADURA como recompensa aleatoria!";
                    break;
                default:
                    recompensa = "";
                    break;
            }
            return "\n" + Ganador.Datos.Nombre + " " + Ganador.Datos.Apodo + recompensa + "\n";
        }

        public void GanadorDelTronoDeHierro(Personaje Ganador){
            Console.WriteLine("\nEl Ganador y merecedor del Trono de Hierro es...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\nEs un " + Ganador.Datos.Tipo + " de " + Ganador.Datos.Edad + " años de edad!!...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(Ganador.Datos.Nombre.ToUpper() + " " + Ganador.Datos.Apodo.ToUpper() + " FELICIDADES!!!...");
        }

        public void EscribirGanadorEnArchivoCSV(Personaje Ganador){
            if (File.Exists("Ganador.csv") && new FileInfo("Ganador.csv").Length > 0)
            {
                int bandera=0,aux=0;
                string[] lineasDelArchivo = File.ReadAllLines("Ganador.csv");
                var ListaDeLineas = new List<Lineas>();

                foreach (var item in lineasDelArchivo)
                {
                    if (bandera!=0 && item !="")    // Bandera para evitar que ingrese la primera fila que seran los titulos de las columnas
                    {
                        string[] line = item.Split(';');

                        var Linea = new Lineas();

                        Linea.Nombre = line[1];
                        Linea.Apodo = line[2];
                        if (Ganador.Datos.Nombre == Linea.Nombre && Ganador.Datos.Apodo == Linea.Apodo)     //Si el ganador ya estaba en el .csv le añado su victoria actual
                        {
                            Linea.Ganadas = Convert.ToInt32(line[3]) + 1;
                            aux = 1;   // Otra bandera para verificar que ya se conto la victoria
                        }else
                        {
                            Linea.Ganadas = Convert.ToInt32(line[3]);
                        
                        }
                        ListaDeLineas.Add(Linea);
                    }
                    bandera = 1;
                }

                if (aux == 0)  // Si es que el ganador no estaba en el csv se lo añade
                {
                    var Linea = new Lineas();

                    Linea.Nombre = Ganador.Datos.Nombre;
                    Linea.Apodo = Ganador.Datos.Apodo;
                    Linea.Ganadas = 1;

                    ListaDeLineas.Add(Linea);
                }

                ListaDeLineas = ListaDeLineas.OrderByDescending(linea => linea.Ganadas).ToList();   // Ordeno la lista segun la cantidad de victorias en orden descendiente

                string[] nuevasLineas = new string[ListaDeLineas.LongCount()+1];
                nuevasLineas[0] = "Top;Nombre;Apodo;Victorias";

                int i = 1;
                foreach (var linea in ListaDeLineas)
                {
                    nuevasLineas[i] = i + ";" + linea.Nombre + ";" + linea.Apodo + ";" + linea.Ganadas;
                    i++;
                }
                File.WriteAllLines("Ganador.csv", nuevasLineas);
            }else
            {
                string[] nuevasLineas = {"Top;Nombre;Apodo;Victorias", 1 + ";" + Ganador.Datos.Nombre + ";" + Ganador.Datos.Apodo + ";" + 1};
                File.WriteAllLines("Ganador.csv", nuevasLineas);
            }
        }

        public DateTime GenerarFecha()
        {
            var anioActual = DateTime.Today.Year;
            var mesActual = DateTime.Today.Month;
            var diaActual = DateTime.Today.Day;

            int anio = new Random().Next(anioActual-300, anioActual-18);
            int mes = new Random().Next(1,12);
            int dia = 0;
            int aux = 0;

            switch (mes)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    aux = 1; break;
                case 4:
                case 6:
                case 9:
                case 11:
                    aux = 2; break;
                case 2:
                    if (Bisiesto(anio))
                    {
                        aux = 3;
                    }
                    else
                    {
                        aux = 4;
                    }
                    break;
            }

            switch (aux)
            {
                case 1: dia = new Random().Next(1,31); break;
                case 2: dia = new Random().Next(1,30); break;
                case 3: dia = new Random().Next(1,29); break;
                case 4: dia = new Random().Next(1, 28); break;
            }

            var FechaDeNacimiento = new DateTime(anio, mes, dia);
            return FechaDeNacimiento;
        }

        public bool Bisiesto(int anio)
        {
            if (Convert.ToInt32(anio) % 4 == 0 && Convert.ToInt32(anio) % 100 != 0 || Convert.ToInt32(anio) % 400 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CalcularEdad(DateTime FechaDeNacimiento){
            return DateTime.Today.AddTicks(-FechaDeNacimiento.Ticks).Year - 1;;
        }

        private static string ObtenerNombreAleatorio(){
            var url = $"https://random-names-api.herokuapp.com/random";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using(WebResponse response = request.GetResponse()){
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            Root Nombre = JsonSerializer.Deserialize<Root>(responseBody);
                            return Nombre.body.name;
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
    public class Lineas
    {
        int ganadas;
        string nombre,apodo;

        public int Ganadas { get => ganadas; set => ganadas = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
    }
}