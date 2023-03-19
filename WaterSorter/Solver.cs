using System;
using System.Collections.Generic;
using System.Text;

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

    static class Solver
    {
        private static bool BottleFilledWithOneColor(Stack<string> bottle, int bottleSize=0)
        {
            if (bottleSize > 0 && bottle.Count < bottleSize)
            {
                // Return false if the bottle is not filled.
                // To ignore this criteria, set bottleSize to 0 or less.
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

        private static List<Move> IdentifyPossibleMoves(List<Stack<string>> bottles, int bottleSize)
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

                    if (MoveMakesSense(bottleI, bottleJ, bottleSize))
                    {
                        Move move = new Move(i, j);
                        Move prevMove = LastItemOfList(possibleMoves);
                        if (prevMove == null || !move.IsReverseOf(prevMove))
                        {
                            possibleMoves.Add(move);
                        }
                    }

                    if (MoveMakesSense(bottleJ, bottleI, bottleSize))
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

        private static bool MoveMakesSense(Stack<string> fromBottle, Stack<string> toBottle, int bottleSize)
        {
            if (fromBottle.Count == 0 || toBottle.Count >= bottleSize)
            {
                return false;
            }

            if (toBottle.Count == 0 && BottleFilledWithOneColor(fromBottle))
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

        private static bool PourBottle(Stack<string> fromBottle, Stack<string> toBottle, int bottleSize)
        {
            Stack<string> movedLiquid = new Stack<string>();
            string movedColor = null;
            do
            {
                movedColor = fromBottle.Pop();
                movedLiquid.Push(movedColor);
            } while (fromBottle.Count > 0 && fromBottle.Peek() == movedColor);

            bool poured = false;
            Stack<string> reciever = null;
            if(movedLiquid.Count + toBottle.Count <= bottleSize)
            {
                reciever = toBottle;
                poured = true;
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

            return poured;
        }

        private static bool PuzzleSolved(List<Stack<string>> bottles, int bottleSize)
        {
            foreach(Stack<string> bottle in bottles)
            {
                if (bottle.Count > 0 && !BottleFilledWithOneColor(bottle, bottleSize))
                {
                    return false;
                }
            }

            return true;
        }

        public static List<Move> SolvePuzzle(List<Stack<string>> bottles, int bottleSize)
        {
            bottles = new List<Stack<string>>(bottles);
            List<Move> moves = new List<Move>();
            TryMoves(bottles, moves, bottleSize);
            return moves;
        }

        private static bool TryMoves(List<Stack<string>> bottles, List<Move> moves, int bottleSize)
        {
            List<Move> possibleMoves = IdentifyPossibleMoves(bottles, bottleSize);

            if(possibleMoves.Count == 0)
            {
                return PuzzleSolved(bottles, bottleSize);
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
                bool poured = PourBottle(fromBottle, toBottle, bottleSize);
                if (!poured)
                {
                    continue;
                }

                moves.Add(move);
                solved = TryMoves(bottles, moves, bottleSize);

                if (solved)
                {
                    break;
                }
                else
                {
                    moves.RemoveAt(moves.Count - 1);
                }
            }

            return solved;
        }
    }
}
