string[] s = File.ReadAllLines("input.txt");
var val = (char c) => c <= 'Z' ? c - 'A' + 27 : c - 'a' + 1;
Console.WriteLine(s.Sum(x => val(x.First(c => (x.IndexOf(c) * 2 / x.Length + x.LastIndexOf(c) * 2 / x.Length) % 2 == 1))));
Console.WriteLine(s.Select((x,i) => i).Sum(i => i % 3 == 0 ? val(s[i].Intersect(s[i+1]).Intersect(s[i+2]).First()) : 0));
