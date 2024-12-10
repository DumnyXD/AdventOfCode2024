using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode;

public class Day2
{
    public static int Part1()
    {
        var reactorData = GetReactorData("Day2Input.txt");
        return GetSafeReactorsReport(reactorData);
    }

    public static int Part2()
    {
        var reactorData = GetReactorData("Day2Input.txt");
        return GetSafeReactorsReport(reactorData, true);
    }

    public static int GetSafeReactorsReport(List<List<int>> reactorData, bool tolerance = false)
    {
        int safeReactorsCount = 0;

        foreach (var reactorLevels in reactorData)
        {
            if (IsSortedOrDescending(reactorLevels) && !HasInvalidDifferences(reactorLevels))
            {
                safeReactorsCount++;
                continue;
            }
            if (tolerance && CanRemoveOneAndBeSafe(reactorLevels))
                safeReactorsCount++;
        }
        return safeReactorsCount;
    }

    private static bool IsSortedOrDescending(List<int> reactorLevels)
    {
        return reactorLevels.SequenceEqual(reactorLevels.OrderBy(n => n)) ||
               reactorLevels.SequenceEqual(reactorLevels.OrderByDescending(n => n));
    }


    private static bool HasInvalidDifferences(List<int> reactorLevels)
    {
        return reactorLevels.Zip(reactorLevels.Skip(1), (a, b) => Math.Abs(b - a)).Any(diff => diff > 3 || diff < 1);
    }

    private static bool CanRemoveOneAndBeSafe(List<int> reactorLevels)
    {
        for (int i = 0; i < reactorLevels.Count; i++)
        {
            var modifiedReactor = new List<int>(reactorLevels);
            modifiedReactor.RemoveAt(i);
            if (IsSortedOrDescending(modifiedReactor) && !HasInvalidDifferences(modifiedReactor))
            {
                return true;
            }
        }
        return false;
    }

    public static List<List<int>> GetReactorData(string file)
    {
        var reactorData = new List<List<int>>();
        var lines = File.ReadAllLines(file);
        foreach (var line in lines)
        {
            reactorData.Add(line.Split(' ').Select(int.Parse).ToList());
        }
        return reactorData;
    }
}
