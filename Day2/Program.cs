// var text = File.ReadAllText("input/sample.txt");
var text = File.ReadAllText("input/input1.txt");
var ranges = text.Split(',');

long invalidSum = 0;

foreach (var range in ranges)
{
    string[] minxmax = range.Split("-");

    string minText = minxmax[0];
    long min = long.Parse(minText);

    string maxText = minxmax[1];
    long max = long.Parse(maxText);

    Console.WriteLine("# " + min + " " + max);

    for (long id = min; id <= max; id++)
    {
        string idText = id.ToString();
        if (idText.Length % 2 != 0) continue;

        int halfLen = idText.Length / 2;
        if (idText[..halfLen] == idText[halfLen..])
        {
            Console.WriteLine(id);
            invalidSum += id;
        }
    }

}

Console.WriteLine();
Console.WriteLine("invalidSum: " + invalidSum);
