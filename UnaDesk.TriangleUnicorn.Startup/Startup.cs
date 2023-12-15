using UnaDesk.TriangleUnicorn.Library;

Library.TestDetermineTriangleType();

while (true)
{
    Console.WriteLine("Enter three numbers separated by space:");
    try
    {
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            continue;
        }

        var numbers = input.Split(' ');
        if (numbers.Length != 3)
        {
            continue;
        }

        var t1 = double.Parse(numbers[0]);
        var t2 = double.Parse(numbers[1]);
        var t3 = double.Parse(numbers[2]);

        var triangleType = Library.DetermineTriangleType(t1, t2, t3);
        Console.WriteLine($"Triangle type: {triangleType}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Something went wrong: {ex.Message}. Try again");
    }
}