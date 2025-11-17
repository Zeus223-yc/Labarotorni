using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int[] array;

        Console.WriteLine("=== Обробка масиву ===");
        Console.WriteLine("Оберіть режим:");
        Console.WriteLine("1 — Ввід масиву з клавіатури");
        Console.WriteLine("2 — Генерація випадкових чисел [-100; 100]");
        Console.Write("Ваш вибір: ");
        string mode = Console.ReadLine();

        if (mode == "1")
        {
            array = InputArrayFromKeyboard();
        }
        else if (mode == "2")
        {
            array = GenerateRandomArray();
        }
        else
        {
            Console.WriteLine("❌ Невірний вибір. Завершення програми.");
            return;
        }

        Console.WriteLine("\n🔹 Початковий масив:");
        Console.WriteLine(string.Join(", ", array));

        int maxIndex = GetMaxIndex(array);
        Console.WriteLine($"\n🔸 Індекс максимального елемента: {maxIndex}");

        int sum = SumBetweenFirstAndLastZero(array);
        Console.WriteLine($"🔸 Сума модулів між першим і останнім нулями: {sum}");
    }

    // --- Ввід з клавіатури ---
    static int[] InputArrayFromKeyboard()
    {
        int n;
        Console.Write("Введіть кількість елементів масиву: ");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("❌ Помилка. Введіть додатне ціле число: ");
        }

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введіть елемент [{i}]: ");
            while (!int.TryParse(Console.ReadLine(), out arr[i]))
            {
                Console.Write("❌ Некоректне число. Повторіть: ");
            }
        }
        return arr;
    }

    // --- Генерація випадкового масиву ---
    static int[] GenerateRandomArray()
    {
        int n;
        Console.Write("Введіть розмір масиву: ");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("❌ Помилка. Введіть додатне ціле число: ");
        }

        int[] arr = new int[n];
        Random rand = new Random();
        Console.WriteLine("\n🔧 Генерується масив...");
        for (int i = 0; i < n; i++)
        {
            arr[i] = rand.Next(-100, 101); // [-100, 100]
        }
        return arr;
    }

    // --- Пошук індексу максимуму ---
    static int GetMaxIndex(int[] arr)
    {
        int maxIndex = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > arr[maxIndex])
                maxIndex = i;
        }
        return maxIndex;
    }

    // --- Сума модулів між першим і останнім нулем ---
    static int SumBetweenFirstAndLastZero(int[] arr)
    {
        int first = Array.IndexOf(arr, 0);
        int last = Array.LastIndexOf(arr, 0);

        if (first == -1 || last == -1 || first == last)
        {
            Console.WriteLine("⚠️ У масиві недостатньо нульових елементів.");
            return 0;
        }

        int sum = 0;
        for (int i = first + 1; i < last; i++)
        {
            sum += Math.Abs(arr[i]);
        }
        return sum;
    }
}
