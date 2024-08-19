using UnityEngine;

namespace nPuzzle.GridSystem
{
//     public class GridFiller_TheGridItSelfIsScalable : IGridInitializer
//     {
//         /*public void FillGrid(out GridTile[,] tiles, Vector2Int gridDimensions, Vector2 centerOfTheGrid)
//     {
//         GridTile[,] tiles = new GridTile[rows, columns];
//         int orderInGrid = 1;
//
//         int lastRowIndex = rows - 1;
//         int lastColumnIndex = columns - 1;
//
//         for (int y = lastRowIndex; y >= 0; y--)
//         {
//             for (int x = 0; x <= lastColumnIndex; x++)
//             {
//                 Vector2 gridPosition = CalculateGridPosition(x, y, gridInfo);
//                 string order = DetermineTileOrder(x, y, lastColumnIndex, orderInGrid);
//
//                 tiles[x, y] = new GridTile
//                 {
//                     gridPosition = gridPosition,
//                     orderInTheGrid = order
//                 };
//
//                 orderInGrid++;
//             }
//         }
//         gridInfo.Tiles = tiles;
//     }*/
//
//         /*private Vector2 CalculateGridPosition(int x, int y, GridSo gridInfo)
//     {
//         return new Vector2(
//             x * gridInfo.distanceBetweenTiles - gridInfo.CenterOfTheGrid.x,
//             y * gridInfo.distanceBetweenTiles - gridInfo.CenterOfTheGrid.y
//         );
//     }
//
//     private string DetermineTileOrder(int x, int y, int lastColumnIndex, int orderInGrid)
//     {
//         // Leave the bottom-right tile as empty
//         return (y == 0 && x == lastColumnIndex) ? "" : orderInGrid.ToString();
//     }*/
//
//         public void FillGrid(out GridTile[,] tiles, Vector2Int gridDimensions, Vector2 centerOfTheGrid)
//         {
//             throw new System.NotImplementedException();
//         }
//     }
}