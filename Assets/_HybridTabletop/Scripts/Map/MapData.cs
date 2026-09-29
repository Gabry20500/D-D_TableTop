using UnityEngine;
using HybridTabletop.Core;

namespace HybridTabletop.Map
{
    [CreateAssetMenu(
        fileName = "MapData",
        menuName = "Hybrid Tabletop/Map Data")]
    public class MapData : ScriptableObject
    {
        [Min(1)] public int columns = 80;
        [Min(1)] public int rows = 60;

        public GridSize Size => new GridSize(columns, rows);
    }
}
