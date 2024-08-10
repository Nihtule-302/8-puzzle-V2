using UnityEngine;

public class DefaultGridFiller : IGridFiller
{
    public GridTile[,] FillGrid(int rows, int columns)
    {
        GridTile[,] tiles = new GridTile[rows, columns];
        int orderInGrid = 1;
 
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                tiles[x, y] = new GridTile
                {
                    GridPosition = new Vector2(x, y),
                    OrderInTheGrid = orderInGrid++
                };
            }
        }

        return tiles;
    }
}