using UnityEngine;

namespace nPuzzle.GridSystem
{
    public class DefaultGridDrawer : MonoBehaviour, IGridDrawer
    {
        
        private readonly IObjectCreation _objectCreationHandler = new DefaultObjectCreation(); // Handles object creation

        public void DrawGrid(GridSo gridData)
        {
            if (gridData == null || gridData.tileSo.tilePrefab == null)
            {
                Debug.LogError("Grid data or tilePrefab is not assigned.");
                return;
            }
            InstantiateTiles(gridData);
        }

        private void InstantiateTiles(GridSo gridData)
        {
            int tileOrder = 1;
            for (int row = gridData.rows - 1; row >= 0; row--)
            {
                for (int column = 0; column < gridData.columns; column++)
                {
                    var tilePosition = gridData.Tiles[row, column].gridPosition;
                    
                    Debug.Log(column + "," + row + "," + tilePosition);
                    
                    gridData.InstantiatedTiles[row, column] = _objectCreationHandler.Create(tilePrefab, tilePosition, transform);
                    AssignTileName(tileOrder, column, row, gridData);
                    tileOrder++;
                }
            }
        }

        private void AssignTileName(int tileOrder, int column, int row, GridSo gridData)
        {
            bool isNotLastTile = tileOrder < gridData.InstantiatedTiles.GetLength(0) * gridData.InstantiatedTiles.GetLength(1);
            gridData.InstantiatedTiles[row, column].name = isNotLastTile ? tileOrder.ToString() : "";
        }

        public void UpdateGrid(GridSo gridData)
        {
            if (!HaveTilesChanged(gridData))
            {
                return;
            }
        
            for (int row = gridData.rows - 1; row >= 0; row--)
            {
                for (int column = 0; column < gridData.columns; column++)
                {
                    gridData.InstantiatedTiles[row, column].transform.position = gridData.Tiles[row, column].gridPosition;
                }
            }
        }

        private bool HaveTilesChanged(GridSo gridData)
        {
            for (int row = gridData.rows - 1; row >= 0; row--)
            {
                for (int column = 0; column < gridData.columns; column++)
                {
                    if (gridData.Tiles[row, column].gridPosition != gridData.InstantiatedTiles[row, column].transform.position)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
