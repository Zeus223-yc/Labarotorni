using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть номер трамвайного маршруту (від 1 до 9): ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int routeNumber))
        {
            switch (routeNumber)
            {
                case 1:
                    Console.WriteLine("Маршрут 1: Вокзал — Центр");
                    break;
                case 2:
                    Console.WriteLine("Маршрут 2: Площа Ринок — Сихів");
                    break;
                case 3:
                    Console.WriteLine("Маршрут 3: Аеропорт — Вокзал");
                    break;
                case 4:
                    Console.WriteLine("Маршрут 4: Привокзальна — Залізнична лікарня");
                    break;
                case 5:
                    Console.WriteLine("Маршрут 5: Автовокзал — Центр");
                    break;
                case 6:
                    Console.WriteLine("Маршрут 6: Левандівка — Сихів");
                    break;
                case 7:
                    Console.WriteLine("Маршрут 7: Шевченківський гай — Вокзал");
                    break;
                case 8:
                    Console.WriteLine("Маршрут 8: Технопарк — Центр");
                    break;
                case 9:
                    Console.WriteLine("Маршрут 9: Рясне — Личаків");
                    break;
                default:
                    Console.WriteLine("Невірний номер маршруту. Введіть число від 1 до 9.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Будь ласка, введіть дійсний номер.");
        }
    }
}
