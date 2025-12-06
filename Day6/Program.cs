Console.Clear();

var sample = File.ReadAllText("input/sample.txt");
var input = File.ReadAllText("input/input.txt");

Console.WriteLine("Part 1");
Console.WriteLine();
long sampleNumberP1 = Part1(sample);
Console.WriteLine($"sample = {sampleNumberP1}");
long answerNumberP1 = Part1(input);
Console.WriteLine();
Console.WriteLine($"answer = {answerNumberP1}");
Console.WriteLine();


// Console.WriteLine("Part 2");
// Console.WriteLine();
// long sampleNumberP2 = Part2(sample);
// Console.WriteLine($"sample = {sampleNumberP2}");
// long answerNumberP2 = Part2(input);
// Console.WriteLine();
// Console.WriteLine($"answer = {answerNumberP2}");
// Console.WriteLine();

Console.WriteLine("Tests");
Console.WriteLine();

long Part1(string input)
{
    var lines = input.Split('\n');

    int state = 0;

    string[] ops = [];

    long[] values = [];

    for (int l = lines.Length - 1; l >= 0; l--)
    {
        string? line = lines[l];

        if (state == 0)
        {
            ops = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            values = new long[ops.Length];

            state = 1;
        }
        else if (state == 1)
        {
            string[] numbers = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < values.Length; i++)
            {
                long value = long.Parse(numbers[i]);
                values[i] = value;
            }

            state = 2;
        }
        else if (state == 2)
        {
            string[] numbers = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < values.Length; i++)
            {
                long value = long.Parse(numbers[i]);
                char op = ops[i][0];

                switch (op)
                {
                    case '*':
                        values[i] = values[i] * value;
                        break;

                    case '+':
                        values[i] = values[i] + value;
                        break;

                    default:
                        Console.WriteLine(op);
                        break;
                }
            }
        }
    }

    long total = 0;

    for (int i = 0; i < values.Length; i++)
    {
        var val = values[i];
        total += val;
    }

    return total;
}

long Part2(string input)
{
    return 0;
}
