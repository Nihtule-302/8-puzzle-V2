using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class GridTile
{
    public Vector2 gridPosition;
    public int orderInTheGrid;
}