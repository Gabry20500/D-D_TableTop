using UnityEngine;
using HybridTabletop.Board;
using HybridTabletop.Core;

namespace HybridTabletop.Rendering
{
    [ExecuteAlways]
    public class GridDebugRenderer : MonoBehaviour
    {
        [SerializeField] private BoardBootstrap boardBootstrap;
        [SerializeField] private float worldWidth = 16f;
        [SerializeField] private float worldHeight = 9f;

        private void OnDrawGizmos()
        {
            if (boardBootstrap == null ||
                !boardBootstrap.IsReady)
            {
                return;
            }

            HybridTabletop.Board.GridLayout layout = boardBootstrap.Layout;

            float cellWidth =
                worldWidth / layout.Columns;

            float cellHeight =
                worldHeight / layout.Rows;

            Gizmos.color = new Color(
                1f,
                1f,
                1f,
                0.35f);

            Vector3 origin = transform.position;

            for (int column = 0;
                 column <= layout.Columns;
                 column++)
            {
                float x = origin.x + column * cellWidth;

                Gizmos.DrawLine(
                    new Vector3(x, origin.y, origin.z),
                    new Vector3(x, origin.y, origin.z + worldHeight));
            }

            for (int row = 0;
                 row <= layout.Rows;
                 row++)
            {
                float z = origin.z + row * cellHeight;

                Gizmos.DrawLine(
                    new Vector3(origin.x, origin.y, z),
                    new Vector3(origin.x + worldWidth, origin.y, z));
            }
        }
    }
}