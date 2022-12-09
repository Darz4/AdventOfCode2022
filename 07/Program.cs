string[] lines = File.ReadAllLines("07/input.txt");
var dirFiles = new SortedDictionary<string, List<(string, int)>>();
var curDir = new Stack<string>();

foreach (var line in lines)
{
    var cmd = line.Split(' ').ToArray();
    string dirPath = "/" + string.Join('/', curDir.Reverse().Skip(1));
    if (line.StartsWith("$ cd"))
        if (cmd[2] == "..") curDir.Pop();
        else curDir.Push(cmd[2]);
    else if (line.StartsWith("$ ls"))
        dirFiles[dirPath] = new List<(string, int)>();
    else if (int.TryParse(cmd[0], out var size))
        dirFiles[dirPath].Add((cmd[1], size));
}

var dirSizes = dirFiles.ToDictionary(x => x.Key, x => dirFiles.Where(e => e.Key.StartsWith(x.Key)).SelectMany(x => x.Value).Sum(e => e.Item2));

Console.WriteLine(dirSizes.Where(x => x.Value <= 100000).Sum(x => x.Value));
Console.WriteLine(dirSizes.Where(x => x.Value >= dirSizes["/"] - 40000000).Min(x => x.Value));