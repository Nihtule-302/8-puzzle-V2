using UnityEngine;

public class DefaultGridFiller : IGridFiller
{
    public void FillGrid(GridSo gridInfo)
    {
        GridTile[,] tiles = new GridTile[gridInfo.rows, gridInfo.columns];
        int orderInGrid = 1;

        int height = gridInfo.rows - 1;
        int width = gridInfo.columns - 1;
 
        for (int y = height; y >= 0; y--)
        {
            for (int x = 0; x <= width; x++)
            {
                tiles[x, y] = new GridTile
                {
                    gridPosition = new Vector2(x * gridInfo.distanceBetweenTiles - gridInfo.CenterOfTheGrid.x,
                                               y * gridInfo.distanceBetweenTiles - gridInfo.CenterOfTheGrid.y),
                    orderInTheGrid = orderInGrid++
                };
            }
        }
        gridInfo.Tiles = tiles;
    }
}