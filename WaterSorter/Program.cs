using System;
using System.Collections.Generic;

namespace WaterSorter
{
    static class Program
    {
        public static void Main(string[] args)
        {
            string puzzlePath = args[0];
            string solutionPath = args[1];

            Console.WriteLine($"Puzzle: {puzzlePath}");
            Console.WriteLine($"Solution: {solutionPath}");

            List<Stack<string>> bottles = FileIO.ReadPuzzle(puzzlePath);
            Console.WriteLine();
            foreach(Stack<string> bottle in bottles)
            {
                Console.WriteLine(FileIO.BottleToLine(bottle));
            }

            List<Move> moves = Solver.SolvePuzzle(bottles, 4);
            Console.WriteLine();
            foreach (Move move in moves)
            {
                Console.WriteLine(move);
            }

            FileIO.WriteSolution(solutionPath, bottles, moves);
        }
    }
}
