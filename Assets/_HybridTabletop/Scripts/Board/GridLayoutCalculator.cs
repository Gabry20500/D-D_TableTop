using UnityEngine;
using HybridTabletop.Core;

namespace HybridTabletop.Board
{
    public static class GridLayoutCalculator
    {
        public static bool TryCalculate(
            BoardProfile profile,
            out GridLayout layout)
        {
            layout = default;

            if (profile == null || !profile.IsCalibrated)
            {
                return false;
            }

            Rect availableArea = profile.GetAvailableAreaMm();

            float cellSize = Mathf.Clamp(
                profile.preferredCellSizeMm,
                profile.minimumCellSizeMm,
                profile.maximumCellSizeMm);

            int columns = Mathf.FloorToInt(
                availableArea.width / cellSize);

            int rows = Mathf.FloorToInt(
                availableArea.height / cellSize);

            if (columns < 1 || rows < 1)
            {
                return false;
            }

            float gridWidth = columns * cellSize;
            float gridHeight = rows * cellSize;

            float gridX = availableArea.x +
                          (availableArea.width - gridWidth) * 0.5f;

            float gridY = availableArea.y +
                          (availableArea.height - gridHeight) * 0.5f;

            layout = new GridLayout(
                new GridSize(columns, rows),
                cellSize,
                new Rect(gridX, gridY, gridWidth, gridHeight),
                availableArea);

            return true;
        }
    }
}