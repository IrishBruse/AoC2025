Console.Clear();

var sample = File.ReadAllText("input/sample.txt");
var input = File.ReadAllText("input/input.txt");

Console.WriteLine("Part 1");
Console.WriteLine();
long sampleNumberP1 = Part1(sample);
Console.WriteLine($"sample = {sampleNumberP1}");
long answerNumber = Part1(input);
Console.WriteLine();
Console.WriteLine($"answer = {answerNumber}");
Console.WriteLine();

Console.WriteLine("Tests");
Console.WriteLine();

long Part1(string input)
{
    var lines = input.Split('\n');
    long total = 0;

    bool processRanges = true;

    List<Range> ranges = new();

    foreach (var line in lines)
    {
        if (processRanges)
        {
            if (line == "")
            {
                processRanges = false;
                continue;
            }
            Console.WriteLine("range: " + line);

            string[] range = line.Split('-');

            ranges.Add(new(long.Parse(range[0]), long.Parse(range[1])));
        }
        else
        {
            Console.WriteLine("id: " + line);
            long value = long.Parse(line);

            bool fresh = false;

            foreach (var range in ranges)
            {
                if (range.Contains(value))
                {
                    fresh = true;
                }
            }

            if (fresh)
            {
                total += 1;
            }
        }
    }

    return total;
}

long Part2(string input)
{
    return 0;
}

record Range(long Min, long Max)
{
    public bool Contains(long value)
    {
        return value >= Min && value <= Max;
    }
}
