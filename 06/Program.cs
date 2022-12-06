
int detect(string in, int len)
    => in.Select((x,i) => i)
         .Skip(len-1)
         .TakeWhile(
             i => in.Substring(i-len+1, len)
                    .Distinct()
                    .Count() < len
         )
         .Count() + len;

string input = File.OpenText("06/input.txt").ReadLine();
Console.WriteLine(detect(input, 4));
Console.WriteLine(detect(input, 14));