using System.Globalization;
using System.Text.RegularExpressions;
using Utility;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Day 1");
        var input = Utility.ImportInput.ToStringList("input.txt");
        Console.WriteLine("Part 1: " + Part1(input));
        Console.WriteLine("Part 2: " + Part2(input));
        
        
        // Part 1
        int Part1(List<String> input)
        {
            int calibration = 0;
            foreach (string line in input)
            {
                // Parse each line and extract digits from the string
                char[] digits = line.Where(Char.IsDigit).ToArray();
                calibration += int.Parse(digits.First().ToString() + digits.Last().ToString());
            }
            return calibration;
        }

        // Part 2
        int Part2(List<String> input)
        {
            // Create a map of the digits and their spelling
            Dictionary<char, string> map = new Dictionary<char, string>();
            map.Add('1', "one");
            map.Add('2', "two");
            map.Add('3', "three");
            map.Add('4', "four");
            map.Add('5', "five");
            map.Add('6', "six");
            map.Add('7', "seven");
            map.Add('8', "eight");
            map.Add('9', "nine");
            int calibration = 0;

            // replace each spelling with the corresponding digit in each line
            // spellings can overlap and the end of a spelling can be the beginning of another
            // we need to keep the order of the digits
            for (int i = 0; i < input.Count; i++)
            {
                // TBD
            }
            return calibration;
        }
    }
}
