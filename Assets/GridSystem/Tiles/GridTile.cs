using System;
using UnityEngine;

namespace nPuzzle.GridSystem
{
    [Serializable]
    public class GridTile
    {
        public Vector3 gridPosition;
        public string orderInTheGrid;
    }
}