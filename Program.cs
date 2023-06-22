using EspacioPersonaje;

List<personaje> listaDePersonajes = new List<personaje>();
personaje nuevoPersonaje;
FabricaDePErsonajes fp = new FabricaDePErsonajes();
int cantidadDePersonajes = 10;

string nomArchivo = "Personajes.json";
PersonajesJson archivo = new PersonajesJson();

if (archivo.Existe(nomArchivo)){

    listaDePersonajes = archivo.LeerPersonajes(nomArchivo);

}
else{
    
    for(int i=0; i<cantidadDePersonajes; i++) {

    nuevoPersonaje = fp.CrearPersonaje();
    listaDePersonajes.Add(nuevoPersonaje);

    }

    archivo.GuardarPersonajes(listaDePersonajes, nomArchivo);

}

Console.Write("\nMostrando los personajes...");
Thread.Sleep(2000);

mostrarListaDePersonajes(listaDePersonajes);

//FUNCIONES

void mostrarListaDePersonajes(List<personaje> pj){

    if (pj == null) {

        Console.Write("\nNo hay personajes cargados");

    }
    else {
        int i = 1;
        foreach (var p in pj) {
            Console.Write($"\n\nPersonaje N° {i}\n");
            p.mostrarPersonaje();
            i++;
            Thread.Sleep(2000);

        }
    }
}