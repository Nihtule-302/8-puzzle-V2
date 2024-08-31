using UnityEngine;

namespace nPuzzle.GridSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GridInfo", fileName = "Grid (n*m)")]
    public class GridSo : ScriptableObject
    {
        [Header("Grid Settings")]
        public int rows = 3;
        public int columns = 3;
        public TileSo tileConfiguration;

        public Vector2 GridCenter => new Vector2((columns - 1) * 0.5f, (rows - 1) * 0.5f);

        private int _cachedRowCount;
        private int _cachedColumnCount;
        private IGridInitializer _gridInitializer;

        public GridState CurrentGridState;

        public bool HasGridSizeChanged()
        {
            return _cachedRowCount != rows || _cachedColumnCount != columns;
        }

        private void OnValidate()
        {
            if (HasGridSizeChanged())
            {
                _cachedRowCount = rows;
                _cachedColumnCount = columns;
            }
        }
    }
}
