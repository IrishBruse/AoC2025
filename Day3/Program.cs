Console.Clear();

var sample = File.ReadAllText("input/sample.txt");
var input = File.ReadAllText("input/input.txt");

Console.WriteLine("Tests");
Console.WriteLine("98 = " + GetLargest("987654321111111", 2));
Console.WriteLine("89 = " + GetLargest("811111111111119", 2));
Console.WriteLine("78 = " + GetLargest("234234234234278", 2));
Console.WriteLine("92 = " + GetLargest("818181911112111", 2));
Console.WriteLine();

Console.WriteLine("Part 1");
Console.WriteLine("sample 357 = " + Part1(sample));
Console.WriteLine("answer 17694 = " + Part1(input));
Console.WriteLine();

Console.WriteLine("Part 2");
Console.WriteLine("sample 3121910778619 = " + Part2(sample));
Console.WriteLine("answer 175659236361660 = " + Part2(input));
Console.WriteLine();

long Part1(string input)
{
    var banks = input.Split("\n");

    long total = 0;

    foreach (var bank in banks)
    {
        total += GetLargest(bank, 2);
    }

    return total;
}

long Part2(string input)
{
    var banks = input.Split("\n");

    long total = 0;

    foreach (var bank in banks)
    {
        total += GetLargest(bank, 12);
    }

    return total;
}

long GetLargest(string bank, int size)
{
    List<int> digits = [];
    List<int> batteries = bank.ToCharArray().Select(c => int.Parse(c.ToString())).ToList();

    while (digits.Count != size)
    {
        int largest = 0;
        int index = 0;
        if (batteries.Count < size - digits.Count)
        {
            for (int i = 0; i < size - digits.Count; i++)
            {
                digits.Add(batteries[batteries.Count + 1 - i]);
            }
        }
        else
        {
            for (int i = 0; i < batteries.Count - (size - 1 - digits.Count); i++)
            {
                if (largest < batteries[i])
                {
                    largest = batteries[i];
                    index = i;
                }
            }
            batteries.RemoveRange(0, index + 1);
        }

        digits.Add(largest);
    }

    long answer = 0;

    for (int i = size - 1; i >= 0; i--)
    {
        long val = (long)(digits[i] * Math.Pow(10, size - i - 1));
        answer += val;
    }

    return answer;
}
