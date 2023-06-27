using System;

public class Personaje
{
    public string Nombre { get; set; }
    public int Velocidad { get; set; }
    public int Destreza { get; set; }
    public int Fuerza { get; set; }
    public int Nivel { get; set; }
    public int Armadura { get; set; }
    public int Salud { get; set; }

    public Personaje(string nombre, int velocidad, int destreza, int fuerza, int nivel, int armadura, int salud)
    {
        Nombre = nombre;
        Velocidad = velocidad;
        Destreza = destreza;
        Fuerza = fuerza;
        Nivel = nivel;
        Armadura = armadura;
        Salud = salud;
    }
}
