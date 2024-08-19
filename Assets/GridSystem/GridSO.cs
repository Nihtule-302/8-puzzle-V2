using System;
using UnityEngine;
using UnityEngine.Serialization;

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
        
        public TileSo tileSo;

        private int _cachedRows;
        private int _cachedColumns;

        private IGridInitializer _gridFiller;
    
        public GridState GridState;
        
        private void OnEnable()
        {
            _gridFiller ??= new GridInitializer();

            GridState = new GridState(this);
            InitializeGrid(this);
        }

        private void InitializeGrid(GridSo gridSo)
        {
            if (_cachedRows == gridSo.rows && _cachedColumns == gridSo.columns) return;
            _gridFiller.InitializeGrid(gridSo);
        
            _cachedRows = gridSo.rows;
            _cachedColumns = gridSo.columns;
        }
        
    }
    
    public class GridState
    {
        public class TileState
        {
            public Vector3 Position;
            public String OrderInTheGrid;
            public static int TilesUsed = 0;
        }
        
        public TileState[,] Tiles;
        public GameObject[,] InstantiatedTiles;
        
        private GridSo _gridSo;

        public GridState(GridSo gridInfo)
        {
            Tiles = new TileState[gridInfo.rows, gridInfo.columns];
            InstantiatedTiles = new GameObject[gridInfo.rows, gridInfo.columns];
            _gridSo = gridInfo;
        }

        public void AddTile(int row, int column, Vector3 position)
        {
            TileState.TilesUsed++;
            
            var orderInTheGrid = DetermineTileLabel(row, column, _gridSo.columns-1);
            
            Tiles[row, column] = new TileState
            {
                Position = position,
                OrderInTheGrid = orderInTheGrid
            };
        }
        
        private string DetermineTileLabel(int rowIndex,int columnIndex,  int lastColumnIndex)
        {
            // Leaves the bottom-right tile empty
            bool isBottomRightTile = (rowIndex == 0 && columnIndex == lastColumnIndex);
            string tileLabel = isBottomRightTile ? "" : TileState.TilesUsed.ToString();
            return tileLabel;
        }

        public void InstantiateTile(int row, int column, Vector3 position, Transform parent)
        {
            var tilePrefab = _gridSo.tileSo.tilePrefab;
            InstantiatedTiles[row, column] = GameObject.Instantiate(tilePrefab, position, Quaternion.identity, parent);
            InstantiatedTiles[row, column].name = Tiles[row, column].OrderInTheGrid;
        }
        
    }
}