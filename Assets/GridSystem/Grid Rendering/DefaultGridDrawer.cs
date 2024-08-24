using UnityEngine;

namespace nPuzzle.GridSystem
{
    public class DefaultGridDrawer : MonoBehaviour, IGridDrawer
    {
        public void DrawGrid(GridSo gridData)
        {
            if (IsGridDataInvalid(gridData)) return;
            
            DrawTiles(gridData);
        }

        private bool IsGridDataInvalid(GridSo gridData)
        {
            if (gridData == null || gridData.tileConfiguration.tilePrefab == null)
            {
                Debug.LogError("Grid data or tilePrefab is not assigned.");
                return true;
            }
            return false;
        }

        private void DrawTiles(GridSo gridData)
        {
            for (int row = gridData.rows - 1; row >= 0; row--)
            {
                for (int column = 0; column < gridData.columns; column++)
                {
                    Vector3 tilePosition = gridData.CurrentGridState.Tiles[row, column].Position;
                    gridData.CurrentGridState.SpawnTile(row, column, tilePosition,transform);
                }
            }
        }

        public void UpdateGrid(GridSo gridData)
        {
            if (!HaveTilePositionsChanged(gridData)) return;

            UpdateTilePositions(gridData);
        }

        private bool HaveTilePositionsChanged(GridSo gridData)
        {
            for (int row = gridData.rows - 1; row >= 0; row--)
            {
                for (int column = 0; column < gridData.columns; column++)
                {
                    if (gridData.CurrentGridState.Tiles[row, column].Position != gridData.CurrentGridState.SpawnedTiles[row, column].transform.position)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void UpdateTilePositions(GridSo gridData)
        {
            for (int row = gridData.rows - 1; row >= 0; row--)
            {
                for (int column = 0; column < gridData.columns; column++)
                {
                    gridData.CurrentGridState.SpawnedTiles[row, column].transform.position = gridData.CurrentGridState.Tiles[row, column].Position;
                }
            }
        }
    }
}
