using System;
namespace JuegoRPG{
class Program
{
    static async void Main(string[] args)
    {
        Juego juego = new Juego();

        PersonajesJson persistencia = new PersonajesJson();
        string nombreArchivo = "personajes.json";

        if (persistencia.Existe(nombreArchivo))
        {
            // Leer personajes desde el archivo existente
            List<Personaje> personajesGuardados = persistencia.LeerPersonajes(nombreArchivo);

            // Agregar los personajes leídos al juego
            foreach (Personaje personaje in personajesGuardados)
            {
                juego.AgregarPersonaje(personaje);
            }
        }
        else
        {
            // Generar 10 personajes aleatorios
            FabricaDePersonajes fabrica = new FabricaDePersonajes();

            for (int i = 0; i < 10; i++)
            {
                Personaje personaje = fabrica.CrearPersonajeAleatorio();
                juego.AgregarPersonaje(personaje);
            }

            // Guardar los personajes generados en el archivo
            persistencia.GuardarPersonajes(juego.Personajes, nombreArchivo);
        }

        // Mostrar los datos y características de los personajes cargados
        Console.WriteLine("╔════════════════════");
        Console.WriteLine("║Personajes cargados:");
        foreach (Personaje personaje in juego.Personajes)
        {
            Console.WriteLine($"║Nombre: {personaje.Nombre}");
            Console.WriteLine("╠══════════════════════");
            Console.WriteLine($"║Velocidad: {personaje.Velocidad}");
            Console.WriteLine($"║Destreza: {personaje.Destreza}");
            Console.WriteLine($"║Fuerza: {personaje.Fuerza}");
            Console.WriteLine($"║Nivel: {personaje.Nivel}");
            Console.WriteLine($"║Armadura: {personaje.Armadura}");
            Console.WriteLine($"║Salud: {personaje.Salud}");
            Console.WriteLine("╚═══════════════════════");
            Console.WriteLine();
        }

        // Iniciar el combate
        await juego.IniciarCombate();
    }
}
}