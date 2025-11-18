using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Введіть текстовий рядок:");
        string text = Console.ReadLine();

        text = Regex.Replace(text, @"\b\w*[A-Za-z]\w*\b", "");

        text = Regex.Replace(text, @"\d+", "");

        text = Regex.Replace(text, @"\s{2,}", " ").Trim();

        Console.WriteLine("\nРезультат:");
        Console.WriteLine(text);
    }
}
