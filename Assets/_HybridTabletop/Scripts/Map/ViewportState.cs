using UnityEngine;
using HybridTabletop.Core;

namespace HybridTabletop.Map
{
    public class ViewportState : MonoBehaviour
    {
        [SerializeField] private Vector2Int originMapCell = Vector2Int.zero;

        public GridCell Origin =>
            new GridCell(originMapCell.x, originMapCell.y);

        public void SetOrigin(GridCell mapCell)
        {
            originMapCell = new Vector2Int(
                Mathf.Max(0, mapCell.Column),
                Mathf.Max(0, mapCell.Row));
        }

        public GridCell ViewportToMap(GridCell viewportCell)
        {
            return new GridCell(
                Origin.Column + viewportCell.Column,
                Origin.Row + viewportCell.Row);
        }

        public GridCell MapToViewport(GridCell mapCell)
        {
            return new GridCell(
                mapCell.Column - Origin.Column,
                mapCell.Row - Origin.Row);
        }
    }
}