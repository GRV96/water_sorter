using System;

namespace water_sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            String puzzlePath = args[0];
            String solutionPath = args[1];

            Console.WriteLine("Puzzle: {0}", puzzlePath);
            Console.WriteLine("Solution: {0}", solutionPath);
        }
    }
}
