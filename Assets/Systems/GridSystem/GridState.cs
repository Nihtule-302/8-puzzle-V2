using TMPro;
using UnityEngine;

namespace nPuzzle.Systems.GridSystem
{
    public class GridState
    {
        public class TileState
        {
            public Vector3 Position { get; set; }
            public string TileLabel { get; set; }
            
        }

        private int TotalTilesCreated { get; set; }
        private void IncrementTileCount() => TotalTilesCreated++;

        private readonly string _emptyTileString;

        public TileState[,] Tiles { get; private set; }
        public Vector2Int EmptyTileIndex;
        
        public GameObject[,] SpawnedTiles { get; private set; }

        private readonly GridSo _gridSo;

        public GridState(GridSo gridSo)
        {
            _gridSo = gridSo;
            _emptyTileString = _gridSo.tileConfiguration.emptyTileString;
            
            InitializeTileArrays(gridSo.rows, gridSo.columns);
        }

        private void InitializeTileArrays(int rows, int columns)
        {
            Tiles = new TileState[rows, columns];
            SpawnedTiles = new GameObject[rows, columns];
            FindEmptyTileIndex();
        }

        private void FindEmptyTileIndex()
        {
            EmptyTileIndex = new Vector2Int(0, _gridSo.columns -1);
        }


        public void AddTile(int row, int column, Vector3 position)
        {
            IncrementTileCount();
            var tileLabel = GenerateTileLabel(row, column, _gridSo.columns - 1);
            //Debug.Log($"{row}, {column}, {tileLabel}");

            Tiles[row, column] = new TileState
            {
                Position = position,
                TileLabel = tileLabel
            };
        }

        private string GenerateTileLabel(int row, int column, int lastColumnIndex)
        {
            bool isBottomRightTile = (row == 0 && column == lastColumnIndex);
            
            return isBottomRightTile ? _emptyTileString : TotalTilesCreated.ToString();
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