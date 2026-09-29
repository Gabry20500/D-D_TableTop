using UnityEngine;
using HybridTabletop.Board;

namespace HybridTabletop.Debugging
{
    public class BoardDebugPanel : MonoBehaviour
    {
        [SerializeField] private BoardBootstrap boardBootstrap;

        private void OnGUI()
        {
            if (boardBootstrap == null)
            {
                return;
            }

            GUILayout.BeginArea(
                new Rect(20f, 20f, 360f, 220f),
                GUI.skin.box);

            GUILayout.Label("<b>Hybrid Tabletop - Board Debug</b>");

            if (!boardBootstrap.IsReady)
            {
                GUILayout.Label("Stato: board non pronta.");
                GUILayout.EndArea();
                return;
            }

            GridLayout layout = boardBootstrap.Layout;

            GUILayout.Label($"Display: {Screen.width} x {Screen.height}px");
            GUILayout.Label(
                $"Celle visibili: {layout.Columns} x {layout.Rows}");
            GUILayout.Label(
                $"Cella fisica: {layout.CellSizeMm:0.##} mm");
            GUILayout.Label(
                $"Area griglia: " +
                $"{layout.GridAreaMm.width:0.#} x " +
                $"{layout.GridAreaMm.height:0.#} mm");

            GUILayout.EndArea();
        }
    }
}