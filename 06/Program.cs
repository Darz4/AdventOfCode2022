string input = File.OpenText("06/input.txt").ReadLine();

int detect(string s, int len)
    => s.Select((x,i) => i).Skip(len-1).TakeWhile(i => s.Substring(i-len+1,len).Distinct().Count() < len).Count() + len;

Console.WriteLine(detect(input, 4));
Console.WriteLine(detect(input, 14));