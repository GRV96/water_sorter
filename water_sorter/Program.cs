using System;
using System.Collections.Generic;

namespace water_sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            string puzzlePath = args[0];
            string solutionPath = args[1];

            Console.WriteLine("Puzzle: {0}", puzzlePath);
            Console.WriteLine("Solution: {0}", solutionPath);

            List<Stack<string>> bottles = FileIO.ReadPuzzle(puzzlePath);
            Console.WriteLine();
            foreach(Stack<string> bottle in bottles)
            {
                Console.WriteLine(FileIO.BottleToLine(bottle));
            }
        }
    }
}
