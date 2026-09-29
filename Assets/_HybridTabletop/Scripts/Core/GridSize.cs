using System;
using UnityEngine;

namespace HybridTabletop.Core
{
    [Serializable]
    public readonly struct GridSize
    {
        [Min(1)] public readonly int Columns;
        [Min(1)] public readonly int Rows;

        public int CellCount => Columns * Rows;

        public GridSize(int columns, int rows)
        {
            Columns = Mathf.Max(1, columns);
            Rows = Mathf.Max(1, rows);
        }

        public bool Contains(GridCell cell)
        {
            return cell.Column >= 0 &&
                   cell.Column < Columns &&
                   cell.Row >= 0 &&
                   cell.Row < Rows;
        }

        public override string ToString()
        {
            return $"{Columns} x {Rows}";
        }
    }
}