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
            if (_cachedRows == rows && _cachedColumns == columns && Tiles != null) return;
            _gridFiller.InitializeGrid(gridSo);
        
            _cachedRows = rows;
            _cachedColumns = columns;
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

        public GridState(GridSo gridInfo)
        {
            Tiles = new TileState[gridInfo.rows, gridInfo.columns];
            InstantiatedTiles = new GameObject[gridInfo.rows, gridInfo.columns];
        }

        public void AddTile(int row, int column, Vector3 position, TileSo tileSo)
        {
            TileState.TilesUsed++;
            
            Tiles[row, column] = new TileState
            {
                Position = position,
                OrderInTheGrid = TileState.TilesUsed.ToString()
            };
        }

        public void InstantiateTile(int row, int column, Vector3 position, Transform parent, TileSo tileSo)
        {
            var tilePrefab = tileSo.tilePrefab;
            InstantiatedTiles[row, column] = GameObject.Instantiate(tilePrefab, position, Quaternion.identity, parent);
            InstantiatedTiles[row, column].name = Tiles[row, column].OrderInTheGrid;
        }
        
    }
}