using System;
using System.Collections.Generic;

public class FabricaDePersonajes
{
    private Random random;

    public FabricaDePersonajes()
    {
        random = new Random();
    }

    public Personaje CrearPersonajeAleatorio()
    {
        string nombre = GenerarNombreAleatorio();
        int velocidad = random.Next(1, 11);
        int destreza = random.Next(1, 6);
        int fuerza = random.Next(1, 11);
        int nivel = random.Next(1, 11);
        int armadura = random.Next(1, 11);
        int salud = 100;

        return new Personaje(nombre, velocidad, destreza, fuerza, nivel, armadura, salud);
    }

    private string GenerarNombreAleatorio()
    {
        string[] nombres = { "Gandalf", "Aragorn", "Legolas", "Frodo", "Gimli", "Boromir", "Samwise", "Gollum", "Galadriel", "Elrond" };
        int index = random.Next(nombres.Length);
        return nombres[index];
    }
}
