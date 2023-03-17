using System;
using System.Collections.Generic;
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

            List<Stack<string>> bottles = ReadPuzzle(puzzlePath);
            Console.WriteLine();
            foreach(Stack<string> bottle in bottles)
            {
                Console.WriteLine(BottleToLine(bottle));
            }
        }

        private static string BottleToLine(Stack<string> bottle)
        {
            if (bottle.Count == 0)
            {
                return STR_DASH;
            }

            Stack<string> bottleCopy = new Stack<string>(bottle);
            List<string> colors = new List<string>();
            while(bottleCopy.Count > 0)
            {
                colors.Insert(0, bottleCopy.Pop());
            }

            string line = string.Join(STR_SPACE, colors);

            return line;
        }

        private static List<Stack<string>> ReadPuzzle(string puzzlePath)
        {
            List<Stack<string>> bottles = new List<Stack<string>>();

            using (StreamReader reader = new StreamReader(puzzlePath))
            {
                string line = null;

                while((line = reader.ReadLine()) != null)
                {
                    if(line.Length == 0 || line[0] == CH_SHARP)
                    {
                        continue;
                    }

                    Stack<string> bottle = ParsePuzzleLine(line);
                    bottles.Add(bottle);
                }
            }

            return bottles;
        }

        private static Stack<string> ParsePuzzleLine(string puzzleLine)
        {
            Stack<string> bottle = new Stack<string>();

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
