string[] s = File.ReadAllLines("input.txt");

// Calculation function of item priority
var prio = (char c) => c <= 'Z' ? c - 'A' + 27 : c - 'a' + 1;

// Part 1:
// when an index i is in the first part of a string of length s, i/(s/2) is equal to 0.
// when an index i is in the second part of a string of length s, i/(s/2) is equal to 1.
// for each character c we apply this calculation over the two most distant indexes found for c
// if the pair of results (a,b) is (0,0) or (1,1), it means the occurrences are in the same half of the string [1]
// if the pair of results (a,b) is (0,1) or (1,0), it means the occurrences are not in the same half of the string [2]
// then (a+b)%2 is equal to 0 in case [1] and is equal to 1 in case [2] (which is the one we are looking for)
Console.WriteLine(s.Sum(x => prio(x.First(c => (x.IndexOf(c) * 2 / x.Length + x.LastIndexOf(c) * 2 / x.Length) % 2 == 1))));

// Part 2:
// iterate only through elements that have an index i that is a multiple of 3
// for each of these elements, use Intersect to find the common character
Console.WriteLine(s.Select((x,i) => i).Where(i => i%3 == 0).Sum(i => prio(s[i].Intersect(s[i+1]).Intersect(s[i+2]).First())));