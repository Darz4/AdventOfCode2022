using System.Text.RegularExpressions;

string[] input = File.ReadAllLines("04/input.txt");

// Part 1:
Console.WriteLine(
    input.Select(line =>
        Regex.Split(line, @"(\d+)-(\d+),(\d+)-(\d+)")
        .Where(x => x != "").Select(x => int.Parse(x)).ToArray())
    .Count(v => (v[0]-v[2]) * (v[1]-v[3]) <= 0)
);