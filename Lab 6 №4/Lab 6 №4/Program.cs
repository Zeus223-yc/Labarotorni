using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ===== ІНТЕРФЕЙС =====
interface IProductionDB
{
    void Add();
    void Edit();
    void Delete();
    void Show();
    void ShowUnderPlan();   // індивідуальне завдання
}

// ===== МОДЕЛЬ ДАНИХ =====
class ProductionRecord
{
    public string Month { get; set; }
    public int Plan { get; set; }
    public int Fact { get; set; }

    public ProductionRecord(string m, int p, int f)
    {
        Month = m;
        Plan = p;
        Fact = f;
    }

    public override string ToString() => $"{Month};{Plan};{Fact}";

    public static ProductionRecord FromString(string line)
    {
        var a = line.Split(';');
        return new ProductionRecord(a[0], int.Parse(a[1]), int.Parse(a[2]));
    }
}

// ===== РЕАЛІЗАЦІЯ ІНТЕРФЕЙСУ =====
class ProductionDatabase : IProductionDB
{
    string file = "production.txt";

    List<ProductionRecord> Load() =>
        File.ReadAllLines(file).Select(ProductionRecord.FromString).ToList();

    void Save(List<ProductionRecord> list) =>
        File.WriteAllLines(file, list.Select(x => x.ToString()));

    public ProductionDatabase()
    {
        if (!File.Exists(file))
        {
            File.WriteAllLines(file, new[]
            {
                "Січень;1000;950",
                "Лютий;1200;1200",
                "Березень;1400;1300",
                "Квітень;1600;1580",
                "Травень;1500;1400"
            });
        }
    }

    public void Add()
    {
        try
        {
            Console.Write("Місяць: ");
            string m = Console.ReadLine();
            Console.Write("План: ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("Факт: ");
            int f = int.Parse(Console.ReadLine());

            var list = Load();
            list.Add(new ProductionRecord(m, p, f));
            Save(list);

            Console.WriteLine("Додано!");
        }
        catch { Console.WriteLine("Помилка: некоректний ввід."); }

        Console.ReadKey();
    }

    public void Edit()
    {
        var list = Load();

        Console.Write("Введіть місяць для редагування: ");
        string m = Console.ReadLine();

        var r = list.FirstOrDefault(x => x.Month == m);
        if (r == null)
        {
            Console.WriteLine("Не знайдено!");
            Console.ReadKey();
            return;
        }

        Console.Write("Новий факт: ");
        r.Fact = int.Parse(Console.ReadLine());

        Save(list);
        Console.WriteLine("Оновлено!");
        Console.ReadKey();
    }

    public void Delete()
    {
        var list = Load();

        Console.Write("Місяць для видалення: ");
        string m = Console.ReadLine();

        list.RemoveAll(x => x.Month == m);
        Save(list);

        Console.WriteLine("Видалено!");
        Console.ReadKey();
    }

    public void Show()
    {
        foreach (var r in Load())
            Console.WriteLine($"{r.Month} | План {r.Plan} | Факт {r.Fact}");
        Console.ReadKey();
    }

    // ===== ІНДИВІДУАЛЬНЕ ЗАВДАННЯ =====
    public void ShowUnderPlan()
    {
        var list = Load();

        Console.WriteLine("\nМісяці з недовиконанням плану:");
        Console.WriteLine("--------------------------------");

        foreach (var r in list)
            if (r.Fact < r.Plan)
                Console.WriteLine($"{r.Month,-10} | План: {r.Plan} | Факт: {r.Fact}");

        Console.ReadKey();
    }
}

// ===== ГОЛОВНЕ МЕНЮ =====
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        IProductionDB db = new ProductionDatabase();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("A - додати");
            Console.WriteLine("E - редагувати");
            Console.WriteLine("D - видалити");
            Console.WriteLine("S - показати всі");
            Console.WriteLine("U - недовиконання плану");
            Console.WriteLine("Enter - вихід");

            var k = Console.ReadKey(true).Key;

            if (k == ConsoleKey.Enter) break;
            if (k == ConsoleKey.A) db.Add();
            if (k == ConsoleKey.E) db.Edit();
            if (k == ConsoleKey.D) db.Delete();
            if (k == ConsoleKey.S) db.Show();
            if (k == ConsoleKey.U) db.ShowUnderPlan();
        }
    }
}
