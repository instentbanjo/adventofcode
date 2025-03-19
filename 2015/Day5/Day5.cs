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
      List<string> naughtylessWords = new List<string>();
      // string word = "qjhvtzxqqjkmpbp";
      foreach (string word in _input){
          // Console.WriteLine(HasDuplicatePairsWOOverlap(word));
          // Console.WriteLine(HasRepetitionEveryOther(word));
        if (HasDuplicatePairsWOOverlap(word) && HasRepetitionEveryOther(word))
        {
          naughtylessWords.Add((string)word.Clone());
        }
      }
      Console.WriteLine(naughtylessWords.Count);
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

    static List<string> GetPairs(string word)
    {
        List<string> duplicates = new List<string>();
        for (int i = 1; i < word.Length; i++)
        {
          duplicates.Add($"{word[i-1]}{word[i]}"); 
        }
        return duplicates;
    }

    static bool HasDuplicatePairsWOOverlap(string word)
    {
        List<string> pairs = GetPairs(word); 
        foreach (string pair in pairs)
        {
            string pattern = @"(" + System.Text.RegularExpressions.Regex.Escape(pair) + @").*?\1";
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(pattern);
            if (rg.IsMatch(word))
            {
                return true;
            }
        }
        return false;
    }

    static bool HasRepetitionEveryOther(string word){
      List<string> pairs = GetPairs(word);
      for (int i = 0; i < pairs.Count; i++){
        List<int> indexesOfPair = word.AllIndexesOf(pairs[i]);
        for (int y = 0; y < indexesOfPair.Count; y++)
        {
          if (indexesOfPair[y] + 2 < word.Length && word[indexesOfPair[y]+2] == pairs[i][0])
          {
            return true;
          }
        }
      }
      return false;
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

public static class IndexOfExtension
{
  // stackoverflow.com/questions/2641326/finding-all-positions-of-substring-in-a-larger-string-in-c-sharp
  public static List<int> AllIndexesOf(this string str, string value) {
      if (String.IsNullOrEmpty(value))
          throw new ArgumentException("the string to find may not be empty", "value");
      List<int> indexes = new List<int>();
      for (int index = 0;; index += value.Length) {
          index = str.IndexOf(value, index);
          if (index == -1)
              return indexes;
          indexes.Add(index);
      }
  }

}
