using System;
using System.Collections.Generic;

public class PersonajesJson
{
    public void GuardarPersonajes(List<Personaje> personajes, string nombreArchivo)
    {
        // Guarda la lista de personajes en formato Json en el archivo
        Console.WriteLine($"Guardando personajes en el archivo '{nombreArchivo}'...");
    }

    public List<Personaje> LeerPersonajes(string nombreArchivo)
    {
        //Lee la lista de personajes desde el archivo Json y la devuelve
        Console.WriteLine($"Leyendo personajes desde el archivo '{nombreArchivo}'...");
        return new List<Personaje>();
    }

    public bool Existe(string nombreArchivo)
    {
        // Verifica si el archivo existe y si tiene datos
        Console.WriteLine($"Verificando existencia del archivo '{nombreArchivo}'...");
        return false;
    }
}
