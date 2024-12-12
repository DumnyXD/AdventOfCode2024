using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode;

public class Day3
{
    public static string Exemple = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
    public static int Part1()
    {
        string input = File.ReadAllText("Day3input.txt");
        MatchCollection matches = GetMatchesMul(input);
        return GetSumMul(matches);
    }

    public static int Part2()
    {
        string input = File.ReadAllText("Day3input.txt");
        IEnumerable<string> matches = FilterEnabledMul(input);
        return GetSumMul(matches);
    }

    public static int GetSumMul(IEnumerable<string> matches)
    {
        return matches.Sum(item =>
        {
            (int num1, int num2) = ExtractMulNumbers(item);
            return num1 * num2;
        });
    }

    public static int GetSumMul(MatchCollection matches)
    {
        return matches.Cast<Match>().Sum(match =>
        {
            (int num1, int num2) = ExtractMulNumbers(match.Value);
            return num1 * num2;
        });
    }

    public static (int num1, int num2) ExtractMulNumbers(string mulExpression)
    {
        Match match = Regex.Match(mulExpression, @"mul\((\d{1,3}),(\d{1,3})\)");
        return match.Success ? (int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value)) : (0, 0);
    }

    public static MatchCollection GetMatchesMul(string input)
    {
        return Regex.Matches(input, @"mul\(\d{1,3},\d{1,3}\)");
    }

    public static IEnumerable<string> FilterEnabledMul(string input)
    {
        bool enable = true;
        return Regex.Matches(input, @"mul\(\d{1,3},\d{1,3}\)|don't\(\)|do\(\)")
                    .Cast<Match>()
                    .Where(match => ProcessMulCommand(ref enable, match.Value))
                    .Select(match => match.Value);
    }

    private static bool ProcessMulCommand(ref bool enable, string command)
    {
        if (command == "don't()")
        {
            enable = false;
            return false;
        }
        if (command == "do()")
        {
            enable = true;
            return false;
        }
        return enable;
    }
}
