// See https://aka.ms/new-console-template for more information

using CacheCalculator;

Console.WriteLine("Hello, World!");
Calculator cCalculator = new Calculator();
cCalculator.SetParams("secureLogin=ext_test1&options=GetFeatures");
cCalculator.SetKey("testKey");
Console.WriteLine("hash = " + cCalculator.Calculate());