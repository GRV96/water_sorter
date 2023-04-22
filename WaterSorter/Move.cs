namespace WaterSorter
{
    class Move
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
            if (obj == null)
            {
                return false;
            }

            Move other = null;
            if (obj.GetType() == typeof(Move))
            {
                other = (Move)obj;
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
}
