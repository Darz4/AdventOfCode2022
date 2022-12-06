using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines("05/input.txt");

string operate(string[] lines, bool is9001)
{
    var stacks = new List<char>[9];
    for (int i = 0; i < stacks.Length; ++i)
        stacks[i] = lines.Take(8).Reverse().Select(x => x[1+i*4]).Where(x => x != ' ').ToList();

    foreach (var line in lines.Skip(10))
    {
        int[] c = Regex.Split(line, @"move (\d+) from (\d+) to (\d+)").Where(x => x != "").Select(x => int.Parse(x)).ToArray();
        List<char> crates = stacks[c[1]-1].GetRange(stacks[c[1]-1].Count - c[0], c[0]);
        stacks[c[1]-1].RemoveRange(stacks[c[1]-1].Count - c[0], c[0]);
        stacks[c[2]-1].AddRange(is9001 ? crates : Enumerable.Reverse(crates));
    }

    return new string(stacks.Select(x => x.Last()).ToArray());
}

Console.WriteLine(operate(lines, false));
Console.WriteLine(operate(lines, true));