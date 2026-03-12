using System;

class Calculator
{
    static void Main()
    {
        double a = 0;
        double b = 0;

        while (true)
        {
            Console.WriteLine("Enter 2 number divided by space (to exit enter 'exit')");
            var input = Console.ReadLine();

            if (input == "exit")
            {
                break;
            }

            var parts = input?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts?.Length == 0)
            {
                continue;
            }
            if (parts?.Length != 2)
            {
                Console.WriteLine("Invalid input");
                continue;
            }
            if (
                !double.TryParse(
                    parts[0],
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out a
                )
                || !double.TryParse(
                    parts[1],
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out b
                )
            )
            {
                Console.WriteLine("Invalid input");
                continue;
            }

            Console.WriteLine("Enter operation type: +, -, *, /");
            var operation = Console.ReadLine();
            switch (operation)
            {
                case "+":
                    Console.WriteLine("Result: {0}", a + b);
                    break;
                case "-":
                    Console.WriteLine("Result: {0}", a - b);
                    break;
                case "*":
                    Console.WriteLine("Result: {0}", a * b);
                    break;
                case "/":
                    if (b == 0)
                    {
                        Console.WriteLine("ERROR: Division by zero");
                        break;
                    }
                    Console.WriteLine("Result: {0}", a / b);
                    break;
                default:
                    Console.WriteLine("Invalid operation type");
                    break;
            }
        }
    }
}
