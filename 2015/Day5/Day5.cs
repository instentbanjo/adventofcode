namespace _2015;

public class Day5
{
    
    private static string[] _input =  File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../Day5/input.txt"));

    static Day5()
    {
      Console.WriteLine("---5---");
      Part1();
      Part2();
    }

    static void Part1(){
      List<string> naughtylessWords = new List<string>();
      foreach (string word in _input)
      {
        if (GetNumberOfVowels(word) >= 3)
        {
          if (ContainsDuplicates(word))
          {
            if (!DoesContainCertainPairs(new string[] { "ab", "cd", "pq", "xy"} ,word))
            {
              naughtylessWords.Add((string)word.Clone());
            }
          }
        }
      }
      Console.WriteLine(naughtylessWords.Count);
    }

    static void Part2(){
      Console.WriteLine(GetDuplicates("hallo")[0]);
    }

    static int GetNumberOfVowels(string word){
      HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
      return word.Count(c => vowels.Contains(c));
    }

    static bool ContainsDuplicates(string word){
      bool containsDuplicates = false;
      for (int i = 1; i < word.Length; i++){
        if (word[i]==word[i-1])
        {
          containsDuplicates = true;
        }
      }
      return containsDuplicates;
    }

    static List<string> GetDuplicates(string word)
    {
        List<string> duplicates = new List<string>();
        for (int i = 1; i < word.Length; i++)
        {
            if (word[i] == word[i - 1])
            {
                duplicates.Add($"{word[i]}{word[i - 1]}"); 
            }
        }
        return duplicates;
    }

    static bool DoesContainCertainPairs(string[] pairs, string word)
    {
        foreach (string pair in pairs)
        {
            if (word.Contains(pair)) return true;
        }
        return false; 
    }

}
