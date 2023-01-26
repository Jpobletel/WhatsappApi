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
}