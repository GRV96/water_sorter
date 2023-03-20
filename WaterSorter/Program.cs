using System;
using System.Collections.Generic;

namespace WaterSorter
{
    static class Program
    {
        public static void Main(string[] args)
        {
            int nbArgs = args.Length;
            if (nbArgs < 1)
            {
                Console.WriteLine("Missing argument 1: the path to the puzzle.\n");
                return;
            }

            string puzzlePath = args[0];

            List<Stack<string>> bottles = FileIO.ReadPuzzle(puzzlePath);
            Console.WriteLine();
            foreach (Stack<string> bottle in bottles)
            {
                Console.WriteLine(FileIO.BottleToLine(bottle));
            }
            Console.WriteLine();

            List<Move> moves = Solver.SolvePuzzle(bottles, 4);

            if (nbArgs < 2)
            {
                foreach (Move move in moves)
                {
                    Console.WriteLine(move);
                }
                Console.WriteLine();
            }
            else
            {
                string solutionPath = args[1];
                FileIO.WriteSolution(solutionPath, bottles, moves);
            }
        }
    }
}
