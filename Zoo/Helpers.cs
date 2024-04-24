using System;
using System.Text;

namespace Zoo;

internal static class Helpers
{
    public static string ReadString(string? message = null)
    {
        if (!string.IsNullOrEmpty(message))
            Console.Write(message);

        return Console.ReadLine() ?? string.Empty;
    }

    public static string ReadPassword(string? message = null)
    {
        if (!string.IsNullOrEmpty(message))
            Console.Write(message);

        var pass = new StringBuilder();
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
            {
                pass.Remove(pass.Length - 1, 1);
                Console.Write("\b \b");
            }
            else if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                pass.Append(key.KeyChar);
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                return pass.ToString();
            }
        }
    }



    public static int ReadInteger(string? message = null)
    {
        while (true)
        {
            var str = ReadString(message);
            if (!int.TryParse(str, out var number))
            {
                Console.WriteLine("Not a valid number");
                continue;
            }

            return number;
        }
    }




    public static void WaitForAKey(string? message = null)
    {
        if (!string.IsNullOrEmpty(message))
            Console.Write(message);

        Console.ReadKey(true);
    }
}