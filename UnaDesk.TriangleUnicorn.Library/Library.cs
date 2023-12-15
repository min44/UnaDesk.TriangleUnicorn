namespace UnaDesk.TriangleUnicorn.Library;

public static class Library
{
    public enum TriangleType
    {
        Acute,
        Obtuse,
        Rectangular,
        DoesNotExist
    }

    public static TriangleType DetermineTriangleType(double s1, double s2, double s3, double? tolerance = 0.01)
    {
        var inputLengthZeroOrLess = s1 <= 0 || s2 <= 0 || s3 <= 0;
        if (inputLengthZeroOrLess)
        {
            // var msg = "One or more side length are zero or less";
            return TriangleType.DoesNotExist;
        }

        var incorrectLength = s1 + s2 <= s3 || s1 + s3 <= s2 || s2 + s3 <= s1;
        if (incorrectLength)
        {
            // var msg = "Triangle with such sides does not exist";
            return TriangleType.DoesNotExist;
        }

        var sides = new[] {s1, s2, s3};
        Array.Sort(sides);

        var a = sides[0];
        var b = sides[1];
        var c = sides[2];

        var rectangular = Math.Abs(a * a + b * b - c * c) < tolerance;
        if (rectangular)
        {
            return TriangleType.Rectangular;
        }

        var acute = a * a + b * b > c * c;
        if (acute)
        {
            return TriangleType.Acute;
        }

        var obtuse = a * a + b * b < c * c;
        if (obtuse)
        {
            return TriangleType.Obtuse;
        }

        return TriangleType.DoesNotExist;
    }

    public static void TestDetermineTriangleType()
    {
        var testCases = new[]
        {
            new {s1 = 3.0, s2 = 4.0, s3 = 5.0, expected = TriangleType.Rectangular},
            new {s1 = 3.0, s2 = 3.0, s3 = 3.0, expected = TriangleType.Acute},
            new {s1 = 3.0, s2 = 3.0, s3 = 5.0, expected = TriangleType.Obtuse},
            new {s1 = 0.0, s2 = 3.0, s3 = 5.0, expected = TriangleType.DoesNotExist},
            new {s1 = 3.0, s2 = 3.0, s3 = 7.0, expected = TriangleType.DoesNotExist},
        };

        foreach (var tc in testCases)
        {
            var actual = DetermineTriangleType(tc.s1, tc.s2, tc.s3);
            if (actual != tc.expected)
            {
                throw new Exception($"Test failed. Actual={actual}. Expected={tc.expected}");
            }

            Console.WriteLine($"s1={tc.s1}, s2={tc.s2}, s3={tc.s3}. Actual={actual}. Expected={tc.expected}\n");
        }
    }
}