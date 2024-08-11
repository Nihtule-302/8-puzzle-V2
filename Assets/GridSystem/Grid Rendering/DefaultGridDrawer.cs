using UnityEngine;

[ExecuteAlways]
public class DefaultGridDrawer : MonoBehaviour, IGridDrawer
{
    [SerializeField] private GameObject tilePrefab;
    private GameObject[,] _tiles;
    
    [Range(0.5f,10f)]
    [SerializeField] private float distanceBetweenTiles = 1.5f;

    private readonly IObjectCreation _objectCreation = new DefaultObjectCreation();
    

    public void Draw(GridSo grid)
    {
        if (grid == null || tilePrefab == null)
        {
            Debug.LogError("Grid or TilePrefab is not assigned.");
            return;
        }
        _tiles = new GameObject[grid.rows, grid.columns];

        CreateTiles(grid.rows, grid.columns);
    }
    
    private void CreateTiles(int gridRows, int gridColumns)
    {
        float width = (gridColumns - 1) * 0.5f;
        float height = (gridRows - 1) * 0.5f;
        Vector2 centerOfTheGrid = new Vector2(width * distanceBetweenTiles, height * distanceBetweenTiles);

        for (int y = 0; y < gridRows; y++)
        {
            for (int x = 0; x < gridColumns; x++)
            {
                var position = new Vector3(x * distanceBetweenTiles - centerOfTheGrid.x,
                                           y * distanceBetweenTiles - centerOfTheGrid.y);

                _tiles[x, y] = _objectCreation.Create(tilePrefab,position);
                _tiles[x, y].transform.parent = transform;
            }
        }
        
    }
}