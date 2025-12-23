using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("kalkulačka");

        while (true)
        {
            // Zvolení operace
            Console.Write("Zadej operaci (+, -, *, /), nebo 'konec': ");
            string operace = Console.ReadLine();

            if (operace == "konec")
            {
                Console.WriteLine("Program ukončen.");
                break;
            }

            // Načtení prvního čísla s kontrolou
            Console.Write("Zadej první číslo: ");
            double a;
            while (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("To není platné číslo, zkus to znovu.");
                Console.Write("Zadej první číslo: ");
            }

            // Načtení druhého čísla s kontrolou
            Console.Write("Zadej druhé číslo: ");
            double b;
            while (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("To není platné číslo, zkus to znovu.");
                Console.Write("Zadej druhé číslo: ");
            }

            // Výpočet podle zvolené operace
            if (operace == "+")
            {
                Console.WriteLine("Výsledek: " + (a + b));
            }
            else if (operace == "-")
            {
                Console.WriteLine("Výsledek: " + (a - b));
            }
            else if (operace == "*")
            {
                Console.WriteLine("Výsledek: " + (a * b));
            }
            else if (operace == "/")
            {
                if (b == 0)
                {
                    Console.WriteLine("Dělení nulou není povoleno");
                }
                else
                {
                    Console.WriteLine("Výsledek: " + (a / b));
                }
            }
            else
            {
                Console.WriteLine("Neplatná operace, zkus to znovu.");
            }
        }
    }
}

