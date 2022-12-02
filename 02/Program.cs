// PART 1
// First proposal:
int[,] m = { { 3, 0, 6 }, { 6, 3, 0 }, { 0, 6, 3 } };
Console.WriteLine(File.ReadAllLines("input").Sum(r => 1 + r[2] - 'X' + m[r[2] - 'X', r[0] - 'A']));

// Improved proposal without the hardcoded matrix:
Console.WriteLine(File.ReadAllLines("input").Sum(r => r[2] - 'W' + (r[2] - r[0] - 1) % 3 * 3));

// PART 2
Console.WriteLine(File.ReadAllLines("input").Sum(r => ((r[2] - 'X') * 3) + ((r[0] + r[2] - 1) % 3) + 1));