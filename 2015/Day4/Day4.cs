namespace _2015;

public class Day4
{
    
    private static string _input =  "iwrupvqb";

    static Day4()
    {
      Console.WriteLine("---4---");
      Part1();
      // Part2();
    }

    static void Part1(){
      FindHexStartingWith("00000");
    }

    static void Part2(){
      FindHexStartingWith("000000");
    }

    static void FindHexStartingWith(string start){
      int i = 0;
      bool hasFound = false;
      while (!hasFound)
      {
        i++;
        string hex = CreateMD5(_input+i.ToString());
        if (hex.StartsWith(start))
        {
          Console.WriteLine(hex + "created with num: "+ i);
          hasFound = true;
        }
      }
    }

    public static string CreateMD5(string input)
    {
      // Use input string to calculate MD5 hash
      // https://stackoverflow.com/questions/11454004/calculate-a-md5-hash-from-a-string
      using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
      {
          byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
          byte[] hashBytes = md5.ComputeHash(inputBytes);
          return Convert.ToHexString(hashBytes); 
      }
    }

}
