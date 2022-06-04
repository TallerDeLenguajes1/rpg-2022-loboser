namespace RPG
{
    public class Funcion
    {
        public Datos CargarDatos(Datos Datos){
            string[] Tipos = new string[] { "Duende", "Humano", "Orco", "Elfo", "Enano", "Lycan", "Trol", "No-muerto", "Lizzard" };

            string[] NombresHombre = new string[] { "John", "Mike", "Charlie", "Gabriel", "Patrick", "Arthur", "Smith" };
            string[] NombresMujer = new string[] { "Ashley", "Nancy", "Abby", "Evie", "Johanna", "Sistine", "Amelia" };

            string[] Apodos = new string[] { "The Wrecker", "The Assassin", "The Stealthy", "The Dominator", "The Destroyer", "The Maniac", "The Ninja", "The Last Samurai", "The King", "The Emperator" };

            Datos.Tipo = Tipos[new Random().Next(9)];

            if (new Random().Next(1)==0)
            {
                Datos.Nombre = NombresHombre[new Random().Next(6)];
            }else
            {
                Datos.Nombre = NombresMujer[new Random().Next(6)];
                
            }

            Datos.Apodo = Apodos[new Random().Next(7)];

            Datos.FechaDeNacimiento = GenerarFecha();
            Datos.Edad = CalcularEdad(Datos.FechaDeNacimiento);
            Datos.Salud = (int)Maximos.SaludMax;

            return Datos;
        }

        public Caracteristicas CargarCaracteristicas(Caracteristicas Caracteristicas){
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
            "Fecha de Nacimiento: " + Personaje.Datos.FechaDeNacimiento + " \n" +
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

        public string Combate(Personaje Atacante, Personaje Defensor)
        {
            string Informe;
            int Daño = Atacante.Atacar(Defensor);
            if(Daño == 0){
                Informe = "INCREIBLEE!! " + Defensor.Datos.Nombre + " " + Defensor.Datos.Apodo + " a esquivado el atacaque de " + Atacante.Datos.Nombre + " " + Atacante.Datos.Apodo + "\n";
            }
            else if (Daño <= 5)
            {
                Informe = Atacante.Datos.Nombre + " " + Atacante.Datos.Apodo + " a tocado a " + Defensor.Datos.Nombre + " " + Defensor.Datos.Apodo + " haciendole " + Daño + " de daño" + "\n";
            }
            else if (Daño <= 10)
            {
                Informe = Atacante.Datos.Nombre + " " + Atacante.Datos.Apodo + " le ha hecho un rasguño a " + Defensor.Datos.Nombre + " " + Defensor.Datos.Apodo + " infligiendole " + Daño + " de daño" + "\n";
            }
            else if(Daño <= 20)
            {
                Informe = Atacante.Datos.Nombre + " " + Atacante.Datos.Apodo + " ha cortado a " + Defensor.Datos.Nombre + " " + Defensor.Datos.Apodo + " provocandole " + Daño + " puntos de daño" + "\n";
            }
            else
            {
                Informe = "OHH NOOO!! " + Atacante.Datos.Nombre + " " + Atacante.Datos.Apodo + " ha realizado un GOLPE CRITICO!! contra " + Defensor.Datos.Nombre + " " + Defensor.Datos.Apodo + " costandole " + Daño + " puntos de salud" + "\n";
            }
            return Informe;
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
    }
}