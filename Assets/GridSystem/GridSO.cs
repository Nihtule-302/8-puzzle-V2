using UnityEngine;

namespace nPuzzle.GridSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GridInfo", fileName = "Grid (n*m)")]
    public class GridSo : ScriptableObject
    {
        public int rows = 3;
        public int columns = 3;
        public Vector2 CenterOfTheGrid
        {
            get
            {
                float width = (columns - 1) * 0.5f;
                float height = (rows - 1) * 0.5f;
                return new Vector2(width, height);
            }
        }

        private int _cachedRows;
        private int _cachedColumns;

        private IGridFiller _gridFiller;
    
        public GridTile[,] Tiles;

        private void OnEnable()
        {
            _gridFiller ??= new DefaultGridFiller();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            if (_cachedRows == rows && _cachedColumns == columns && Tiles != null) return;
            _gridFiller.FillGrid(out Tiles, new Vector2Int(rows,columns), CenterOfTheGrid);
        
            _cachedRows = rows;
            _cachedColumns = columns;
        }
        
    }
}