using System;

class IntArray
{
    private int[] array;

    // Метод А – введення з клавіатури
    public void InputFromKeyboard()
    {
        int n;
        Console.Write("Введіть кількість елементів масиву: ");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Помилка. Введіть додатне ціле число: ");
        }

        array = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"array[{i}] = ");
            while (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.Write("Помилка. Введіть ціле число: ");
            }
        }
    }

    // Метод Б – генерація випадкових чисел
    public void FillRandom(int size)
    {
        Random rnd = new Random();
        array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = rnd.Next(-100, 101);
        }
    }

    // Виведення масиву
    public void PrintArray()
    {
        Console.WriteLine("\nМасив: " + string.Join(", ", array));
    }

    // Пошук індексу максимального елемента
    public int GetIndexOfMax()
    {
        int maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[maxIndex])
                maxIndex = i;
        }
        return maxIndex;
    }

    // Сума модулів між першим і останнім нулями
    public int GetSumBetweenZeros()
    {
        int firstZero = Array.IndexOf(array, 0);
        int lastZero = Array.LastIndexOf(array, 0);

        if (firstZero == -1 || lastZero == -1 || firstZero == lastZero)
            return 0; // недостатньо нулів

        int sum = 0;
        for (int i = firstZero + 1; i < lastZero; i++)
        {
            sum += Math.Abs(array[i]);
        }

        return sum;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        IntArray arr = new IntArray();

        Console.WriteLine("Оберіть режим:");
        Console.WriteLine("1 — Ввести масив з клавіатури");
        Console.WriteLine("2 — Згенерувати випадковий масив");
        Console.Write("Ваш вибір: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            arr.InputFromKeyboard();
        }
        else if (choice == "2")
        {
            int size;
            Console.Write("Введіть розмір масиву: ");
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.Write("Помилка. Введіть додатне число: ");
            }
            arr.FillRandom(size);
        }
        else
        {
            Console.WriteLine("Невірний вибір.");
            return;
        }

        arr.PrintArray();

        int maxIndex = arr.GetIndexOfMax();
        int sumBetweenZeros = arr.GetSumBetweenZeros();

        Console.WriteLine($"\nНомер (індекс) максимального елемента: {maxIndex}");
        Console.WriteLine($"Сума модулів між першим і останнім нулями: {sumBetweenZeros}");
    }
}

