using UnityEngine;

namespace nPuzzle.GridSystem
{
    public class DefaultGridFiller: IGridFiller
    {
        public void FillGrid( out GridTile[,] tiles, Vector2Int gridDimensions, Vector2 centerOfTheGrid)
        {
            var rows = gridDimensions.x;
            var columns = gridDimensions.y;
            tiles = new GridTile[rows, columns];
            int orderInGrid = 1;

            int lastRowIndex = rows - 1;
            int lastColumnIndex = columns - 1;

            for (int y = lastRowIndex; y >= 0; y--)
            {
                for (int x = 0; x <= lastColumnIndex; x++)
                {
                    Vector2 gridPosition = CalculateGridPosition(x, y, centerOfTheGrid);
                    string order = DetermineTileOrder(x, y, lastColumnIndex, orderInGrid);

                    tiles[x, y] = new GridTile
                    {
                        gridPosition = gridPosition,
                        orderInTheGrid = order
                    };

                    orderInGrid++;
                }
            }
        }

        private Vector2 CalculateGridPosition(int x, int y, Vector2 centerOfTheGrid)
        {
            return new Vector2(
                x - centerOfTheGrid.x,
                y - centerOfTheGrid.y
            );
        }

        private string DetermineTileOrder(int x, int y, int lastColumnIndex, int orderInGrid)
        {
            // Leave the bottom-right tile as empty
            return (y == 0 && x == lastColumnIndex) ? "" : orderInGrid.ToString();
        }
    }
}
