using UnityEngine;

namespace nPuzzle.GridSystem
{
    public interface IGridInitializer
    {
        void InitializeGrid(GridSo grid);
    }
}