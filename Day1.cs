using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode;

public class Day1
{
    public static int Part1()
    {
        var file = File.ReadAllText("Day1Input.txt");
        var leftList = GetList(file);
        var rightList = GetList(file, true);
        leftList.Sort();
        rightList.Sort();
        return GetSumDistance(leftList, rightList);
    }

    public static int Part2()
    {
        var file = File.ReadAllText("Day1Input.txt");
        var leftList = GetList(file);
        var rightList = GetList(file, true);
        leftList.Sort();
        rightList.Sort();
        return GetSumFrequence(leftList, rightList);
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
        for (int i = 0; i < leftList.Count; i++)
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
