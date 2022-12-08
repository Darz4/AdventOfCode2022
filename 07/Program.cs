string input = File.ReadAllText("07/input.txt");
var cmdLines = input.Split('$').Select(x => x.Split("\n").Where(x => x != "")).Where(x => x.Count() > 0);
var dirFiles = new SortedDictionary<string, List<(string, int)>>();
var curDir = new Stack<string>();

foreach (var cmdLine in cmdLines)
{
    var cmd = cmdLine.First().Trim().Split(' ').Select(x => x.Trim()).ToArray();

    if (cmd[0] == "cd")
    {
        if (cmd[1] == "..") curDir.Pop();
        else curDir.Push(cmd[1]);
    }
    else if (cmd[0] == "ls")
    {
        string dirPath = "/" + string.Join('/', curDir.Reverse().Skip(1));
        dirFiles[dirPath] = cmdLine.Skip(1).Select(x => x.Split(' ')).Where(x => x[0] != "dir").Select(x => (x[1], int.Parse(x[0]))).ToList();
    }
}

var dirSizes = dirFiles.ToDictionary(x => x.Key, x => dirFiles.Where(e => e.Key.StartsWith(x.Key)).SelectMany(x => x.Value).Sum(e => e.Item2));

foreach (var dirSize in dirSizes)
    Console.WriteLine($"{dirSize.Key}  ({dirSize.Value})");

Console.WriteLine(dirSizes.Where(x => x.Value <= 100000).Sum(x => x.Value));