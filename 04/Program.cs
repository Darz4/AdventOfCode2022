using System.Text.RegularExpressions;

// Parsing
var input = File.ReadAllLines("04/input.txt")
            .Select(line => Regex.Split(line, @"(\d+)-(\d+),(\d+)-(\d+)")
            .Where(x => x != "").Select(x => int.Parse(x)).ToArray());

Console.WriteLine(input.Count(v => (v[0]-v[2]) * (v[1]-v[3]) <= 0));
Console.WriteLine(input.Count(v => (v[0]-v[3]) * (v[1]-v[2]) <= 0));