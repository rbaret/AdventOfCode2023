using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        var input = Utility.ImportInput.ToStringList("input.txt");
        Dictionary<string,int> cubesSet = new Dictionary<string, int>();
        cubesSet.Add("red", 12);
        cubesSet.Add("green", 13);
        cubesSet.Add("blue", 14);
        Console.WriteLine("Part 1: " + Part1(input, cubesSet));
        Console.WriteLine("Part 2: " + Part2(input, cubesSet));
    }

    static int Part1(List<String> input, Dictionary<string,int> cubesSet)
    {
        int gameNr = 1;
        List<int> possibleGames = new List<int>();
        foreach (string line in input)
        {
            bool possible = true;
            string[] game = line.Substring(line.IndexOf(':') + 2).Split("; ");
            int i = 0;
            do
            {
                string[] subset = game[i].Split(", ");
                foreach(string cube in subset)
                {
                    int cubeNr = int.Parse(cube.Split(' ')[0]);
                    string cubeColor = cube.Split(' ')[1];
                    if (cubesSet[cubeColor] < cubeNr)
                    {
                        possible = false;
                        break;
                    }
                }
                i++;
            }while (i < game.Length && possible);
            if (possible)
            {
                possibleGames.Add(gameNr);
            }
            gameNr++;
        }
        return possibleGames.Sum();
    }

    static int Part2(List<String> input, Dictionary<string, int> cubesSet)
    {
        List<int> gamesPower = new List<int>();
        foreach (string line in input)
        {
            string[] games = line.Substring(line.IndexOf(':') + 2).Split("; ");
            int i = 0;
            int[] minCubesRGB = { 0, 0, 0 };
            foreach(string subset in games) { 
                string[] cubes = subset.Split(", ");
                foreach (string cube in cubes)
                {
                    int cubeQty = int.Parse(cube.Split(' ')[0]);
                    string cubeColor = cube.Split(' ')[1];
                    switch(cubeColor)
                    {
                        case "red":
                            if (cubeQty > minCubesRGB[0]) minCubesRGB[0] = cubeQty;
                            break;
                        case "green":
                            if (cubeQty > minCubesRGB[1]) minCubesRGB[1] = cubeQty;
                            break;
                        case "blue":
                            if (cubeQty > minCubesRGB[2]) minCubesRGB[2] = cubeQty;
                            break;
                        default:
                            break;
                    }
                }
             }
            gamesPower.Add(minCubesRGB[0] * minCubesRGB[1] * minCubesRGB[2]);
        }
        return gamesPower.Sum();
    }
}