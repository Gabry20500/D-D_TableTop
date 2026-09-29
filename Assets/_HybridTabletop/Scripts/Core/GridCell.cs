using System;

namespace HybridTabletop.Core
{
    [Serializable]
    public readonly struct GridCell : IEquatable<GridCell>
    {
        public readonly int Column;
        public readonly int Row;

        public GridCell(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public static readonly GridCell Zero = new(0, 0);

        public GridCell Offset(int columnOffset, int rowOffset)
        {
            return new GridCell(
                Column + columnOffset,
                Row + rowOffset);
        }

        public bool Equals(GridCell other)
        {
            return Column == other.Column &&
                   Row == other.Row;
        }

        public override bool Equals(object obj)
        {
            return obj is GridCell other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Column, Row);
        }

        public override string ToString()
        {
            return $"({Column}, {Row})";
        }

        public static bool operator ==(GridCell left, GridCell right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(GridCell left, GridCell right)
        {
            return !left.Equals(right);
        }
    }
}