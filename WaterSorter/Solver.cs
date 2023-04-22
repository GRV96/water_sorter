using System.Collections.Generic;

namespace WaterSorter
{
    class Solver
    {
        private List<Stack<string>> bottles = null;
        private int bottleSize = 0;
        private List<Move> moves = null;
        private List<Move[]> solutions = null;

        private Solver(List<Stack<string>> bottles, int bottleSize)
        {
            this.bottles = CopyBottles(bottles);
            this.bottleSize = bottleSize;
            this.moves = new();
            this.solutions = new();
        }

        private bool BottleFilledWithOneColor(Stack<string> bottle, bool requireFull)
        {
            if (requireFull && bottle.Count < bottleSize)
            {
                return false;
            }

            string prevColor = null;
            foreach (string color in bottle)
            {
                if (prevColor != null && !color.Equals(prevColor))
                {
                    return false;
                }

                prevColor = color;
            }

            return true;
        }

        private static int CompareArraysByLenght<T>(T[] array1, T[] array2)
        {
            return array1.Length - array2.Length;
        }

        private static List<Stack<string>> CopyBottles(List<Stack<string>> bottles)
        {
            List<Stack<string>> copiedBottles = new();

            foreach(Stack<string> bottle in bottles)
            {
                copiedBottles.Add(new Stack<string>(new Stack<string>(bottle)));
            }

            return copiedBottles;
        }

        private List<Move> IdentifyPossibleMoves()
        {
            List<Move> possibleMoves = new List<Move>();

            int nbBottles = bottles.Count;
            for (int i = 0; i < nbBottles; i++)
            {
                Stack<string> bottleI = bottles[i];

                for (int j = i + 1; j < nbBottles; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    Stack<string> bottleJ = bottles[j];

                    if (MoveMakesSense(bottleJ, bottleI))
                    {
                        Move move = new(j, i);
                        Move prevMove = LastItemOfList(possibleMoves);
                        if (prevMove == null || !move.IsReverseOf(prevMove))
                        {
                            possibleMoves.Add(move);
                        }
                    }

                    if (MoveMakesSense(bottleI, bottleJ))
                    {
                        Move move = new(i, j);
                        Move prevMove = LastItemOfList(possibleMoves);
                        if (prevMove == null || !move.IsReverseOf(prevMove))
                        {
                            possibleMoves.Add(move);
                        }
                    }
                }
            }

            return possibleMoves;
        }

        private static T LastItemOfList<T>(List<T> someList)
        {
            int nbItems = someList.Count;
            if (nbItems == 0)
            {
                return default(T);
            }

            return someList[nbItems - 1];
        }

        private bool MoveMakesSense(Stack<string> fromBottle, Stack<string> toBottle)
        {
            if (fromBottle.Count == 0 || toBottle.Count >= bottleSize)
            {
                return false;
            }

            if (toBottle.Count == 0 && BottleFilledWithOneColor(fromBottle, false))
            {
                return false;
            }

            if (toBottle.Count == 0)
            {
                return true;
            }

            string fromColor = fromBottle.Peek();
            string toColor = toBottle.Peek();
            return fromColor.Equals(toColor);
        }

        private int PourBottle(Stack<string> fromBottle, Stack<string> toBottle)
        {
            Stack<string> movedLiquid = new Stack<string>();
            string movedColor = null;
            do
            {
                movedColor = fromBottle.Pop();
                movedLiquid.Push(movedColor);
            } while (fromBottle.Count > 0 && fromBottle.Peek() == movedColor);

            int pouredUnits = 0;
            int unitsToPour = movedLiquid.Count;
            Stack<string> reciever = null;
            if(unitsToPour + toBottle.Count <= bottleSize)
            {
                reciever = toBottle;
                pouredUnits = unitsToPour;
            }
            else
            {
                // The destination bottle does not have enough room for all the liquid.
                reciever = fromBottle;
            }

            foreach(string color in movedLiquid)
            {
                reciever.Push(color);
            }

            return pouredUnits;
        }

        private int PourBottle(Stack<string> fromBottle, Stack<string> toBottle, int nbUnits)
        {
            int pouredUnits = 0;

            if(fromBottle.Count >= nbUnits && bottleSize - toBottle.Count >= nbUnits)
            {
                for (int i = 0; i < nbUnits; i++)
                {
                    toBottle.Push(fromBottle.Pop());
                    pouredUnits++;
                }
            }

            return pouredUnits;
        }

        private bool PuzzleSolved()
        {
            foreach(Stack<string> bottle in bottles)
            {
                if (bottle.Count > 0 && !BottleFilledWithOneColor(bottle, true))
                {
                    return false;
                }
            }

            return true;
        }

        public static List<Move[]> SolvePuzzle(List<Stack<string>> bottles, int bottleSize, int nbSolutions = 0)
        {
            Solver solver = new(bottles, bottleSize);
            solver.TryMoves(nbSolutions);
            List<Move[]> solutions = solver.solutions;
            solutions.Sort(CompareArraysByLenght);
            return solutions;
        }

        private void TryMoves(int nbSolutions)
        {
            if(nbSolutions > 0 && solutions.Count >= nbSolutions)
            {
                return;
            }

            List<Move> possibleMoves = IdentifyPossibleMoves();

            if(possibleMoves.Count == 0)
            {
                bool solved = PuzzleSolved();
                if (solved)
                {
                    Move[] solution = moves.ToArray();
                    solutions.Add(solution);
                }
                return;
            }

            Move prevMove = LastItemOfList(moves);
            foreach (Move move in possibleMoves)
            {
                if (prevMove != null && move.IsReverseOf(prevMove))
                {
                    continue;
                }

                Stack<string> fromBottle = bottles[move.FromIndex];
                Stack<string> toBottle = bottles[move.ToIndex];
                int pouredUnits = PourBottle(fromBottle, toBottle);
                if (pouredUnits == 0)
                {
                    // Pouring not allowed.
                    continue;
                }

                moves.Add(move);
                TryMoves(nbSolutions);
                moves.RemoveAt(moves.Count - 1);
                PourBottle(toBottle, fromBottle, pouredUnits);
            }
        }
    }
}
