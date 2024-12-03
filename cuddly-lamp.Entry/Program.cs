using cuddly_lamp.Input;
using cuddly_lamp.solutions.fsharp;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
(var a, var b) = new Input1().FirstFormattedInput(true);
Console.WriteLine(Day01.firstPuzzle(a, b));
Console.WriteLine(Day01.secondPuzzle(a, b));

var testInp = new Input2().FirstFormattedInput(false);
var realInp = new Input2().FirstFormattedInput(true);

Console.WriteLine(Day02.secondPuzzle(testInp));
Console.WriteLine(Day02.secondPuzzle(realInp));

var input3 = new Input3();

Console.WriteLine(Day03.firstPuzzle(input3.FirstFormattedInput(false)));
Console.WriteLine(Day03.firstPuzzle(input3.FirstFormattedInput(true)));

Console.WriteLine(Day03.secondPuzzle(input3.SecondFormattedInput(false)));
Console.WriteLine(Day03.secondPuzzle(input3.SecondFormattedInput(true)));
