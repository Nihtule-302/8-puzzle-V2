using UnityEngine;

namespace nPuzzle.GridSystem
{
    public interface IGridFiller
    {
        void FillGrid(out GridTile[,] gridTiles, Vector2Int gridSize, Vector2 gridCenter);
    }
}