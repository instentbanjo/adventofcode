namespace _2015;

public class Day2
{
    
    private static string[] _input =  File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../Day2/input.txt"));

    static Day2()
    {
      Part1();
      Part2();
    }

    static void Part1(){
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
    
    static void Part2(){
        int totalRibbonArea = 0;
        int[][] dimensions = new int[_input.Length][];
        for (int i = 0; i < dimensions.Length; i++)
        {
            dimensions[i] = Array.ConvertAll(_input[i].Split("x"), input => int.Parse(input));
            int x = dimensions[i][0], y= dimensions[i][1], z = dimensions[i][2];
            totalRibbonArea += x*y*z + Math.Min(2*x+2*y, Math.Min(2*y+2*z, 2*z+2*x));
        }
        Console.WriteLine(totalRibbonArea);
    }
}
