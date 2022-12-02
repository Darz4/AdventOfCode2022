int[,] m = { { 3, 0, 6 }, { 6, 3, 0 }, { 0, 6, 3 } };
Console.WriteLine(File.ReadAllLines("input").Sum(r => 1 + r[2]-'X' + m[r[2]-'X', r[0]-'A']));