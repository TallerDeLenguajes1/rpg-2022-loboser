namespace RPG
{
    public enum Maximos
    {
        VelocidadMax = 10,
        DestrezaMax = 5,
        FuerzaMax = 10,
        NivelMax = 10,
        ArmaduraMax = 10,
        SaludMax = 100,
        DañoMax = 50000,
    }
    public class Personaje {
        public Datos Datos = new Datos();
        public Caracteristicas Caracteristicas = new Caracteristicas();

        public int Atacar(Personaje Defensor)
        {
            float PD = Caracteristicas.Destreza * Caracteristicas.Fuerza * Caracteristicas.Nivel;
            int ED = new Random().Next(20,50);      //Le reduzco algo para que sea mas "equilibrado" y no tan random el daño
            float VA = PD * ED;
            float PDEF = Defensor.Caracteristicas.Armadura * Defensor.Caracteristicas.Velocidad;
            int DañoProvocado = (int)((((VA * ED) - PDEF) / (int)Maximos.DañoMax) * 10);

            Defensor.Datos.Salud -= DañoProvocado; 
            return DañoProvocado;
        }
    }
    public class Datos {
        string tipo="", nombre="", apodo="";
        DateTime fechaDeNacimiento;
        int edad;     //  0 - 300
        int salud;  //  100

        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Salud { get => salud; set => salud = value; }

    }

    public class Caracteristicas {
        int velocidad, fuerza, nivel, armadura; //  1 - 10
        int destreza;  //  1 - 5

        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
    }
}