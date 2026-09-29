using System;

namespace HybridTabletop.Core
{
    [Serializable]
    public readonly struct GridRect
    {
        public readonly GridCell Origin;
        public readonly GridSize Size;

        public int MinColumn => Origin.Column;
        public int MinRow => Origin.Row;
        public int MaxColumnExclusive => Origin.Column + Size.Columns;
        public int MaxRowExclusive => Origin.Row + Size.Rows;

        public GridRect(GridCell origin, GridSize size)
        {
            Origin = origin;
            Size = size;
        }

        public bool Contains(GridCell cell)
        {
            return cell.Column >= MinColumn &&
                   cell.Column < MaxColumnExclusive &&
                   cell.Row >= MinRow &&
                   cell.Row < MaxRowExclusive;
        }
    }
}