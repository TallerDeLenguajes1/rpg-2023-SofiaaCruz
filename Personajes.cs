using System.Text.Json;
using System.Text.Json.Serialization;

namespace EspacioPersonaje{

    public class personaje {

        //DATOS

        private string? tipo;
        private string? nombre;
        private string? apodo;
        private DateTime fechadenacimiento;
        private int edad; //0-300

        //Características

        private int velocidad; //1-10
        private int destreza; //1-5
        private int fuerza; //1-10
        private int nivel; //1-10
        private int armadura; //1-10
        private int salud; //100

        public string? Tipo { get => tipo; set => tipo = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Apodo { get => apodo; set => apodo = value; }
        public DateTime Fechadenacimiento { get => fechadenacimiento; set => fechadenacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = value; }

        public void mostrarPersonaje(){

            Console.Write($"\nTipo: {tipo}");
            Console.Write($"\nNombre: {nombre}");
            Console.Write($"\nApodo: {apodo}");
            Console.Write($"\nFecha de nacimiento: {fechadenacimiento.Day}/{fechadenacimiento.Month}/{fechadenacimiento.Year}");
            Console.Write($"\nEdad: {edad} años");
            Console.Write($"\nVelocidad: {velocidad}");
            Console.Write($"\nDestreza: {destreza}");
            Console.Write($"\nFuerza: {fuerza}");
            Console.Write($"\nNivel: {nivel}");
            Console.Write($"\nArmadura: {armadura}");
            Console.Write($"\nSalud: {salud}");

        }
    }

    public class FabricaDePErsonajes {

        Random random = new Random();

        public personaje CrearPersonaje() {

            string[] tipos = {"Demonio", "Espiritu de la naturaleza"};

            string[] nombres = {"Ama-no-jaku", "Joro-Gumo", "Dodomeki", "Uwan", "Tengu", "Nopperabo", "Tsuchigmo", "Ningyo", "Kamaitachi", "Gashadokuro", "Espiritu del fuego", "Espiritu del agua", "Espiritu del viento", "Espiritu de la tierra", "Espiritu del bosque", "Espiritu del rayo", "Espiritu de la luna", "Espiritu de la montaña", "Espiritu de la niebla", "Espiritu de la aurora"};

            string[] apodos = {"", "", "", "", "", "", "", "", "", "","Llama Ardiente", "Susurro Acuático", "Torbellino Veloz", "El Guardián de la Tierra", "Vigía del Bosque", "Centella Electrica", "Luz Lunar", "El Vigía de las Cumbres", "Niebla Enigmática", "Aurora Brillante"};

            personaje pj = new personaje();

            pj.Tipo = tipos[random.Next(0,2)];

            int indice;

            if(pj.Tipo == "Demonio"){
                indice = random.Next(0, 10);
            }
            else {
                indice = random.Next(10,20);
            }

            pj.Nombre = nombres[indice];
            pj.Apodo = apodos[indice];
            pj.Fechadenacimiento = fecha();
            pj.Edad = 1094 - pj.Fechadenacimiento.Year;
            pj.Velocidad = random.Next(1, 11);
            pj.Destreza = random.Next(1, 6); 
            pj.Fuerza = random.Next(1,11);
            pj.Nivel = random.Next(1,11);
            pj.Armadura = random.Next(1,11);
            pj.Salud = 100;

            return pj;
        }

        DateTime fecha(){

            int dia = random.Next(1,31);
            int mes = random.Next(1,13); 
            int año = random.Next(794,1095);

            DateTime f = new DateTime(año, mes, dia);
            
            return f;
        }

        
    }

    public class PersonajesJson {

        public void GuardarPersonajes (List<personaje> listaPj, string nomArchivo){

            string Json = JsonSerializer.Serialize(listaPj);

            File.WriteAllText(nomArchivo, Json);
        }

        public List<personaje> LeerPersonajes (string nomArchivo) {

            string Json = File.ReadAllText(nomArchivo);

            List<personaje>? listaPersonaje = new List<personaje>();

            listaPersonaje = JsonSerializer.Deserialize<List<personaje>>(Json);

            return listaPersonaje;

        }

        public bool Existe (string nomArchivo) {

            if(File.Exists(nomArchivo)){ //verifica que el archivo existe

                string datos = File.ReadAllText(nomArchivo);//lee el contenido

                return !string.IsNullOrEmpty(datos); // verifica que el contenido no sea nulo
            }
            else{
                return false;
            }
        }
    }
}
