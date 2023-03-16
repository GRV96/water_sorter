using System;
using System.Collections;
using System.IO;

namespace water_sorter
{
    class Program
    {
        const char CH_SHARP = '#';
        const string STR_DASH = "-";
        const string STR_SPACE = " ";

        static void Main(string[] args)
        {
            string puzzlePath = args[0];
            string solutionPath = args[1];

            Console.WriteLine("Puzzle: {0}", puzzlePath);
            Console.WriteLine("Solution: {0}", solutionPath);

            // Error: paths are not relative to the solution.
            ArrayList bottles = ReadPuzzle(puzzlePath);
            Console.WriteLine();
            foreach(Stack bottle in bottles)
            {
                Console.WriteLine(BottleToLine(bottle));
            }
        }

        private static string BottleToLine(Stack bottle)
        {
            if (bottle.Count == 0)
            {
                return STR_DASH;
            }

            Stack bottleCopy = new Stack(bottle);
            ArrayList colors = new ArrayList();
            while(bottleCopy.Count > 0)
            {
                colors.Insert(0, bottleCopy.Pop());
            }

            string line = "";
            foreach (string color in colors)
            {
                line += color + STR_SPACE;
            }

            return line;
        }

        private static ArrayList ReadPuzzle(string puzzlePath)
        {
            ArrayList bottles = new ArrayList();

            using (StreamReader reader = new StreamReader(puzzlePath))
            {
                string line = null;

                while((line = reader.ReadLine()) != null)
                {
                    if(line.Length == 0 || line[0] == CH_SHARP)
                    {
                        continue;
                    }

                    Stack bottle = ParsePuzzleLine(line);
                    bottles.Add(bottle);
                }
            }

            return bottles;
        }

        private static Stack ParsePuzzleLine(string puzzleLine)
        {
            Stack bottle = new Stack();

            if(puzzleLine != STR_DASH)
            {
                string[] colors = puzzleLine.Split(STR_SPACE);

                for (int i = colors.Length - 1; i >= 0; i--)
                {
                    bottle.Push(colors[i]);
                }
            }

            return bottle;
        }
    }
}
