using UnityEngine;

public class DefaultGridFiller : IGridFiller
{
    public void FillGrid(GridSo gridInfo)
    {
        GridTile[,] tiles = new GridTile[gridInfo.rows, gridInfo.columns];
        int orderInGrid = 1;

        int lastRowIndex = gridInfo.rows - 1;
        int lastColumnIndex = gridInfo.columns - 1;

        for (int y = lastRowIndex; y >= 0; y--)
        {
            for (int x = 0; x <= lastColumnIndex; x++)
            {
                Vector2 gridPosition = CalculateGridPosition(x, y, gridInfo);
                string order = DetermineTileOrder(x, y, lastColumnIndex, orderInGrid);

                tiles[x, y] = new GridTile
                {
                    gridPosition = gridPosition,
                    orderInTheGrid = order
                };

                orderInGrid++;
            }
        }
        gridInfo.Tiles = tiles;
    }

    private Vector2 CalculateGridPosition(int x, int y, GridSo gridInfo)
    {
        return new Vector2(
            x * gridInfo.distanceBetweenTiles - gridInfo.CenterOfTheGrid.x,
            y * gridInfo.distanceBetweenTiles - gridInfo.CenterOfTheGrid.y
        );
    }

    private string DetermineTileOrder(int x, int y, int lastColumnIndex, int orderInGrid)
    {
        // Leave the bottom-right tile as empty
        return (y == 0 && x == lastColumnIndex) ? "" : orderInGrid.ToString();
    }
}