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
                Console.WriteLine("Missing argument 0: the path to the puzzle.\n");
                return;
            }

            string puzzlePath = args[0];

            List<Stack<string>> bottles = FileIO.ReadPuzzle(puzzlePath);
            Console.WriteLine();
            FileIO.WriteBottles(bottles, Console.WriteLine);

            int nbSolutions = 0;
            if(nbArgs >= 2)
            {
               int.TryParse(args[1], out nbSolutions);
            }

            List<Move[]> solutions = Solver.SolvePuzzle(bottles, 4, nbSolutions);

            if (nbArgs < 3)
            {
                FileIO.WriteSolutions(solutions, Console.WriteLine);
            }
            else
            {
                string solutionPath = args[2];
                FileIO.WritePuzzleAndSolutions(solutionPath, bottles, solutions);
            }

            Console.WriteLine();
        }
    }
}
