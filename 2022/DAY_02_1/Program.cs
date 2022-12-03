﻿var inputFile = "input.txt";
var drawLines = new[] {"A X", "B Y", "C Z"};
var winLines = new[] {"A Y", "B Z", "C X"};

var sum = File.ReadAllLines(inputFile).AsEnumerable().Sum(line=>
    line switch
    {
        _ when winLines.Contains(line) => 6,
        _ when drawLines.Contains(line) => 3,
        _ => 0
    }
    + line.Split(' ')[1] switch
    {
        "X" => 1,
        "Y" => 2,
        "Z" => 3,
        _ => 0
    });

Console.WriteLine(sum);