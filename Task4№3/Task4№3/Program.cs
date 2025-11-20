using System;
using System.Collections.Generic;

class ProductionRecord
{
    public string Month { get; set; }
    public int Plan { get; set; }
    public int Fact { get; set; }

    public ProductionRecord(string month, int plan, int fact)
    {
        if (plan < 0 || fact < 0)
            throw new ArgumentException("План і факт не можуть бути від'ємними!");

        Month = month;
        Plan = plan;
        Fact = fact;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<ProductionRecord> data = new List<ProductionRecord>();

        // Створимо 10 записів
        try
        {
            data.Add(new ProductionRecord("Січень", 1000, 950));
            data.Add(new ProductionRecord("Лютий", 1200, 1200));
            data.Add(new ProductionRecord("Березень", 1500, 1400));
            data.Add(new ProductionRecord("Квітень", 1600, 1580));
            data.Add(new ProductionRecord("Травень", 1300, 1250));
            data.Add(new ProductionRecord("Червень", 1400, 1380));
            data.Add(new ProductionRecord("Липень", 1100, 1050));
            data.Add(new ProductionRecord("Серпень", 1700, 1700));
            data.Add(new ProductionRecord("Вересень", 1800, 1750));
            data.Add(new ProductionRecord("Жовтень", 1900, 1850));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка створення записів: " + ex.Message);
        }

        Console.WriteLine("\nМісяці з недовиконанням плану:\n");
        Console.WriteLine("┌────────────┬───────────┬───────────┐");
        Console.WriteLine("│   Місяць   │   План    │   Факт    │");
        Console.WriteLine("├────────────┼───────────┼───────────┤");

        foreach (var r in data)
        {
            if (r.Fact < r.Plan)
            {
                Console.WriteLine($"│ {r.Month,-10} │ {r.Plan,7}    │ {r.Fact,7}    │");
            }
        }

        Console.WriteLine("└────────────┴───────────┴───────────┘");

        Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }
}

