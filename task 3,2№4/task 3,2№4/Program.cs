using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Введіть шлях до файлу:");
        string path = Console.ReadLine();

        if (!File.Exists(path))
        {
            Console.WriteLine("Файл не знайдено!");
            return;
        }

     
        List<int> numbers = new List<int>();
        foreach (var part in File.ReadAllText(path).Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries))
        {
            if (int.TryParse(part, out int n))
                numbers.Add(n);
        }

       
        List<int> result = new List<int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            int num = numbers[i];

           
            result.Add(num);

         
            if ((i + 1) % 2 == 1 && num % 2 == 0)
            {
                
                result.Add(num);
            }
        }

     
        File.WriteAllText(path, string.Join(" ", result));

        Console.WriteLine("Готово! Парні числа на непарних місцях продубльовано.");
    }
}
