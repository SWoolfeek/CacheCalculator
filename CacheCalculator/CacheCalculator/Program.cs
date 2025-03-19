// See https://aka.ms/new-console-template for more information

using CacheCalculator;

class Program
{
    static void Main()
    {
        Calculator cCalculator = new Calculator();
        Console.WriteLine("Hello! Write parameters (Example: key1=value1&key2=value2):");
        cCalculator.SetParams(Console.ReadLine());
        Console.WriteLine("Enter the secret key:");
        cCalculator.SetKey(Console.ReadLine());

        Console.WriteLine("Hash result:");
        Console.WriteLine(cCalculator.Calculate());
        
        Console.WriteLine("Press any key to exit...");
        Console.WriteLine();
    }
}