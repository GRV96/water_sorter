using System.Collections.Generic;
using System.IO;

namespace WaterSorter
{
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

            Stack<string> bottleCopy = new Stack<string>(bottle);
            List<string> colors = new List<string>();
            while (bottleCopy.Count > 0)
            {
                colors.Insert(0, bottleCopy.Pop());
            }

            string line = string.Join(STR_SPACE, colors);

            return line;
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
    }
}
