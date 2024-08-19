using UnityEngine;

namespace nPuzzle.GridSystem
{
    // public class DefaultGridFiller : IGridInitializer
    // {
    //     public void FillGrid(out GridTile[,] gridTiles, Vector2Int gridSize, Vector2 gridCenter)
    //     {
    //         int rowCount = gridSize.x;
    //         int columnCount = gridSize.y;
    //         var lastColumnIndex = columnCount - 1;
    //         
    //         gridTiles = new GridTile[columnCount, rowCount];
    //         int tileOrder = 1;
    //
    //         for (int rowIndex = rowCount - 1; rowIndex >= 0; rowIndex--)
    //         {
    //             for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
    //             {
    //                 Vector2 tilePosition = CalculateTilePosition(columnIndex, rowIndex, gridCenter);
    //                 string tileLabel = DetermineTileLabel(columnIndex, rowIndex, lastColumnIndex,ref tileOrder);
    //
    //                 gridTiles[columnIndex, rowIndex] = CreateGridTile(tilePosition, tileLabel);
    //             }
    //         }
    //     }
    //
    //     private Vector2 CalculateTilePosition(int columnIndex, int rowIndex, Vector2 gridCenter)
    //     {
    //         // Adjusts the tile position based on the grid’s center point
    //         return new Vector2(
    //             columnIndex - gridCenter.x,
    //             rowIndex - gridCenter.y
    //         );
    //     }
    //
    //     private string DetermineTileLabel(int columnIndex, int rowIndex, int lastColumnIndex, ref int tileOrder)
    //     {
    //         //if (columnIndex == lastColumnIndex && rowIndex == lastRowIndex) return "";
    //         
    //         // Leaves the bottom-right tile empty
    //         bool isBottomRightTile = (rowIndex == 0 && columnIndex == lastColumnIndex);
    //         string tileLabel = isBottomRightTile ? "" : tileOrder.ToString();
    //         tileOrder++;
    //         return tileLabel;
    //     }
    //
    //     private GridTile CreateGridTile(Vector2 position, string label)
    //     {
    //         return new GridTile
    //         {
    //             gridPosition = position,
    //             orderInTheGrid = label
    //         };
    //     }
    // }
}