namespace WhatsappApi;
using System;

public class View
{
    public static string? GetInputString(string text)
    {
        Console.WriteLine(text);
        var inputUsuario = Console.ReadLine();
        while (string.IsNullOrEmpty(inputUsuario))
        {
            Console.WriteLine("Ingresa un texto valido");
            inputUsuario = Console.ReadLine();
        }
        return inputUsuario;
    }
    
    public static int GetIntInput(int supLimit)
    {
        var inputUsuario = Console.ReadLine();
        bool success = int.TryParse(inputUsuario, out var inputInt);
        while (!success || inputInt < 0 || inputInt >= supLimit)
        {
            inputUsuario  = Console.ReadLine();
            success = int.TryParse(inputUsuario, out inputInt);
        }

        return inputInt;
    }
}