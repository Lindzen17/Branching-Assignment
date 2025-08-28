using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

        decimal weight = ReadNonNegativeDecimal("Please enter the package weight: ");
        if (weight > 50)
        {
            Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            return;
        }

        decimal width = ReadNonNegativeDecimal("Please enter the package width: ");
        decimal height = ReadNonNegativeDecimal("Please enter the package height: ");
        decimal length = ReadNonNegativeDecimal("Please enter the package length: ");

        if ((width + height + length) > 50)
        {
            Console.WriteLine("Package too big to be shipped via Package Express.");
            return;
        }

        // Quote = (height * width * length * weight) / 100
        decimal volume = height * width * length;
        decimal quote = (volume * weight) / 100m;

        // Display as a dollar amount (2 decimals, current culture currency symbol)
        Console.WriteLine($"Your estimated total for shipping this package is: {quote.ToString("C2")}");
        Console.WriteLine("Thank you!");
    }

    static decimal ReadNonNegativeDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal value) && value >= 0)
                return value;

            Console.WriteLine("Please enter a valid non-negative number.");
        }
    }
}
