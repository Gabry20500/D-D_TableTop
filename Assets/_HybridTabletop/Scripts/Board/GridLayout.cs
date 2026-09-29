using UnityEngine;
using HybridTabletop.Core;

namespace HybridTabletop.Board
{
    public readonly struct GridLayout
    {
        public readonly GridSize VisibleGridSize;
        public readonly float CellSizeMm;
        public readonly Rect GridAreaMm;
        public readonly Rect AvailableAreaMm;

        public int Columns => VisibleGridSize.Columns;
        public int Rows => VisibleGridSize.Rows;

        public GridLayout(
            GridSize visibleGridSize,
            float cellSizeMm,
            Rect gridAreaMm,
            Rect availableAreaMm)
        {
            VisibleGridSize = visibleGridSize;
            CellSizeMm = cellSizeMm;
            GridAreaMm = gridAreaMm;
            AvailableAreaMm = availableAreaMm;
        }

        public override string ToString()
        {
            return $"{Columns} x {Rows} | {CellSizeMm:0.##} mm";
        }
    }
}