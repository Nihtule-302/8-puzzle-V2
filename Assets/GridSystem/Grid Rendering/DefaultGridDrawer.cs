using UnityEngine;

public class DefaultGridDrawer : MonoBehaviour, IGridDrawer
{
    [SerializeField] private GameObject tilePrefab;
    private GameObject[,] _tiles;
    
    private readonly IObjectCreation _objectCreation = new DefaultObjectCreation();
    

    public void Draw(GridSo grid)
    {
        if (grid == null || tilePrefab == null)
        {
            Debug.LogError("Grid or TilePrefab is not assigned.");
            return;
        }
        _tiles = new GameObject[grid.columns,grid.rows];

        CreateTiles(grid);
    }
    
    private void CreateTiles(GridSo grid)
    {
        int i = 1;
        for (int y = grid.rows-1 ; y >= 0; y--)
        {
            for (int x = 0; x < grid.columns; x++)
            {
                var position = grid.Tiles[x, y].gridPosition;

                _tiles[x, y] = _objectCreation.Create(tilePrefab,position);
                _tiles[x, y].transform.parent = transform;
                
                NameTiles(grid, i, x, y);

                i++;
            }
        }
        
    }

    private void NameTiles(GridSo grid, int i, int x, int y)
    {
        bool iteratorIsNotOnTheFinalTile = i < grid.rows * grid.columns;
        _tiles[x, y].name = iteratorIsNotOnTheFinalTile ? i.ToString() : "Empty Tile";
    }
}