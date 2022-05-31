namespace RPG
{
    public class Personaje {
        public class Caracteristicas {
            int velocidad, fuerza, nivel, armadura; //  1 - 10
            int destreza;  //  1 - 5

            public Caracteristicas(int Velocidad,int Destreza, int Fuerza, int Nivel, int Armadura){
                velocidad = Velocidad;
                destreza = Destreza;
                fuerza = Fuerza;
                nivel = Nivel;
                armadura = Armadura;
                destreza = Destreza;
            }
        }
        public class Datos {
            string tipo, nombre, apodo;
            DateTime fechaDeNacimiento;
            int edad;     //  0 - 300
            int salud;    //  100

            public Datos(string Tipo, string Nombre, string Apodo, DateTime FechaDeNacimiento, int Edad, int Salud){
                tipo = Tipo;
                nombre = Nombre;
                apodo = Apodo;
                fechaDeNacimiento = FechaDeNacimiento;
                edad = Edad;
                salud = Salud;
            }
        }
    }
}