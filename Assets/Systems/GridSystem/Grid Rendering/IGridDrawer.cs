using System.Collections;
using System.Collections.Generic;
using nPuzzle.GridSystem;
using UnityEngine;

public interface IGridDrawer
{
    void DrawGrid(GridSo grid);
    public void UpdateGrid(GridSo gridData);
}
