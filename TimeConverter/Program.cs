using System;

namespace TimeConverter
{
    public class Program
    {
        // Метод: повертає кількість повних хвилин
        public static int GetFullMinutes(int seconds)
        {
            int minutes = seconds / 60;
            Console.WriteLine($"Минуло хвилин: {minutes}");
            return minutes;
        }

        static void Main(string[] args)
        {
            Console.Write("Введіть кількість секунд з початку доби: ");
            string input = Console.ReadLine();
            int seconds = int.Parse(input);

            GetFullMinutes(seconds);

            Console.ReadLine();
        }
    }
}
