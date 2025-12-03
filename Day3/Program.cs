Console.Clear();

var sample = File.ReadAllText("input/sample.txt");
var input = File.ReadAllText("input/input.txt");

Console.WriteLine("98 = " + GetLargestPair("987654321111111"));
Console.WriteLine("89 = " + GetLargestPair("811111111111119"));
Console.WriteLine("78 = " + GetLargestPair("234234234234278"));
Console.WriteLine("92 = " + GetLargestPair("818181911112111"));

Console.WriteLine("\nsample = " + Part1(sample));
Console.WriteLine("\nsample = " + Part1(input));

long Part1(string input)
{
    var banks = input.Split("\n");

    long total = 0;

    foreach (var bank in banks)
    {
        int pair = GetLargestPair(bank);

        Console.WriteLine(pair);
        total += pair;
    }

    return total;
}

static int GetLargestPair(string bank)
{
    Console.WriteLine($"# {bank}");
    int[] batteries = bank.ToCharArray().Select(b => int.Parse(b.ToString())).ToArray();

    int firstDigit = 0;
    int index = 0;

    for (int i = 0; i < batteries.Length; i++)
    {
        int val = batteries[i];

        if (firstDigit < val)
        {
            firstDigit = val;
            index = i + 1;
        }
    }

    int secondDigit = 0;
    int secondIndex = 0;

    for (int i = index == batteries.Length ? 0 : index; i < batteries.Length; i++)
    {
        int val = batteries[i];

        if (secondDigit < val && i != index - 1)
        {
            secondDigit = val;
            secondIndex = i;
        }
    }

    if (index - 1 < secondIndex)
    {
        return (firstDigit * 10) + secondDigit;
    }
    else
    {
        return (secondDigit * 10) + firstDigit;
    }
}

long Part2(string input)
{
    return 0;
}
