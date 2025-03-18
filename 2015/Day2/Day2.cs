namespace _2015;

public class Day2
{
    
    private static string[] _input =  File.ReadAllLines("../../../Day2/input.txt");

    static Day2()
    {
        int totalArea = 0;
        int[][] dimensions = new int[_input.Length][];
        for (int i = 0; i < dimensions.Length; i++)
        {
            dimensions[i] = Array.ConvertAll(_input[i].Split("x"), input => int.Parse(input));
            int x = dimensions[i][0], y= dimensions[i][1], z = dimensions[i][2];
            totalArea += 2*x*y + 2*y*z + 2*z*x + Math.Min(x*y, Math.Min(y*z, z*x));
        }
        Console.WriteLine(totalArea);
    }
}