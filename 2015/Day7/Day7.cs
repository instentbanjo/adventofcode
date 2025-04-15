namespace _2015;

public class Day7
{
    private static string[] _input =  File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../Day7/input.txt"));
    private static Dictionary<string,int> wires = new Dictionary<string,int>();

    static Day7()
    {
      Console.WriteLine("---7---");
      Part1();
    }

    static void Part1(){
      // foreach (string line in _input)
      // {
      //   ProcessLine(line)
      // }

      // string line = "NOT lk -> ll";
      string line = "af AND ah -> ai";
      // string line = "du OR dt -> dv";
      // string line = "hz RSHIFT 3 -> is";
      // string line = "eo LSHIFT 15 -> es";

      ProcessLine(line);
    }

    private static void ProcessLine(string line){
      string[] arr = line.Split(" ");
      string operation = null;
      int shiftvalue = new int();
      if (arr[0]=="NOT")operation=arr[0];
      else
      {
        //if value already exists for key, keep it, else initialize key-value pair with new int (value 0)
        wires.TryAdd(arr[0], new int());
      }
      if (operation != null)
      {
        wires.TryAdd(arr[1], new int());
      }else
      {
          operation = arr[1];
      }
      if (operation == "AND"||operation == "OR")
      {
        wires.TryAdd(arr[2], new int());
        // wires.TryAdd(arr.LastIndexOf(), operation=="AND"?wires[arr[0]&wires[arr[2]]:wires[arr[0]|wires[arr[2]]]);
      }else if (operation != "NOT")
      {
        shiftvalue = operation=="LSHIFT"?int.Parse(arr[2])*-1:int.Parse(arr[2])*1;
        Console.WriteLine(shiftvalue);
      }
      Console.WriteLine(operation);
      foreach (var kvp in wires)
      {
          Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
      }
    }

}

