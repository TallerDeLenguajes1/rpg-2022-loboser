namespace RPG
{
    public class Personaje {
        public class Caracteristicas {
            int velocidad, fuerza, nivel, armadura; //  1 - 10
            int destreza;  //  1 - 5
        }
        public class Datos {
            string tipo, nombre, apodo;
            DateTime fechaDeNacimiento;
            int edad;     //  0 - 300
            int salud;    //  100
        }
    }
}