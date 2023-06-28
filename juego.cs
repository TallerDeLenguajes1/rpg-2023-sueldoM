using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
namespace JuegoRPG
{
public class Juego
{
    private List<Personaje> personajes;
    private Random random;
    private FabricaDePersonajes fabrica;
    private PersonajesJson persistencia;

    public List<Personaje> Personajes { get { return personajes; } }

    private HttpClient httpClient;
    public Juego()
    {
        personajes = new List<Personaje>();
        random = new Random();
        fabrica = new FabricaDePersonajes();
        persistencia = new PersonajesJson();
        httpClient = new HttpClient();
    }

    public void AgregarPersonaje(Personaje personaje)
    {
        personajes.Add(personaje);
    }

    public async Task IniciarCombate()
    {
        // Elege 2 personajes aleatorios
        Personaje personaje1 = ElegirPersonajeAleatorio();
        Personaje personaje2 = ElegirPersonajeAleatorio();

        Console.WriteLine("══════════════════════");
        Console.WriteLine("¡Comienza el combate!");
        Console.WriteLine("══════════════════════");
        Console.WriteLine(" ");
        Console.WriteLine("╔════════════════════════════════════");
        Console.WriteLine($"║{personaje1.Nombre} ║vs║ {personaje2.Nombre}");
        Console.WriteLine("╚════════════════════════════════════");
        Console.WriteLine(" ");

        // Variables para llevar el control del turno actual
        int turno = 1;
        Personaje atacante = personaje1;
        Personaje defensor = personaje2;

        // Sistema de combate
        while (atacante.Salud > 0 && defensor.Salud > 0)
        {
            Console.WriteLine("╔════════╗");
            Console.WriteLine($"║Turno {turno} ║");
            string insultoJson = await httpClient.GetStringAsync("https://evilinsult.com/generate_insult.php?lang=en&type=json");
            Insulto? insulto = JsonConvert.DeserializeObject<Insulto>(insultoJson);
            Console.WriteLine("╠════════╩════════════════════╗");
            Console.WriteLine($"║{atacante.Nombre} [══[===========- {defensor.Nombre}║");
            Console.WriteLine("╚═════════════════════════════╝");
            Console.WriteLine(" ");
            // Calcula el daño provocado
            int ataque = atacante.Destreza * atacante.Fuerza * atacante.Nivel;
            int efectividad = random.Next(1, 101);
            int defensa = defensor.Armadura * defensor.Velocidad;
            int dañoProvocado = (ataque * efectividad - defensa) / 500;

            
            defensor.Salud -= dañoProvocado; // Actualiza la salud del personaje defensor

            Console.WriteLine("╔════════════════════════╗");
            Console.WriteLine($"║Has provocado: {dañoProvocado} de Daño║");
            Console.WriteLine("╚════════════════════════╝");
            Console.WriteLine($"Insulto: {insulto?.Insult}");
            Console.WriteLine(" ");

            // Cambia roles de atacante y defensor
            Personaje temp = atacante;
            atacante = defensor;
            defensor = temp;

            turno++;
        }

        // Determinara al ganador y otorgara la mejora de habilidades
        Personaje ganador = (personaje1.Salud <= 0) ? personaje2 : personaje1;
        Console.WriteLine(" ");
        Console.WriteLine("═════════════════════════");
        Console.WriteLine("¡Fin del combate!");
        Console.WriteLine($"{ganador.Nombre} es el ganador");
        Console.WriteLine("═════════════════════════");


        // Otorgara mejora de habilidades al ganador
        MejorarHabilidades(ganador);
    }

    private Personaje ElegirPersonajeAleatorio()
    {
        int index = random.Next(personajes.Count);
        return personajes[index];
    }

    private void MejorarHabilidades(Personaje personaje)
    {
        Console.WriteLine(" ");
        Console.WriteLine("═════════════════════════");
        Console.WriteLine($"{personaje.Nombre} ha sido mejorado:");

        //Mejorar en salud o defensa
        personaje.Salud += 10;
        personaje.Armadura += 5;

        Console.WriteLine($"Salud mejorada: {personaje.Salud}");
        Console.WriteLine($"Armadura mejorada: {personaje.Armadura}");
        Console.WriteLine("═════════════════════════");
    }
}
}