using System.Collections.Generic;

namespace WaterSorter
{
    public class Move
    {
        public int FromIndex { get; init; }
        public int ToIndex { get; init; }

        public Move(int fromIndex, int toIndex)
        {
            FromIndex = fromIndex;
            ToIndex = toIndex;
        }

        public override bool Equals(object obj)
        {
            Move other = null;
            if(obj.GetType() == typeof(Move))
            {
                other = (Move) obj;
            }
            else
            {
                return false;
            }

            return this.FromIndex == other.FromIndex && this.ToIndex == other.ToIndex;
        }

        public bool IsReverseOf(Move other)
        {
            return this.FromIndex == other.ToIndex && this.ToIndex == other.FromIndex;
        }

        public override string ToString()
        {
            return $"{FromIndex} -> {ToIndex}";
        }
    }

    class Solver
    {
        private List<Stack<string>> bottles = null;
        private int bottleSize = 0;
        private List<Move> moves = null;

        private Solver(List<Stack<string>> bottles, int bottleSize)
        {
            this.bottles = CopyBottles(bottles);
            this.bottleSize = bottleSize;
            this.moves = new();
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

                    if (MoveMakesSense(bottleI, bottleJ))
                    {
                        Move move = new Move(i, j);
                        Move prevMove = LastItemOfList(possibleMoves);
                        if (prevMove == null || !move.IsReverseOf(prevMove))
                        {
                            possibleMoves.Add(move);
                        }
                    }

                    if (MoveMakesSense(bottleJ, bottleI))
                    {
                        Move move = new Move(j, i);
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

        public static List<Move> SolvePuzzle(List<Stack<string>> bottles, int bottleSize)
        {
            Solver solver = new(bottles, bottleSize);
            solver.TryMoves();
            return solver.moves;
        }

        private bool TryMoves()
        {
            List<Move> possibleMoves = IdentifyPossibleMoves();

            if(possibleMoves.Count == 0)
            {
                return PuzzleSolved();
            }

            bool solved = false;
            foreach (Move move in possibleMoves)
            {
                Move prevMove = LastItemOfList(moves);
                if (prevMove != null && move.IsReverseOf(prevMove))
                {
                    continue;
                }

                Stack<string> fromBottle = bottles[move.FromIndex];
                Stack<string> toBottle = bottles[move.ToIndex];
                int pouredUnits = PourBottle(fromBottle, toBottle);
                if (pouredUnits == 0)
                {
                    continue;
                }

                moves.Add(move);
                solved = TryMoves();

                if (solved)
                {
                    break;
                }
                else
                {
                    moves.RemoveAt(moves.Count - 1);
                    PourBottle(toBottle, fromBottle, pouredUnits);
                }
            }

            return solved;
        }
    }
}
