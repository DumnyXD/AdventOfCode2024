using System.IO;

namespace AdventOfCode;

public class Program
{
    static void Main(string[] args)
    {
        var file = File.ReadAllText("D:\\Codes\\dotnet\\AdventOfCode\\Day1Input.txt");
        var leftList = GetList(file);
        var rightList = GetList(file, true);
        leftList.Sort();
        rightList.Sort();
        var distance = GetSumDistance(leftList, rightList);
        var frequence = GetSumFrequence(leftList, rightList);

        Console.WriteLine(distance);
        Console.WriteLine(frequence);
    }

    public static int GetSumFrequence(List<int> leftList, List<int> rightList)
    {
        int sum = 0;
        foreach (var item in leftList)
        {
            sum += item * rightList.Count(n => n == item);
        }
        return sum;
    }

    public static int GetSumDistance(List<int> leftList, List<int> rightList)
    {
        int sum = 0;
        for (int i = 0; i<leftList.Count; i++)
        {
            sum += Math.Abs(leftList[i] - rightList[i]);
        }
        return sum;
    }

    public static List<int> GetList(string file, bool right = false)
    {
        List<int> list = new();
        var lines = file.Split("\n");
        foreach (var line in lines)
        {
            var numbers = line.Split("   ");
            if (right)
            {
                list.Add(int.Parse(numbers[1]));
            }
            else
            {
                list.Add(int.Parse(numbers[0]));
            }
        }
        return list;
    }
}

#region Formato lista day1
//82728   61150
//39850   94024
//24609   43406
//24964   98661
//16230   17299
#endregion
