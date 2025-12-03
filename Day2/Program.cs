Console.Clear();

var sample = File.ReadAllText("input/sample.txt");
var input = File.ReadAllText("input/input1.txt");

Console.WriteLine("1188511885: " + IsInvalid("1188511885"));
Console.WriteLine("1188511882: " + IsInvalid("1188511882"));
Console.WriteLine("111: " + IsInvalid("111"));
Console.WriteLine("113: " + IsInvalid("113"));

Console.WriteLine("sample " + Run(sample));
Console.WriteLine("input " + Run(input));

static long Run(string input)
{
    long invalidSum = 0;
    var ranges = input.Split(',');

    foreach (var range in ranges)
    {
        string[] minxmax = range.Split("-");

        string minText = minxmax[0];
        long min = long.Parse(minText);

        string maxText = minxmax[1];
        long max = long.Parse(maxText);

        for (long id = min; id <= max; id++)
        {
            string idText = id.ToString();

            if (IsInvalid(idText))
            {
                Console.WriteLine(id);
                invalidSum += id;
            }

        }
    }

    return invalidSum;
}

static bool IsInvalid(string idText)
{
    if (idText.Length == 1) return false;

    int halfLen = (int)MathF.Ceiling(idText.Length / 2f);

    for (int w = 1; w <= halfLen; w++)
    {
        string pattern = idText[0..w];

        if (idText.Length % w != 0) continue;

        bool valid = true;
        for (int i = w; i < idText.Length; i += w)
        {
            int end = i + w;
            var range = idText[i..end];

            if (range != pattern)
            {
                valid = false;
                break;
            }
        }

        if (valid)
        {
            return true;
        }
    }

    return false;
}
