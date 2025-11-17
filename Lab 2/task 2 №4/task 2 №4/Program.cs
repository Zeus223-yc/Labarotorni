using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть номер завдання (1-13): ");
        int task = int.Parse(Console.ReadLine());

        double a = 0, b = 0, dx = 0;
        string formula = "";

        switch (task)
        {
            case 1:
                a = -1; b = 3; dx = 0.05;
                formula = "y = lg(x)/x";
                break;
            case 2:
                a = 1; b = 6; dx = 0.2;
                formula = "y = lg(x)";
                break;
            case 3:
                a = 1.25; b = 6.75; dx = 0.25;
                formula = "y = ∛x + ln(3x)";
                break;
            case 4:
                a = 0.5; b = 4.5; dx = 0.4;
                formula = "y = ln(x)";
                break;
            case 5:
                a = 3; b = 6; dx = 0.05;
                formula = "y = e^(√2x) * x^2";
                break;
            case 6:
                a = 1; b = 2; dx = 0.025;
                formula = "y = log₂(x)";
                break;
            case 7:
                a = -Math.PI / 2; b = 3 * Math.PI / 2; dx = Math.PI / 3;
                formula = "y = cos²(x) + 3sin(x)";
                break;
            case 8:
                a = -Math.PI / 2; b = Math.PI / 2; dx = Math.PI / 30;
                formula = "y = sin(x)/x";
                break;
            case 9:
                a = -Math.PI; b = Math.PI; dx = Math.PI / 10;
                formula = "y = cos(x) * sin(x)";
                break;
            case 10:
                a = -3; b = 3; dx = 0.5;
                formula = "y = (2 + x^3)/(x + √(13|x|))";
                break;
            case 11:
                a = 0; b = Math.PI; dx = Math.PI / 20;
                formula = "y = ⁴√(lg(x) + 13)";
                break;
            case 12:
                a = 0; b = 6; dx = 0.5;
                formula = "y = 1 / (1 - √x)";
                break;
            case 13:
                a = -Math.PI / 2; b = Math.PI / 2; dx = Math.PI / 20;
                formula = "y = ctg(x) - 2sin(x)";
                break;
            default:
                Console.WriteLine("Невірний номер завдання.");
                return;
        }

        Console.WriteLine($"\nОбчислення: {formula}");
        Console.WriteLine(" x\t|\ty = f(x)");
        Console.WriteLine("---------------------------");

        double x = a;

        
        while (x <= b + 0.0001) 
        {
            try
            {
                double y = CalculateFunction(task, x);
                Console.WriteLine($"{x:F4}\t|\t{y:F5}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{x:F4}\t|\t{e.Message}");
            }

            x += dx;
        }



    }

    static double CalculateFunction(int task, double x)
    {
        switch (task)
        {
            case 1:
                if (x == 0 || x < 0) throw new Exception("невизначено");
                return Math.Log10(x) / x;
            case 2:
                if (x <= 0) throw new Exception("невизначено");
                return Math.Log10(x);
            case 3:
                if (x < 0) throw new Exception("корінь з < 0");
                return Math.Pow(x, 1.0 / 3) + Math.Log(3 * x);
            case 4:
                if (x <= 0) throw new Exception("невизначено");
                return Math.Log(x);
            case 5:
                return Math.Exp(Math.Sqrt(2 * x)) * x * x;
            case 6:
                if (x <= 0) throw new Exception("невизначено");
                return Math.Log(x) / Math.Log(2);
            case 7:
                return Math.Pow(Math.Cos(x), 2) + 3 * Math.Sin(x);
            case 8:
                if (x == 0) throw new Exception("ділення на 0");
                return Math.Sin(x) / x;
            case 9:
                return Math.Cos(x) * Math.Sin(x);
            case 10:
                double denominator = x + Math.Sqrt(13 * Math.Abs(x));
                if (denominator == 0) throw new Exception("ділення на 0");
                return (2 + Math.Pow(x, 3)) / denominator;
            case 11:
                if (x <= 0) throw new Exception("невизначено");
                return Math.Pow(Math.Log10(x) + 13, 0.25);
            case 12:
                double sqrt = Math.Sqrt(x);
                if (1 - sqrt == 0) throw new Exception("ділення на 0");
                return 1 / (1 - sqrt);
            case 13:
                double sin = Math.Sin(x);
                double cos = Math.Cos(x);
                if (sin == 0) throw new Exception("ctg(x) — ділення на 0");
                return (cos / sin) - 2 * sin;
            default:
                throw new Exception("Немає такої функції.");
        }
    }
}
