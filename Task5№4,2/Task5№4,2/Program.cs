using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ===== АБСТРАКТНИЙ БАЗОВИЙ КЛАС =====
abstract class BaseConference
{
    protected string file = "meetings.txt";

    public abstract void Add();
    public abstract void Edit();
    public abstract void Delete();
    public abstract void Show();

    // Абстрактний метод індивідуального завдання
    public abstract void Stats();
}

// ===== ІНФОРМАЦІЯ ПРО КОНФЕРЕНЦІЮ =====
class Conference
{
    public string Name { get; set; }
    public string Place { get; set; }

    public Conference(string n, string p)
    {
        Name = n; Place = p;
    }
}

// ===== ЗАСІДАННЯ =====
class Meeting
{
    public string Date { get; set; }
    public string Topic { get; set; }
    public int Participants { get; set; }

    public Meeting(string d, string t, int p)
    {
        Date = d; Topic = t; Participants = p;
    }

    public override string ToString() =>
        $"{Date};{Topic};{Participants}";

    public static Meeting FromString(string s)
    {
        var a = s.Split(';');
        return new Meeting(a[0], a[1], int.Parse(a[2]));
    }
}

// ===== РЕАЛІЗАЦІЯ БАЗИ ДАНИХ =====
class MeetingDatabase : BaseConference
{
    List<Meeting> Load() =>
        File.ReadAllLines(file).Select(Meeting.FromString).ToList();

    void Save(List<Meeting> list) =>
        File.WriteAllLines(file, list.Select(x => x.ToString()));

    public MeetingDatabase()
    {
        if (!File.Exists(file))
            File.WriteAllLines(file, new[]
            {
                "2024-01-15;AI Development;120",
                "2024-02-10;Cybersecurity;90",
                "2024-03-21;Cloud Systems;150",
                "2024-04-09;VR Technologies;70",
                "2024-05-18;Quantum Computing;200"
            });
    }

    public override void Add()
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
        catch { Console.WriteLine("Помилка: некоректні дані!"); }

        Console.ReadKey();
    }

    public override void Edit()
    {
        var list = Load();

        Console.Write("Введіть тему для редагування: ");
        string topic = Console.ReadLine();

        var m = list.FirstOrDefault(x => x.Topic == topic);
        if (m == null) { Console.WriteLine("Не знайдено!"); Console.ReadKey(); return; }

        Console.Write("Нова кількість учасників: ");
        m.Participants = int.Parse(Console.ReadLine());

        Save(list);
        Console.WriteLine("Оновлено!");
        Console.ReadKey();
    }

    public override void Delete()
    {
        var list = Load();

        Console.Write("Введіть тему для видалення: ");
        string topic = Console.ReadLine();

        list.RemoveAll(x => x.Topic == topic);
        Save(list);

        Console.WriteLine("Видалено!");
        Console.ReadKey();
    }

    public override void Show()
    {
        foreach (var m in Load())
            Console.WriteLine($"{m.Date} | {m.Topic} | {m.Participants}");
        Console.ReadKey();
    }

    // ===== РЕАЛІЗАЦІЯ СТАТИСТИКИ (ІНДИВІДУАЛЬНЕ ЗАВДАННЯ) =====
    public override void Stats()
    {
        var list = Load();

        Console.WriteLine("\n--- СТАТИСТИКА ---");

        Console.WriteLine("Середня кількість учасників: " +
            list.Average(x => x.Participants));

        var max = list.OrderByDescending(x => x.Participants).First();
        Console.WriteLine($"Максимальна кількість ( {max.Participants} ) у темі: {max.Topic}");

        Console.WriteLine("\nДовжина назв тем:");
        foreach (var m in list)
            Console.WriteLine($"{m.Topic} — {m.Topic.Length} символів");

        Console.ReadKey();
    }
}

// ===== МЕНЮ =====
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var db = new MeetingDatabase();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("A - додати");
            Console.WriteLine("E - редагувати");
            Console.WriteLine("D - видалити");
            Console.WriteLine("S - показати");
            Console.WriteLine("T - статистика");
            Console.WriteLine("Enter - вихід");

            var k = Console.ReadKey(true).Key;

            if (k == ConsoleKey.Enter) break;
            if (k == ConsoleKey.A) db.Add();
            if (k == ConsoleKey.E) db.Edit();
            if (k == ConsoleKey.D) db.Delete();
            if (k == ConsoleKey.S) db.Show();
            if (k == ConsoleKey.T) db.Stats();
        }
    }
}
