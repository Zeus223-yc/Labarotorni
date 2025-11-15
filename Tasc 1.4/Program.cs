using System;

class Program
{
    static void Main()
    {
        int a = 1;
        int b = 2;
        int c = 3;

        int V = a * b * c;
        int S = 2 * (a * b + b * c + a * c);

        Console.WriteLine("Об'єм V = " + V);
        Console.WriteLine("Площа поверхні S = " + S);
    }
}
 2