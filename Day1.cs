using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode;

public class Day1
{
    public static int Part1()
    {
        var file = File.ReadAllText("Day1Input.txt");
        var leftList = GetListLeft(file).OrderBy(n=>n).ToList();
        var rightList = GetListRight(file).OrderBy(n => n).ToList();
        return GetSumDistance(leftList, rightList);
    }

    public static int Part2()
    {
        var file = File.ReadAllText("Day1Input.txt");
        var leftList = GetListLeft(file).OrderBy(n => n).ToList();
        var rightList = GetListRight(file).OrderBy(n => n).ToList();
        return GetSumFrequence(leftList, rightList);
    }

    public static int GetSumFrequence(List<int> leftList, List<int> rightList)
    {
        var rightFrequency = rightList.GroupBy(n => n)
                                      .ToDictionary(g => g.Key, g => g.Count());
        return leftList.Sum(item => item * (rightFrequency.ContainsKey(item) ? rightFrequency[item] : 0));
    }

    public static int GetSumDistance(List<int> leftList, List<int> rightList)
    {
        return leftList.Zip(rightList, (l, r) => Math.Abs(l - r)).Sum();
    }

    public static List<int> GetListLeft(string file)
    {
        return file.Split(Environment.NewLine)
                   .Select(line => int.Parse(line.Split("   ")[0]))
                   .ToList();
    }

    public static List<int> GetListRight(string file)
    {
        return file.Split(Environment.NewLine)
                   .Select(line => int.Parse(line.Split("   ")[1]))
                   .ToList();
    }
}
