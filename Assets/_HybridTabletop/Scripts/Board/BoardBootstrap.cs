using UnityEngine;

namespace HybridTabletop.Board
{
    public class BoardBootstrap : MonoBehaviour
    {
        [SerializeField] private BoardProfile profile;

        public BoardProfile Profile => profile;
        public GridLayout Layout { get; private set; }
        public BoardCoordinateMapper CoordinateMapper { get; private set; }

        public bool IsReady { get; private set; }

        private void Awake()
        {
            Initialize();
        }

        [ContextMenu("Recalculate Board Layout")]
        public void Initialize()
        {
            IsReady = GridLayoutCalculator.TryCalculate(
                profile,
                out GridLayout layout);

            if (!IsReady)
            {
                Debug.LogError(
                    "Board non calibrato o troppo piccolo. " +
                    "Controlla BoardProfile.",
                    this);

                return;
            }

            Layout = layout;
            CoordinateMapper = new BoardCoordinateMapper(
                profile,
                layout);

            Debug.Log(
                $"Board pronto: {Layout}",
                this);
        }
    }
}