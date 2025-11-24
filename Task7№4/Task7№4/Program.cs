using System;
using System.Collections.Generic;

class Vyrib : IComparable<Vyrib>
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public double Price { get; set; }
    public string Material { get; set; }
    public string Manufacturer { get; set; }

    public Vyrib(string name, double weight, double price, string material, string manufacturer)
    {
        Name = name;
        Weight = weight;
        Price = price;
        Material = material;
        Manufacturer = manufacturer;
    }

    // A) Порівняння за вагою
    public int CompareTo(Vyrib other)
    {
        return Weight.CompareTo(other.Weight);
    }

    public override string ToString()
    {
        return $"{Name,-12} | {Weight,6} кг | {Price,6}$ | {Material,-10} | {Manufacturer}";
    }
}

// Б) Порівняння за ціною
class PriceComparer : IComparer<Vyrib>
{
    public int Compare(Vyrib x, Vyrib y)
    {
        return x.Price.CompareTo(y.Price);
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        try
        {
            Vyrib[] items =
            {
                new Vyrib("Столик", 12.5, 150, "Дерево", "Україна"),
                new Vyrib("Стілець", 5.2, 70, "Метал", "Польща"),
                new Vyrib("Лампа", 2.1, 45, "Пластик", "Китай"),
                new Vyrib("Шафа", 40, 350, "Дерево", "Україна"),
                new Vyrib("Диван", 55, 500, "Тканина", "Італія"),
                new Vyrib("Стелаж", 20, 220, "Метал", "Чехія"),
                new Vyrib("Табурет", 3.4, 40, "Дерево", "Україна"),
                new Vyrib("Комод", 18, 260, "Дерево", "Німеччина"),
                new Vyrib("Крісло", 14, 180, "Тканина", "Польща"),
                new Vyrib("Ліжко", 48, 600, "Дерево", "США")
            };

            Console.WriteLine("=== Початковий масив ===");
            Print(items);

            // Сортування за вагою (IComparable)
            Array.Sort(items);
            Console.WriteLine("\n=== Сортовано за вагою ===");
            Print(items);

            // Сортування за ціною (IComparer)
            Array.Sort(items, new PriceComparer());
            Console.WriteLine("\n=== Сортовано за ціною ===");
            Print(items);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Сталася помилка: " + ex.Message);
        }
    }

    static void Print(Vyrib[] arr)
    {
        foreach (var v in arr)
            Console.WriteLine(v);
    }
}

