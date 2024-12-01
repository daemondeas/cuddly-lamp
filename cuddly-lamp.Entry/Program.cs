using cuddly_lamp.Input;
using cuddly_lamp.solutions.fsharp;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
(var a, var b) = new Input1().FirstFormattedInput(true);
Console.WriteLine(Day01.firstPuzzle(a, b));
Console.WriteLine(Day01.secondPuzzle(a, b));
