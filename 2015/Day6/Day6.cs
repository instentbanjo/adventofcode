namespace _2015;

public class Day6
{
    
    private static string[] _input =  File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../Day6/input.txt"));
    private static bool[,] _lightsOnGrid = new bool[1000,1000];
    private static int[,] _brightnessGrid = new int[1000,1000];

    static Day6()
    {
      Console.WriteLine("---6---");
      // Part1();
      Part2();
    }

    static void Part1(){
      foreach (string input in _input)
      {
        ProcessLine(input, _lightsOnGrid[0,0].GetType());
      }
      Console.WriteLine(CTVIM(_lightsOnGrid[0,0].GetType()));
    }

    static void Part2(){
      foreach (string input in _input)
      {
        ProcessLine(input, _brightnessGrid[0,0].GetType());
      }
      Console.WriteLine(CTVIM(_brightnessGrid[0,0].GetType()));
    }

    static void ProcessLine(string line, Type gridType){
      string[] arr = line.Split(" ");
      if (arr[0]=="turn")
      {
        Turn(arr[1]=="on", CSITI(arr[2]), CSITI(arr[4]), gridType);
      }else
      {
        Toggle(CSITI(arr[1]), CSITI(arr[3]), gridType);
      }

    }
    
    static void Turn(bool value, int[] rangeStart,int[] rangeEnd, Type valueType){
      for (int i = rangeStart[0]; i <= rangeEnd[0]; i++)
      {
        for (int y = rangeStart[1]; y <= rangeEnd[1]; y++)
        {
          if (valueType==typeof(bool))
          {
            _lightsOnGrid[i,y]= value;
          }else
          {
             _brightnessGrid[i,y]+= value?1:_brightnessGrid[i,y]==0?0:-1;
          }
        }
      }
    }

    static void Toggle(int[] rangeStart,int[] rangeEnd, Type valueType){
      for (int i = rangeStart[0]; i <= rangeEnd[0]; i++)
      {
        for (int y = rangeStart[1]; y <= rangeEnd[1]; y++)
        {
          if (valueType==typeof(bool))
          {
            _lightsOnGrid[i,y] = !_lightsOnGrid[i,y];
          }else
          {
            _brightnessGrid[i,y]+=2;
          }
        }
      }

    }

    //CountTrueValuesInMatrix
    static int CTVIM(Type valueType){
      int count = 0;
      for (int i = 0; i < _lightsOnGrid.GetLength(0); i++)
      {
        for (int y = 0; y < _lightsOnGrid.GetLength(1); y++)
        {
          if (valueType==typeof(bool))
          {
            if (_lightsOnGrid[i,y]) count++;
          }else
          {
            count += _brightnessGrid[i, y];
          }
        }
      }
      return count;
    }

    //CommaSeperatedIntstringToIntarray
    static int[] CSITI(string intstring){
      return [int.Parse(intstring.Split(",")[0]),int.Parse(intstring.Split(",")[1])];
    }

}
