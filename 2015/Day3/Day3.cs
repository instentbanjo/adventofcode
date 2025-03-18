namespace _2015;

public class Day3
{
    
    private static string _input =  File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../Day3/input.txt"))[0];

    static Day3()
    {
      Part1();
      Part2();
    }

    static void Part1(){
      int[] coordinates =[0, 0];
      List<int[]> visitedCoordinates = new List<int[]>();
      //visitedCoordinates.Add(coordinates);
      //Not good -> .Contains checks if the same <object> is in the list, not if the values align
      visitedCoordinates.Add((int[])coordinates.Clone());
      Console.WriteLine("Length of input: " + _input.Length);
      for (int i = 0; i < _input.Length; i++)
      {
        switch (_input[i])
        {
            case '^':
                    coordinates[1]++;
                  break;
            case 'v':
                    coordinates[1]--;
                  break;
            case '<':
                    coordinates[0]++;
                  break;
            case '>':
                    coordinates[0]--;
                  break;
        }
        //if (!visitedCoordinates.Contains(coordinates))
        //Not good -> .Contains checks if the same <object> is in the list, not if the values align
        if (!visitedCoordinates.Any(c => c[0] == coordinates[0] && c[1]==coordinates[1]))
        {
          visitedCoordinates.Add((int[])coordinates.Clone());
        }
      }
      Console.WriteLine(visitedCoordinates.Count);
    }

    static void Part2(){
      int[] coordinatesSanta = [0,0], coordinatesRobo =[0, 0];
      List<int[]> visitedCoordinates = new List<int[]>();
      visitedCoordinates.Add((int[])coordinatesSanta.Clone());//only need to add 1
      Console.WriteLine("Length of input: " + _input.Length);
      for (int i = 0; i < _input.Length; i++)
      {
        int[] mover = i%2==0?coordinatesRobo:coordinatesSanta;
        switch (_input[i])
        {
            case '^':mover[1]++;break;
            case 'v':mover[1]--;break;
            case '<':mover[0]++;break;
            case '>':mover[0]--;break;
        }
        if (!visitedCoordinates.Any(c => c[0] == mover[0] && c[1]== mover[1]))
        {
          visitedCoordinates.Add((int[])mover.Clone());
        }
      }
      Console.WriteLine(visitedCoordinates.Count);
    }

}
