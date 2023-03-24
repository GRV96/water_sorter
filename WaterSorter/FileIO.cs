using System.Collections.Generic;
using System.IO;

namespace WaterSorter
{
    delegate void ProcessObjNoReturn(object value);

    static class FileIO
    {
        private const char CH_SHARP = '#';
        private const string STR_DASH = "-";
        private const string STR_SPACE = " ";

        public static string BottleToLine(Stack<string> bottle)
        {
            if (bottle.Count == 0)
            {
                return STR_DASH;
            }

            string[] colors = bottle.ToArray();
            string line = string.Join(STR_SPACE, colors);
            return line;
        }

        private static Stack<string> ParsePuzzleLine(string puzzleLine)
        {
            Stack<string> bottle = new Stack<string>();

            if (puzzleLine != STR_DASH)
            {
                string[] colors = puzzleLine.Split(STR_SPACE);

                for (int i = colors.Length - 1; i >= 0; i--)
                {
                    bottle.Push(colors[i]);
                }
            }

            return bottle;
        }

        public static List<Stack<string>> ReadPuzzle(string puzzlePath)
        {
            List<Stack<string>> bottles = new List<Stack<string>>();

            using (StreamReader reader = new StreamReader(puzzlePath))
            {
                string line = null;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length == 0 || line[0] == CH_SHARP)
                    {
                        continue;
                    }

                    Stack<string> bottle = ParsePuzzleLine(line);
                    bottles.Add(bottle);
                }
            }

            return bottles;
        }

        public static void WriteBottles(List<Stack<string>> bottles, ProcessObjNoReturn writerFnc)
        {
            foreach (Stack<string> bottle in bottles)
            {
                writerFnc(BottleToLine(bottle));
            }
        }

        public static void WritePuzzleAndSolutions(
            string solutionPath, List<Stack<string>> bottles, List<Move[]> solutions)
        {
            using (StreamWriter writer = new StreamWriter(solutionPath))
            {
                WriteBottles(bottles, writer.WriteLine);
                WriteSolutions(solutions, writer.WriteLine);
            }
        }

        public static void WriteSolutions(List<Move[]> solutions, ProcessObjNoReturn writerFnc)
        {
            int solutionIndex = 0;
            foreach (Move[] solution in solutions)
            {
                writerFnc($"\n[{solutionIndex}] {solution.Length} moves");

                foreach (Move move in solution)
                {
                    writerFnc(move);
                }

                solutionIndex++;
            }
        }
    }
}
