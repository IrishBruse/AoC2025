Console.Clear();

var sample = File.ReadAllText("input/sample.txt");
var input = File.ReadAllText("input/input.txt");

// Console.WriteLine("Part 1");
// Console.WriteLine();
// long sampleNumberP1 = Part1(sample);
// Console.WriteLine($"sample = {sampleNumberP1}");
// long answerNumberP1 = Part1(input);
// Console.WriteLine();
// Console.WriteLine($"answer = {answerNumberP1}");
// Console.WriteLine();


Console.WriteLine("Part 2");
Console.WriteLine();
long sampleNumberP2 = Part2(sample);
Console.WriteLine($"sample = {sampleNumberP2}");
long answerNumberP2 = Part2(input);
Console.WriteLine();
Console.WriteLine($"answer = {answerNumberP2}");
Console.WriteLine();


Console.WriteLine("Tests");
Console.WriteLine();

long Part1(string input)
{
    var lines = input.Split('\n');
    long total = 0;

    bool processRanges = true;

    List<Range> ranges = [];

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
    var lines = input.Split('\n');
    long total = 0;

    List<Range> ranges = [];

    // Parse
    foreach (var line in lines)
    {
        if (line == "") break;

        string[] splits = line.Split('-');
        var range = new Range(long.Parse(splits[0]), long.Parse(splits[1]));

        ranges.Add(range);
    }

    // Merge
    for (int i = 0; i < ranges.Count; i++)
    {
        Range range = ranges[i];
        for (int j = ranges.Count - 1; j >= 0; j--)
        {
            Range scan = ranges[j];
            if (i != j && range.Overlaps(scan))
            {
                range.Merge(scan);
                ranges.RemoveAt(j);
            }
        }
    }

    Console.WriteLine();

    // Count
    foreach (var range in ranges)
    {
        long size = range.Max - range.Min + 1;
        total += size;
    }

    return total;
}

record Range
{
    public Range(long min, long max)
    {
        Min = min;
        Max = max;
    }

    public long Min { get; set; }
    public long Max { get; set; }

    public bool Contains(long value)
    {
        return value >= Min && value <= Max;
    }

    public bool Overlaps(Range range)
    {
        return Min <= range.Max && Max >= range.Min;
    }

    public void Merge(Range range)
    {
        Min = Math.Min(Min, range.Min);
        Max = Math.Max(Max, range.Max);
    }
}
