using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Приклад масиву (можна змінити або зробити ввід користувача)
        int[] array = { 3, 0, -5, 8, -2, 0, 7, 0, -4 };

        Console.WriteLine("Масив: " + string.Join(", ", array));

        // 1. Індекс максимального елемента
        int maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[maxIndex])
                maxIndex = i;
        }
        Console.WriteLine($"1) Індекс максимального елемента: {maxIndex}");

        // 2. Сума модулів між першим і останнім нулями
        int firstZero = Array.IndexOf(array, 0);
        int lastZero = Array.LastIndexOf(array, 0);

        if (firstZero == -1 || lastZero == -1 || firstZero == lastZero)
        {
            Console.WriteLine("2) Недостатньо нулів у масиві для обчислення суми.");
        }
        else
        {
            int sum = 0;
            for (int i = firstZero + 1; i < lastZero; i++)
            {
                sum += Math.Abs(array[i]);
            }
            Console.WriteLine($"2) Сума модулів між першим і останнім нулями: {sum}");
        }
    }
}
