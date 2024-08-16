using UnityEngine;

namespace nPuzzle.GridSystem
{
    public interface IGridFiller
    {
        void FillGrid(out GridTile[,] tiles, Vector2Int gridDimensions, Vector2 centerOfTheGrid);
    }
}