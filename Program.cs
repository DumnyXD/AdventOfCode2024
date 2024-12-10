using System.IO;

namespace AdventOfCode;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine(Day2.Part1());
            Console.WriteLine(Day2.Part2());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + "\n\n" + ex.StackTrace + "\n\n\n");
        }
    }
}