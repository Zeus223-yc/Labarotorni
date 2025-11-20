using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Disc
{
    public int Inventory { get; set; }
    public string Name { get; set; }
    public double Size { get; set; }
    public string Type { get; set; }
    public string Date { get; set; }

    public Disc() { }

    public Disc(int i, string n, double s, string t, string d)
    {
        Inventory = i; Name = n; Size = s; Type = t; Date = d;
    }

    public override string ToString() => $"{Inventory};{Name};{Size};{Type};{Date}";
    public static Disc FromString(string s)
    {
        var p = s.Split(';');
        return new Disc(int.Parse(p[0]), p[1], double.Parse(p[2]), p[3], p[4]);
    }
}

class Program
{
    static string file = "discs.txt";

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        if (!File.Exists(file))
            File.WriteAllLines(file, new[]
            {
                "1;Hybrid Theory;4.7;CD;2000-10-24",
                "2;Meteora;4.7;CD;2003-03-25",
                "3;Thriller;4.7;CD;1982-11-30"
            });

        while (true)
        {
            Console.Clear();
            Console.WriteLine("D - додати, S - показати, F - пошук, X - видалити, O - сортувати, Enter - вихід");
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Enter) break;
            if (key == ConsoleKey.D) Add();
            if (key == ConsoleKey.S) Show();
            if (key == ConsoleKey.F) Find();
            if (key == ConsoleKey.X) Delete();
            if (key == ConsoleKey.O) Sort();
        }
    }

    static List<Disc> Load() => File.ReadAllLines(file).Select(Disc.FromString).ToList();
    static void Save(List<Disc> l) => File.WriteAllLines(file, l.Select(x => x.ToString()));

    static void Add()
    {
        try
        {
            Console.Write("Інвентарний номер: "); int i = int.Parse(Console.ReadLine());
            Console.Write("Назва альбому: "); string n = Console.ReadLine();
            Console.Write("Об'єм: "); double s = double.Parse(Console.ReadLine());
            Console.Write("Тип: "); string t = Console.ReadLine();
            Console.Write("Дата: "); string d = Console.ReadLine();

            var list = Load();
            list.Add(new Disc(i, n, s, t, d));
            Save(list);

            Console.WriteLine("Додано!");
        }
        catch { Console.WriteLine("Некоректні дані!"); }

        Console.ReadKey();
    }

    static void Show()
    {
        foreach (var d in Load())
            Console.WriteLine($"{d.Inventory} | {d.Name} | {d.Size} | {d.Type} | {d.Date}");
        Console.ReadKey();
    }

    static void Find()
    {
        Console.Write("Введіть назву для пошуку: ");
        string name = Console.ReadLine();

        var res = Load().Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        foreach (var d in res)
            Console.WriteLine($"{d.Inventory} | {d.Name} | {d.Size} | {d.Type} | {d.Date}");

        Console.ReadKey();
    }

    static void Delete()
    {
        Console.Write("Введіть інвентарний номер: ");
        int id = int.Parse(Console.ReadLine());

        var list = Load();
        list.RemoveAll(x => x.Inventory == id);
        Save(list);

        Console.WriteLine("Видалено!");
        Console.ReadKey();
    }

    static void Sort()
    {
        var sorted = Load().OrderBy(x => x.Name).ToList();
        Save(sorted);

        Console.WriteLine("Відсортовано по назві!");
        Console.ReadKey();
    }
}

