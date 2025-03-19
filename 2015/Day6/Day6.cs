namespace _2015;

public class Day6
{
    
    private static string[] _input =  File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../Day6/input.txt"));
    private static bool[,] _lightGrid = new bool[1000,1000];

    static Day6()
    {
      Console.WriteLine("---6---");
      Part1();
    }

    static void Part1(){
      foreach (string input in _input)
      {
        ProcessLine(input);
      }
      Console.WriteLine(CTVIM());
    }

    static void ProcessLine(string line){
      string[] arr = line.Split(" ");
      if (arr[0]=="turn")
      {
        Turn(arr[1]=="on", CSITI(arr[2]), CSITI(arr[4]));
      }else
      {
        Toggle(CSITI(arr[1]), CSITI(arr[3]));
      }

    }
    
    static void Turn(bool value, int[] rangeStart,int[] rangeEnd){
      for (int i = rangeStart[0]; i <= rangeEnd[0]; i++)
      {
        for (int y = rangeStart[1]; y <= rangeEnd[1]; y++)
        {
          _lightGrid[i,y] = value;
        }
      }
    }

    static void Toggle(int[] rangeStart,int[] rangeEnd){
      for (int i = rangeStart[0]; i <= rangeEnd[0]; i++)
      {
        for (int y = rangeStart[1]; y <= rangeEnd[1]; y++)
        {
          _lightGrid[i,y] = !_lightGrid[i,y];
        }
      }

    }

    //CountTrueValuesInMatrix
    static int CTVIM(){
      int count = 0;
      for (int i = 0; i < _lightGrid.GetLength(0); i++)
      {
        for (int y = 0; y < _lightGrid.GetLength(1); y++)
        {
          if (_lightGrid[i,y]) count++;
        }
      }
      return count;
    }

    //CommaSeperatedIntstringToIntarray
    static int[] CSITI(string intstring){
      return [int.Parse(intstring.Split(",")[0]),int.Parse(intstring.Split(",")[1])];
    }

}
