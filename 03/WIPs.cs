
public class Day03
{
    public void v1(string[] s)
    {
        int result1 = 0, result2 = 0;
        var val = (int item) => item <= 'Z' ? item - 'A' + 27 : item - 'a' + 1;

        for (int i = 0; i < s.Length; ++i)
        {
            var s1 = s[i].Substring(0, s[i].Length/2);
            var s2 = s[i].Substring(s[i].Length/2, s[i].Length/2);
            result1 += val(s1.Intersect(s2).First());
            if (i % 3 == 0)
                result2 += val(s[i].Intersect(s[i+1]).Intersect(s[i+2]).First());
        }

        Console.WriteLine(result1);
        Console.WriteLine(result2);
    }

    public void v2(string[] s)
    {
        int result1 = 0, result2 = 0;
        var val = (int item) => item <= 'Z' ? item - 'A' + 27 : item - 'a' + 1;
        
        for (int i = 0; i < s.Length; ++i)
        {
            result1 += val(s[i].First(x => s[i].IndexOf(x) < s[i].Length/2 && s[i].LastIndexOf(x) >= s[i].Length/2));
            if (i % 3 == 0)
                result2 += val(s[i].Intersect(s[i+1]).Intersect(s[i+2]).First());
        }

        Console.WriteLine(result1);
        Console.WriteLine(result2);
    }

    public void v3(string[] s)
    {
        var val = (int item) => item <= 'Z' ? item - 'A' + 27 : item - 'a' + 1;
        int result1 = s.Sum(x => val(x.First(c => (x.IndexOf(c) * 2 / x.Length + x.LastIndexOf(c) * 2 / x.Length) % 2 == 1)));
        int result2 = 0;
        for (int i = 0; i < s.Length; i += 3)
            result2 += val(s[i].Intersect(s[i+1]).Intersect(s[i+2]).First());

        Console.WriteLine(result1);
        Console.WriteLine(result2);
    }
}