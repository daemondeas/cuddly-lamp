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
/*
var input4 = new Input4();
var test4 = input4.FirstFormattedInput(false);
var real4 = input4.FirstFormattedInput(true);

Console.WriteLine(Day04.firstPuzzle(test4.Item1, test4.Item2, test4.Item3));
Console.WriteLine(Day04.firstPuzzle(real4.Item1, real4.Item2, real4.Item3));

Console.WriteLine(Day04.secondPuzzle(test4.Item1, test4.Item2, test4.Item3));
Console.WriteLine(Day04.secondPuzzle(real4.Item1, real4.Item2, real4.Item3));*/

var input5 = new Input5();
var test5 = input5.FirstFormattedInput(false);
var real5 = input5.FirstFormattedInput(true);
Console.WriteLine(Day05.firstPuzzle(test5.Item1, test5.Item2));
Console.WriteLine(Day05.firstPuzzle(real5.Item1, real5.Item2));

Console.WriteLine(Day05.secondPuzzle(test5.Item1, test5.Item2));
Console.WriteLine(Day05.secondPuzzle(real5.Item1, real5.Item2));
