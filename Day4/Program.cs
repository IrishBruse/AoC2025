Console.Clear();

var sample = File.ReadAllText("input/sample.txt");
var input = File.ReadAllText("input/input.txt");

Console.WriteLine("Part 1");
Console.WriteLine("sample(13) = " + Part1(sample));
Console.WriteLine("answer = " + Part1(input));
Console.WriteLine();

Console.WriteLine("Part 2");
long sampleNumber = Part2(sample);
Console.WriteLine("sample = " + sampleNumber);
long answerNumber = Part2(input);
Console.WriteLine("answer = " + answerNumber);
Console.WriteLine();


// @.@
// @@@
// @.@
char[] grid = string.Join("", new string[] {
    "@.@",
    "@@@",
    "@.@"
}).ToCharArray();

Console.WriteLine("Tests");
Console.WriteLine("98 = " + GetNeighbours(grid, 3, 3, 1, 1));
Console.WriteLine("98 = " + GetNeighbours(grid, 3, 3, 0, 0));
Console.WriteLine("98 = " + GetNeighbours(grid, 3, 3, 2, 2));
Console.WriteLine();

long Part1(string input)
{
    int width = input.IndexOf('\n');
    int height = input.Split("\n").Length;

    char[] grid = input.Replace("\n", "").ToCharArray();

    long total = 0;

    // ..@@.@@@@.
    // ..x..x@@@x

    char[] newGrid = grid;

    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            char cell = grid[width * y + x];

            int neighbours = GetNeighbours(grid, width, height, x, y);
            if (neighbours < 4 && cell == '@')
            {
                total += 1;
                Console.Write('x');
            }
            else
            {
                Console.Write(cell);
            }

            newGrid[width * y + x] = '.';
        }
        Console.WriteLine();
    }

    return total;
}

int GetNeighbours(char[] grid, int width, int height, int x, int y)
{
    int neighbours = 0;
    for (int ry = -1; ry <= 1; ry++)
    {
        for (int rx = -1; rx <= 1; rx++)
        {
            int cx = rx + x;
            int cy = ry + y;
            if (cx < 0 || cx >= width || cy < 0 || cy >= height || (ry == 0 && rx == 0))
            {
                continue;
            }

            char cell = grid[width * cy + cx];

            if (cell == '@')
            {
                neighbours += 1;
            }

        }
    }

    return neighbours;
}


long Part2(string input)
{
    int width = input.IndexOf('\n');
    int height = input.Split("\n").Length;

    char[] grid = input.Replace("\n", "").ToCharArray();

    long removed = 0;

    int removeState = 1;
    char[] nextGrid = grid;
    while (removeState > 0)
    {
        removeState = 0;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int index = width * y + x;
                char cell = grid[index];

                int neighbours = GetNeighbours(grid, width, height, x, y);
                if (neighbours < 4 && cell == '@')
                {
                    removeState += 1;
                    nextGrid[index] = '.';
                }
                else
                {
                    Console.Write(cell);
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine(removeState);
        removed += removeState;
        nextGrid.CopyTo(nextGrid, 0);
    }

    return removed;
}
