using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GridInfo", fileName = "Grid (n*m)")]
public class GridSo : ScriptableObject
{
    public int rows = 3;
    public int columns = 3;
    [Range(0.5f,10f)]
    public float distanceBetweenTiles = 1.5f;
    public Vector2 CenterOfTheGrid
    {
        get
        {
            float width = (columns - 1) * 0.5f;
            float height = (rows - 1) * 0.5f;
            return new Vector2(width * distanceBetweenTiles, height * distanceBetweenTiles);
        }
    }

    private int _cachedRows;
    private int _cachedColumns;

    private IGridFiller _gridFiller;
    
    public GridTile[,] Tiles;

    private void OnEnable()
    {
        _gridFiller ??= new DefaultGridFiller();
        InitializeGrid();
    }

    private void OnValidate()
    {
        _gridFiller ??= new DefaultGridFiller();

        InitializeGrid();
    }

    private void InitializeGrid()
    {
        if (_cachedRows == rows && _cachedColumns == columns && Tiles != null) return;
        
        _gridFiller.FillGrid(this);
        
        _cachedRows = rows;
        _cachedColumns = columns;
    }
}