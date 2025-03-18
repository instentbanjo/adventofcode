namespace _2015;

public class Day1
{
    private static string _input =  File.ReadAllLines("../../../Day1/input.txt")[0];
    
    static Day1()
    {
        // Part1();
        // Part2();
    }

    static void Part1() // Complicated Version
    {
        Console.WriteLine("There are " + _input.Length + " characters in the input file.");
        int floorDown = _input.Split(")").Length - 1;
        int floorUp =0;
        Console.WriteLine("He goes down " + floorDown + " floors.");
        foreach (var variable in _input.Split(")"))
        {
            for(int i=0;i<variable.Length;i++)
            {
                floorUp++;
            }
        }
        Console.WriteLine("And he goes up " + floorUp + " floors.");
        Console.WriteLine("Thats why he lands in the " + (floorUp - floorDown) + " floor.");

    }

    static void Part2()
    {
        int floor = 0;
        bool basementFound = false;
        
        Console.WriteLine(_input[0]==')');

        for (int i = 0; i < _input.Length; i++)
        {
            floor += _input[i] == ')' ? -1 : 1;
            if (floor < 0 && !basementFound)
            {
                Console.WriteLine("Santa enters the basement at position " + (i + 1));//i+1 because the position is 1-based
                basementFound = true;
            }
        }
        Console.WriteLine("Final "+nameof(floor)+": " + floor);//Check if the floor is correct
    }
}