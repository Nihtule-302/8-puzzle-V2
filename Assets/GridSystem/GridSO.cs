using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GridInfo", fileName = "Grid (n*m)")]
public class GridSo : ScriptableObject
{
    public int rows = 3;
    public int columns = 3;
    
    private int _cachedRows = 0;
    private int _cachedColumns = 0;

    private IGridFiller _gridFiller;
    
    public GridTile[,] Tiles;

    private void OnEnable()
    {
        if (_gridFiller == null)
        {
            _gridFiller = new DefaultGridFiller();
        }
        InitializeGrid();
    }

    private void OnValidate()
    {
        if (_gridFiller == null)
        {
            _gridFiller = new DefaultGridFiller();
        }
        
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        if (_cachedRows == rows && _cachedColumns == columns && Tiles != null) return;
        
        Tiles = _gridFiller.FillGrid(rows, columns);
        _cachedRows = rows;
        _cachedColumns = columns;
    }
}