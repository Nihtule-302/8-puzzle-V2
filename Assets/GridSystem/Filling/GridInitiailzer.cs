using UnityEngine;
using UnityEngine.UI;

namespace nPuzzle.GridSystem
{
    public class GridInitializer: MonoBehaviour, IGridInitializer
    {
        private Vector2 _gridCenter;
        
        public void InitializeGrid(GridSo grid)
        {
            _gridCenter = grid.GridCenter;
            grid.CurrentGridState ??= new GridState(grid);
            FillTilesArray(grid);
        }

        private void FillTilesArray(GridSo grid)
        {
            for (int rowIndex = grid.rows - 1; rowIndex >= 0; rowIndex--)
            {
                for (int columnIndex = 0; columnIndex < grid.columns; columnIndex++)
                {
                    Vector2 tilePosition = CalculateTilePosition(rowIndex, columnIndex, _gridCenter);
                    grid.CurrentGridState.AddTile(rowIndex, columnIndex, tilePosition);
                }
            }
            grid.CurrentGridState.FindEmptyTileIndex();
        }

        private Vector2 CalculateTilePosition(int rowIndex, int columnIndex, Vector2 gridCenter)
         {
             // Adjusts the tile position based on the grid’s center point
             return new Vector2(
                 columnIndex - gridCenter.x,
                 rowIndex - gridCenter.y
             );
         }
        
    }
}