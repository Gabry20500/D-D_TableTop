using UnityEngine;
using HybridTabletop.Core;

namespace HybridTabletop.Board
{
    public sealed class BoardCoordinateMapper
    {
        private readonly BoardProfile profile;
        private readonly GridLayout layout;

        public BoardCoordinateMapper(
            BoardProfile profile,
            GridLayout layout)
        {
            this.profile = profile;
            this.layout = layout;
        }

        public Vector2 ScreenToBoardMm(Vector2 screenPosition)
        {
            float boardX = screenPosition.x / Screen.width *
                           profile.usableWidthMm;

            float boardY = screenPosition.y / Screen.height *
                           profile.usableHeightMm;

            return new Vector2(boardX, boardY);
        }

        public Vector2 BoardMmToScreen(Vector2 boardPositionMm)
        {
            float screenX = boardPositionMm.x /
                            profile.usableWidthMm *
                            Screen.width;

            float screenY = boardPositionMm.y /
                            profile.usableHeightMm *
                            Screen.height;

            return new Vector2(screenX, screenY);
        }

        public bool TryBoardMmToViewportCell(
            Vector2 boardPositionMm,
            out GridCell cell)
        {
            cell = GridCell.Zero;

            if (!layout.GridAreaMm.Contains(boardPositionMm))
            {
                return false;
            }

            int column = Mathf.FloorToInt(
                (boardPositionMm.x - layout.GridAreaMm.x) /
                layout.CellSizeMm);

            int row = Mathf.FloorToInt(
                (boardPositionMm.y - layout.GridAreaMm.y) /
                layout.CellSizeMm);

            GridCell candidate = new GridCell(column, row);

            if (!layout.VisibleGridSize.Contains(candidate))
            {
                return false;
            }

            cell = candidate;
            return true;
        }

        public bool TryScreenToViewportCell(
            Vector2 screenPosition,
            out GridCell cell)
        {
            Vector2 boardMm = ScreenToBoardMm(screenPosition);

            return TryBoardMmToViewportCell(boardMm, out cell);
        }

        public Vector2 ViewportCellToBoardMmCenter(GridCell cell)
        {
            return new Vector2(
                layout.GridAreaMm.x +
                (cell.Column + 0.5f) * layout.CellSizeMm,

                layout.GridAreaMm.y +
                (cell.Row + 0.5f) * layout.CellSizeMm);
        }

        public Vector2 ViewportCellToScreenCenter(GridCell cell)
        {
            Vector2 boardMm = ViewportCellToBoardMmCenter(cell);

            return BoardMmToScreen(boardMm);
        }
    }
}