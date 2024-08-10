using UnityEngine;

[ExecuteAlways]
public class DefaultGridDrawer : MonoBehaviour, IGridDrawer
{
    [SerializeField] private GameObject tilePrefab;
    [Range(0.5f,10f)]
    [SerializeField] private float distanceBetweenTiles = 1.5f;

    private GameObject[,] _tiles;

    public void Draw(GridSo grid)
    {
        if (grid == null || tilePrefab == null)
        {
            Debug.LogError("Grid or TilePrefab is not assigned.");
            return;
        }

        // Initialize the _tiles array
        _tiles = new GameObject[grid.rows, grid.columns];

        CreateTiles(grid.rows, grid.columns);
    }

    private void CreateTiles(int gridRows, int gridColumns)
    {
        for (int y = 0; y < gridRows; y++)
        {
            for (int x = 0; x < gridColumns; x++)
            {
                var tilePosition = new Vector3(x * distanceBetweenTiles, y * distanceBetweenTiles, 0);
                if (_tiles[x, y] != null)
                {
                    DestroyImmediate(_tiles[x, y]); // Clean up any existing tiles
                }
                _tiles[x, y] = Instantiate(tilePrefab, tilePosition, Quaternion.identity);
                _tiles[x, y].transform.SetParent(transform); // Optional: to keep hierarchy organized
            }
        }
    }
}