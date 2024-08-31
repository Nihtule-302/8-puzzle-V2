using TMPro;
using UnityEngine;

namespace nPuzzle.GridSystem
{
    public class GridState
    {
        public class TileState
        {
            public Vector3 Position { get; set; }
            public string TileLabel { get; set; }
            public static string EmptyTileString => string.Empty;
            public static int TotalTilesCreated { get; private set; }

            public static void IncrementTileCount() => TotalTilesCreated++;
        }

        public TileState[,] Tiles { get; private set; }
        public static Vector2Int EmptyTileIndex;
        
        public GameObject[,] SpawnedTiles { get; private set; }

        private readonly GridSo _gridSo;

        public GridState(GridSo gridSo)
        {
            _gridSo = gridSo;
            InitializeTileArrays(gridSo.rows, gridSo.columns);
        }

        private void InitializeTileArrays(int rows, int columns)
        {
            Tiles = new TileState[rows, columns];
            SpawnedTiles = new GameObject[rows, columns];
        }

        public void FindEmptyTileIndex()
        {
            for (int row = _gridSo.rows - 1; row >= 0; row--)
            {
                for (int column = 0; column < _gridSo.columns; column++)
                {
                    bool currentTileEmpty = _gridSo.CurrentGridState.Tiles[row, column].TileLabel
                        .Equals(TileState.EmptyTileString);
                    
                    if (currentTileEmpty)
                    {
                        EmptyTileIndex = new Vector2Int(row, column);
                    }
                }
            }
        }


        public void AddTile(int row, int column, Vector3 position)
        {
            TileState.IncrementTileCount();
            var tileLabel = GenerateTileLabel(row, column, _gridSo.columns - 1);
            Debug.Log($"{row}, {column}, {tileLabel}");

            Tiles[row, column] = new TileState
            {
                Position = position,
                TileLabel = tileLabel
            };
        }

        private string GenerateTileLabel(int row, int column, int lastColumnIndex)
        {
            bool isBottomRightTile = (row == 0 && column == lastColumnIndex);
            
            return isBottomRightTile ? TileState.EmptyTileString : TileState.TotalTilesCreated.ToString();
        }

        public void SpawnTile(int row, int column, Vector3 position, Transform parent)
        {
            var tilePrefab = _gridSo.tileConfiguration.tilePrefab;
            var instantiatedTile = GameObject.Instantiate(tilePrefab, position, Quaternion.identity, parent);
            instantiatedTile.name = Tiles[row, column].TileLabel;

            var text = instantiatedTile.GetComponentInChildren<TextMeshPro>();
            text.text = Tiles[row, column].TileLabel;
            
            SpawnedTiles[row, column] = instantiatedTile;
        }
    }
}