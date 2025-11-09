using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        while (true)
        {
            PrintMenu();
            char op = ReadOperation();
            if (op == 'q') break;

            double a = ReadDouble();
            double b = ReadDouble(op == '/'); // druhé číslo nesmí být 0, když je dělení

            double res = Compute(op, a, b);
            PrintResult(op, a, b, res);
            Console.WriteLine();
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine("Vyberte operaci: +  -  *  /   (q nebo exit = konec)");
    }

    static char ReadOperation()
    {
        while (true)
        {
            Console.Write("Operace: ");
            string? s = Console.ReadLine()?.Trim().ToLower();
            if (s == "exit") return 'q';
            if (!string.IsNullOrEmpty(s))
            {
                char c = s[0];
                if (c == '+' || c == '-' || c == '*' || c == '/' || c == 'q')
                    return c;
            }
            Console.WriteLine("Neplatná operace, zadejte +, -, *, / nebo q.");
        }
    }

    static double ReadDouble(bool nonZero = false)
    {
        while (true)
        {
            Console.Write(nonZero ? "Zadejte nenulové číslo: " : "Zadejte číslo: ");
            string? t = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(t)) { Console.WriteLine("Prázdný vstup."); continue; }
            t = t.Replace(',', '.');
            if (double.TryParse(t, NumberStyles.Float, CultureInfo.InvariantCulture, out double v))
            {
                if (nonZero && v == 0.0) { Console.WriteLine("Hodnota nesmí být 0."); continue; }
                return v;
            }
            Console.WriteLine("Neplatné číslo.");
        }
    }

    static double Compute(char operation, double operand1, double operand2)
    {
        return operation switch
        {
            '+' => operand1 + operand2,
            '-' => operand1 - operand2,
            '*' => operand1 * operand2,
            '/' => operand1 / operand2,
            _   => 0
        };
    }

    static void PrintResult(char operation, double operand1, double operand2, double result)
    {
        Console.WriteLine($"{operand1} {operation} {operand2} = {result}");
    }
}
