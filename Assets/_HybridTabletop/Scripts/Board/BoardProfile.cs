using UnityEngine;

namespace HybridTabletop.Board
{
    [CreateAssetMenu(
        fileName = "BoardProfile",
        menuName = "Hybrid Tabletop/Board Profile")]
    public class BoardProfile : ScriptableObject
    {
        [Header("Physical board area")]
        [Tooltip("0 = tavolo non calibrato.")]
        [Min(0f)] public float usableWidthMm;

        [Tooltip("0 = tavolo non calibrato.")]
        [Min(0f)] public float usableHeightMm;

        [Header("Playable safe margins")]
        [Min(0f)] public float marginLeftMm = 20f;
        [Min(0f)] public float marginRightMm = 20f;
        [Min(0f)] public float marginTopMm = 20f;
        [Min(0f)] public float marginBottomMm = 20f;

        [Header("Cell size")]
        [Tooltip("Preset D&D classico: 25.4 mm.")]
        [Min(1f)] public float preferredCellSizeMm = 25.4f;

        [Min(1f)] public float minimumCellSizeMm = 22f;
        [Min(1f)] public float maximumCellSizeMm = 32f;

        [Header("Optional UI reservation")]
        public bool reserveHudArea;
        [Min(0f)] public float hudWidthMm;

        public bool IsCalibrated =>
            usableWidthMm > 0f &&
            usableHeightMm > 0f;

        public Rect GetAvailableAreaMm()
        {
            float reservedHud = reserveHudArea ? hudWidthMm : 0f;

            float width = Mathf.Max(
                0f,
                usableWidthMm
                - marginLeftMm
                - marginRightMm
                - reservedHud);

            float height = Mathf.Max(
                0f,
                usableHeightMm
                - marginTopMm
                - marginBottomMm);

            return new Rect(
                marginLeftMm,
                marginBottomMm,
                width,
                height);
        }
    }
}