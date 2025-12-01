var lines = File.ReadAllLines("input/input1");


int password = 0;
int position = 50;
Console.WriteLine(position);

foreach (var line in lines)
{
    int number = int.Parse(line[1..]);

    if (line[0] == 'L') number = -number;

    position += number;

    position %= 100;
    if (position < 0) position += 100;

    Console.WriteLine(position);

    if (position == 0)
    {
        password++;
    }
}

Console.WriteLine();
Console.WriteLine(password);
