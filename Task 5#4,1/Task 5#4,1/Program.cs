using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ==== БАЗОВИЙ КЛАС ====
class BaseConference
{
    protected string file = "meetings.txt";

    public virtual void Add() { }
    public virtual void Edit() { }
    public virtual void Delete() { }
    public virtual void Show() { }

    // Віртуальний метод індивідуального завдання
    public virtual void Stats() { }
}

// ==== КОНФЕРЕНЦІЯ ====
class Conference
{
    public string Name { get; set; }
    public string Place { get; set; }

    public Conference(string n, string p)
    {
        Name = n; Place = p;
    }
}

// ==== ЗАСІДАННЯ ====
class Meeting
{
    public string Date { get; set; }
    public string Topic { get; set; }
    public int Participants { get; set; }

    public Meeting(string d, string t, int p)
    {
        Date = d; Topic = t; Participants = p;
    }

    public override string ToString() => $"{Date};{Topic};{Participants}";
    public static Meeting FromString(string s)
    {
        var a = s.Split(';');
        return new Meeting(a[0], a[1], int.Parse(a[2]));
    }
}

// ==== РОБОТА З БАЗОЮ ====
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
        catch { Console.WriteLine("Помилка — некоректні дані."); }

        Console.ReadKey();
    }

    public override void Edit()
    {
        var list = Load();
        Console.Write("Введіть тему для редагування: ");
        string topic = Console.ReadLine();

        var m = list.FirstOrDefault(x => x.Topic == topic);
        if (m == null) { Console.WriteLine("Не знайдено."); Console.ReadKey(); return; }

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

    public override void Stats()
    {
        var list = Load();

        Console.WriteLine("\n--- СТАТИСТИКА ---");

        Console.WriteLine("Середня к-сть учасників: " +
            list.Average(x => x.Participants));

        var max = list.OrderByDescending(x => x.Participants).First();
        Console.WriteLine($"Найбільше учасників: {max.Topic} ({max.Participants})");

        Console.WriteLine("Довжина назв тем:");
        foreach (var m in list)
            Console.WriteLine($"{m.Topic} → {m.Topic.Length} символів");

        Console.ReadKey();
    }
}


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
            Console.WriteLine("S - показати всі");
            Console.WriteLine("T - статистика");
            Console.WriteLine("Enter - вихід");

            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Enter) break;
            if (key == ConsoleKey.A) db.Add();
            if (key == ConsoleKey.E) db.Edit();
            if (key == ConsoleKey.D) db.Delete();
            if (key == ConsoleKey.S) db.Show();
            if (key == ConsoleKey.T) db.Stats();
        }
    }
}
