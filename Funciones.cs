using System.Net; 
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RPG
{
    public class Funcion
    {
        public Datos CargarDatos(){
            var Datos = new Datos();
            string[] Tipos = new string[] { "Humano", "Duende", "Orco", "Elfo", "Enano", "Lycan", "Trol", "No-muerto", "Lizzard" };
            int opcion = 0;

            do
            {
                Console.WriteLine("Raza del personaje:\n1. Humano\n2. Duende\n3. Orco\n4. Elfo\n5. Enano\n6. Lycan\n7. Trol\n8. No-muerto\n9. Lizzard");
                opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            } while (opcion<1 || opcion>10);

            Datos.Tipo = Tipos[opcion-1];

            Console.WriteLine("Nombre: ");
            Datos.Nombre = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Apodo: ");
            Datos.Apodo = Convert.ToString(Console.ReadLine());


            Datos.FechaDeNacimiento = GenerarFecha();
            Datos.Edad = CalcularEdad(Datos.FechaDeNacimiento);
            Datos.Salud = (int)Maximos.SaludMax;
            Console.Clear();
            return Datos;
        }

        public Caracteristicas CargarCaracteristicas(){
            var Caracteristicas = new Caracteristicas();
            int puntos = 25;
            int pntAGastar = 0;


            Console.WriteLine("Ahora Tendras que elegir como gastar tus " + puntos + " puntos entre las diversas caracteristicas (Velocidad, Destreza, Fuerza, Nivel y Armadura)");
            Console.WriteLine("ENTER Para Continuar...");
            Console.ReadLine();
            Console.Clear();

            do
            {
                Console.WriteLine("Tienes " + puntos + " puntos para gastar");
                Console.WriteLine("Velocidad (0-9): ");
                pntAGastar = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            } while (pntAGastar<0 || pntAGastar>9 || pntAGastar>puntos);
            puntos -= pntAGastar;
            Caracteristicas.Velocidad = 1 + pntAGastar;

            do
            {
                Console.WriteLine("Te quedan " + puntos + " puntos para gastar");
                Console.WriteLine("Destreza (0-4): ");
                pntAGastar = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            } while (pntAGastar<0 || pntAGastar>4 || pntAGastar>puntos);
            puntos -= pntAGastar;
            Caracteristicas.Destreza = 1 + pntAGastar;

            do
            {
                Console.WriteLine("Te quedan " + puntos + " puntos para gastar");
                Console.WriteLine("Fuerza (0-9): ");
                pntAGastar = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            } while (pntAGastar<0 || pntAGastar>9 || pntAGastar>puntos);
            puntos -= pntAGastar;
            Caracteristicas.Fuerza = 1 + pntAGastar;

            do
            {
                Console.WriteLine("Te quedan " + puntos + " puntos para gastar");
                Console.WriteLine("Nivel (0-9): ");
                pntAGastar = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            } while (pntAGastar<0 || pntAGastar>9 || pntAGastar>puntos);
            puntos -= pntAGastar;
            Caracteristicas.Nivel = 1 + pntAGastar;

            do
            {
                Console.WriteLine("Te quedan " + puntos + " puntos para gastar");
                Console.WriteLine("Armadura (0-9): ");
                pntAGastar = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            } while (pntAGastar<0 || pntAGastar>9 || pntAGastar>puntos);
            puntos -= pntAGastar;
            Caracteristicas.Armadura = 1 + pntAGastar;

            return Caracteristicas;
        }
        public Datos CargarDatosAleatorios(){
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

            Datos.FechaDeNacimiento = GenerarFechaAleatoria();
            Datos.Edad = CalcularEdad(Datos.FechaDeNacimiento);
            Datos.Salud = (int)Maximos.SaludMax;

            return Datos;
        }
        public Caracteristicas CargarCaracteristicasAleatorias(int Escalado){
            var Caracteristicas = new Caracteristicas();

            Caracteristicas.Velocidad = new Random().Next(1, ((int)Maximos.VelocidadMax + Escalado));
            Caracteristicas.Destreza = new Random().Next(1, ((int)Maximos.DestrezaMax + Escalado));
            Caracteristicas.Fuerza = new Random().Next(1, ((int)Maximos.FuerzaMax + Escalado));
            Caracteristicas.Nivel = new Random().Next(1, ((int)Maximos.NivelMax + Escalado));
            Caracteristicas.Armadura = new Random().Next(1, ((int)Maximos.ArmaduraMax + Escalado));

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

        public bool GanadorAventura(Personaje PersonajePrincial,Personaje Enemigo){
            if (PersonajePrincial.Datos.Salud >= Enemigo.Datos.Salud)
            {
                PersonajePrincial.Datos.Salud = (int)Maximos.SaludMax;
                return true;
            }
            else if(Enemigo.Datos.Salud > PersonajePrincial.Datos.Salud)
            {
                PersonajePrincial.Datos.Salud = (int)Maximos.SaludMax;
                Enemigo.Datos.Salud = (int)Maximos.SaludMax;
                return false;
            }
            return true;
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
         public void ElegirRecompensa(Personaje PersonajePrincipal)
        {
            int opcion = 0;
            Console.Write("\n1. Velocidad + 4\n2. Destreza + 2\n3. Fuerza + 4\n4. Nievel + 4\n5. Armadura + 4\n\nIngresar la recompensa a elegir: ");
            do
            {
                opcion = Convert.ToInt32(Console.ReadLine());
            } while (opcion<1 || opcion>5);
            switch (opcion)
            {
                case 1:
                    PersonajePrincipal.Caracteristicas.Velocidad += 4;
                    Console.WriteLine("Su Personaje Ha Recibido + 4 puntos de Velocidad!");
                    break;
                case 2:
                    PersonajePrincipal.Caracteristicas.Destreza += 2;
                    Console.WriteLine("Su Personaje Ha Recibido + 2 puntos de Destreza!");
                    break;
                case 3:
                    PersonajePrincipal.Caracteristicas.Fuerza += 4;
                    Console.WriteLine("Su Personaje Ha Recibido + 4 puntos de Fuerza!");
                    break;
                case 4:
                    PersonajePrincipal.Caracteristicas.Nivel += 4;
                    Console.WriteLine("Su Personaje Ha Recibido + 4 Niveles!");
                    break;
                case 5:
                    PersonajePrincipal.Caracteristicas.Armadura += 4;
                    Console.WriteLine("Su Personaje Ha Recibido + 4 puntos de Armadura!");
                    break;
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
                int bandera=0,anotado=0;
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
                            anotado = 1;   // Otra bandera para verificar que ya se conto la victoria
                        }else
                        {
                            Linea.Ganadas = Convert.ToInt32(line[3]);
                        }
                        ListaDeLineas.Add(Linea);
                    }
                    bandera = 1;
                }

                if (anotado == 0)  // Si es que el ganador no estaba en el csv se lo añade
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
            int anio = 0, mes = 0, dia = 0;

            Console.WriteLine("Fecha De Nacimiento:");
            do
            {
                Console.Write("Anio (" + (anioActual-300) + "-" + (anioActual-18) +  "): ");
                anio = Convert.ToInt32(Console.ReadLine());
            } while (anio<anioActual-300 || anio>anioActual-18);

            do
            {
                Console.Write("Mes (1-12): ");
                mes = Convert.ToInt32(Console.ReadLine());
            } while (mes<1 || mes>12);
        
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
                case 1: 
                    do
                    {
                        Console.Write("Dia (1-31): ");
                        dia = Convert.ToInt32(Console.ReadLine());
                    } while (dia<1 || dia>31);
                break;
                case 2: 
                    do
                    {
                        Console.Write("Dia (1-30): ");
                        dia = Convert.ToInt32(Console.ReadLine());
                    } while (dia<1 || dia>30);
                break;
                case 3:
                    do
                    {
                        Console.Write("Dia (1-29): ");
                        dia = Convert.ToInt32(Console.ReadLine());
                    } while (dia<1 || dia>29);
                break;
                case 4:
                    do
                    {
                        Console.Write("Dia (1-28): ");
                        dia = Convert.ToInt32(Console.ReadLine());
                    } while (dia<1 || dia>28);
                break;
            }
            return new DateTime(anio, mes, dia);
        }
        public DateTime GenerarFechaAleatoria()
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

            return new DateTime(anio, mes, dia);
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

        public void MostrarPersonajesGuardados(List<AventuraGuardada> ListaDeAventuraGuardada){
            int i = 1; 
            foreach (var aventura in ListaDeAventuraGuardada)
            {
                Console.WriteLine(i + ". " + aventura.PersonajePrincipal.Datos.Nombre + " PISO N" + aventura.Piso);
                i++;
            }
        }

        public void GuardarYSalir(Personaje PersonajePrincipal, Personaje Enemigo, int Piso){
            if (File.Exists("Aventura.json") && new FileInfo("Aventura.json").Length > 0)
            {
                var StreamReader = new StreamReader("Aventura.json");
                var jsonString = StreamReader.ReadToEnd();
                StreamReader.Close();

                var ListaDeAventuraGuardada = JsonSerializer.Deserialize<List<AventuraGuardada>>(jsonString);

                var AventuraGuardada = new AventuraGuardada();

                AventuraGuardada.Enemigo = Enemigo;
                AventuraGuardada.PersonajePrincipal = PersonajePrincipal;
                AventuraGuardada.Piso = Piso;

                Console.WriteLine("Guardar en: ");
                MostrarPersonajesGuardados(ListaDeAventuraGuardada);
                Console.WriteLine(ListaDeAventuraGuardada.Count+1 + ". Guardado Nuevo");

                int guardarLugar = 0;
                do
                {
                    guardarLugar = Convert.ToInt32(Console.ReadLine());
                } while (guardarLugar<1 || guardarLugar>ListaDeAventuraGuardada.Count+1);

                if (guardarLugar == ListaDeAventuraGuardada.Count+1)
                {
                    ListaDeAventuraGuardada.Add(AventuraGuardada);
                }else
                {
                    ListaDeAventuraGuardada[guardarLugar-1] = AventuraGuardada;
                }

                jsonString = JsonSerializer.Serialize(ListaDeAventuraGuardada);
                using (var StreamWriter = new StreamWriter("Aventura.json"))
                {
                    StreamWriter.Write(jsonString);
                }
            }else
            {
                using (var Archivo = new FileStream("Aventura.json", FileMode.Create))
                {
                    var ListaDeAventuraGuardada = new List<AventuraGuardada>();
                    var AventuraGuardada = new AventuraGuardada();

                    AventuraGuardada.Enemigo = Enemigo;
                    AventuraGuardada.PersonajePrincipal = PersonajePrincipal;
                    AventuraGuardada.Piso = Piso;
                    ListaDeAventuraGuardada.Add(AventuraGuardada);

                    var jsonString = JsonSerializer.Serialize(ListaDeAventuraGuardada);
                    using (var StreamWriter = new StreamWriter(Archivo))
                    {
                        StreamWriter.Write(jsonString);
                    }
                }
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