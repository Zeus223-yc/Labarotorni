using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ===== ІНТЕРФЕЙС З ДВОМА АБСТРАКТНИМИ МЕТОДАМИ =====
interface IMeetingManager
{
    void Add();
    void Show();

    // Абстрактні методи згідно вимог ЛР6
    void Stats();          // індивідуальне завдання
    void Delete();         // метод по вибору
}

// ===== БАЗОВИЙ КЛАС (не абстрактний у ЛР6) =====
class Meeting
{
    public string Date { get; set; }
    public string Topic { get; set; }
    public int Participants { get; set; }

    public Meeting(string d, string t, int p)
    {
        Date = d;
        Topic = t;
        Participants = p;
    }

    public override string ToString() => $"{Date};{Topic};{Participants}";

    public static Meeting FromString(string s)
    {
        var a = s.Split(';');
        return new Meeting(a[0], a[1], int.Parse(a[2]));
    }
}

// ===== КЛАС, ЩО РЕАЛІЗУЄ ІНТЕРФЕЙС =====
class MeetingDatabase : IMeetingManager
{
    string file = "meetings.txt";

    List<Meeting> Load() =>
        File.ReadAllLines(file).Select(Meeting.FromString).ToList();

    void Save(List<Meeting> list) =>
        File.WriteAllLines(file, list.Select(x => x.ToString()));

    public MeetingDatabase()
    {
        if (!File.Exists(file))
        {
            File.WriteAllLines(file, new[]
            {
                "2024-01-15;AI Development;120",
                "2024-02-10;Cybersecurity;90",
                "2024-03-21;Cloud Systems;150",
                "2024-04-09;VR Technologies;70",
                "2024-05-18;Quantum Computing;200"
            });
        }
    }

    public void Add()
    {
        try
        {
            Console.Write("Дата: ");
            string d = Console.ReadLine();

            Console.Write("Тема: ");
            string t = Console.ReadLine();

            Console.Write("Кількість учасників: ");
            int p = int.Parse(Console.ReadLine());

            var list = Load();
            list.Add(new Meeting(d, t, p));
            Save(list);

            Console.WriteLine("Додано!");
        }
        catch { Console.WriteLine("Помилка: некоректні дані."); }

        Console.ReadKey();
    }

    public void Show()
    {
        foreach (var m in Load())
            Console.WriteLine($"{m.Date} | {m.Topic} | {m.Participants}");

        Console.ReadKey();
    }

    // ===== АБСТРАКТНИЙ МЕТОД №1 =====
    public void Stats()
    {
        var list = Load();

        Console.WriteLine("Середня кількість учасників: " +
            list.Average(x => x.Participants));

        var max = list.OrderByDescending(x => x.Participants).First();
        Console.WriteLine($"\nНайбільше учасників: {max.Topic} ({max.Participants})");

        Console.WriteLine("\nДовжина назв тем:");
        foreach (var m in list)
            Console.WriteLine($"{m.Topic} — {m.Topic.Length} символів");

        Console.ReadKey();
    }

    // ===== АБСТРАКТНИЙ МЕТОД №2 =====
    public void Delete()
    {
        var list = Load();

        Console.Write("Тема для видалення: ");
        string name = Console.ReadLine();

        list.RemoveAll(x => x.Topic == name);
        Save(list);

        Console.WriteLine("Видалено!");
        Console.ReadKey();
    }
}

// ===== МЕНЮ =====
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        IMeetingManager db = new MeetingDatabase();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("A - додати");
            Console.WriteLine("S - показати");
            Console.WriteLine("D - видалити");
            Console.WriteLine("T - статистика");
            Console.WriteLine("Enter - вихід");

            var k = Console.ReadKey(true).Key;

            if (k == ConsoleKey.Enter) break;
            if (k == ConsoleKey.A) db.Add();
            if (k == ConsoleKey.S) db.Show();
            if (k == ConsoleKey.D) db.Delete();
            if (k == ConsoleKey.T) db.Stats();
        }
    }
}
