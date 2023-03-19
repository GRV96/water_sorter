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

        public override string ToString()
        {
            return $"{FromIndex} -> {ToIndex}";
        }
    }

    static class Solver
    {
        private static bool BottleFilledWithOneColor(Stack<string> bottle, int bottleSize)
        {
            if(bottle.Count < bottleSize)
            {
                // The bottle is not filled.
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
                for (int j = 1; j < nbBottles; j++)
                {
                    Stack<string> bottleI = bottles[i];
                    Stack<string> bottleJ = bottles[j];

                    if (MoveSeemsPossible(bottleI, bottleJ, bottleSize))
                    {
                        possibleMoves.Add(new Move(i, j));
                    }

                    if (MoveSeemsPossible(bottleJ, bottleI, bottleSize))
                    {
                        possibleMoves.Add(new Move(j, i));
                    }
                }
            }

            return possibleMoves;
        }

        private static bool MoveSeemsPossible(Stack<string> fromBottle, Stack<string> toBottle, int bottleSize)
        {
            if(fromBottle.Count == 0 || toBottle.Count >= bottleSize
                || BottleFilledWithOneColor(fromBottle, bottleSize))
            {
                return false;
            }

            if(toBottle.Count == 0)
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
                // The destination bottle does not have enough place for all the liquid.
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
