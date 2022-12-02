// First solution:
int[,] m = { { 3, 0, 6 }, { 6, 3, 0 }, { 0, 6, 3 } };
Console.WriteLine(File.ReadAllLines("input").Sum(r => 1 + r[2] - 'X' + m[r[2] - 'X', r[0] - 'A']));

// Improved solution without the hardcoded matrix:
Console.WriteLine(File.ReadAllLines("input").Sum(r => r[2] - 'W' + (r[2] - r[0] - 1) % 3 * 3));

// The improved solution is a simplified Linq equivalent to:
//string[] rounds = File.ReadAllLines("input");
//int total = 0;
//foreach (string r in rounds)
//{
//    int score1 = r[2] - 'X' + 1;
//    int score2 = ((r[2] - 'X' + 1) - (r[0] - 'A') + 3) % 3 * 3;
//    total += score1 + score2;
//}