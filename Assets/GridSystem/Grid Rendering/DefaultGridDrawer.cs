using UnityEngine;

[ExecuteAlways]
public class DefaultGridDrawer : MonoBehaviour,IGridDrawer
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject[,] _tiles;
    
    [Range(1f,50f)]
    [SerializeField] private float distanceBetweenTiles = 1.5f;
    
    public void Draw(GridSo grid)
    {
        
        CreateTiles(grid.rows, grid.columns);
        
    }

    private void CreateTiles(int gridRows, int gridColumns)
    {
        for (int y = 0; y < gridRows; y++)
        {
            for (int x = 0; x < gridColumns; x++)
            {
                var tilePosition = new Vector3(x * distanceBetweenTiles, y * distanceBetweenTiles, 0);
                _tiles[x, y] = Instantiate(tilePrefab, tilePosition, Quaternion.identity);
            }
        }
        
    }
}
