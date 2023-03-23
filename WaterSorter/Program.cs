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
            foreach (Stack<string> bottle in bottles)
            {
                Console.WriteLine(FileIO.BottleToLine(bottle));
            }

            int nbSolutions = 0;
            if(nbArgs < 2)
            {
               int.TryParse(args[1], out nbSolutions);
            }

            List<Move[]> solutions = Solver.SolvePuzzle(bottles, 4, nbSolutions);

            if (nbArgs < 3)
            {
                foreach (Move[] solution in solutions)
                {
                    Console.WriteLine($"\n{solution.Length} moves");

                    foreach (Move move in solution)
                    {
                        Console.WriteLine(move);
                    }
                }
            }
            else
            {
                string solutionPath = args[2];
                FileIO.WriteSolutions(solutionPath, bottles, solutions);
            }

            Console.WriteLine();
        }
    }
}
