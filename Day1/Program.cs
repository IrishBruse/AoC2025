Console.Clear();

var lines = File.ReadAllLines("input/input2");

int zeros = 0;
int position = 50;

foreach (var line in lines)
{
    Console.WriteLine("# " + line);
    int number = int.Parse(line[1..]);

    bool isLeft = line[0] == 'L';

    int fullLoops = number / 100;
    zeros += fullLoops;

    int rem = number % 100;
    if (isLeft)
    {
        if (position > 0 && position - rem < 0)
        {
            zeros += 1;
        }
    }
    else
    {
        if (position + rem > 100)
        {
            zeros += 1;
        }
    }

    rem = isLeft ? 100 - rem : rem;

    position = (position + rem) % 100;


    if (position == 0)
    {
        zeros += 1;
    }
}

Console.WriteLine();
Console.WriteLine("Password: " + zeros);
