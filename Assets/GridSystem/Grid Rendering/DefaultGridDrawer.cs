using UnityEditor;
using UnityEngine;

public class DefaultGridDrawer : MonoBehaviour, IGridDrawer
{
    [SerializeField] private GameObject tilePrefab; // Prefab to instantiate for each grid tile
    private GameObject[,] _instantiatedTiles; // Array to hold references to instantiated tile GameObjects
    private string[,] _instantiatedTileNames; // Array to store the names of the tiles for change detection
    private readonly IObjectCreation _objectCreationHandler = new DefaultObjectCreation(); // Handles object creation

    public void DrawGrid(GridSo gridData)
    {
        if (gridData == null || tilePrefab == null)
        {
            Debug.LogError("Grid data or tilePrefab is not assigned.");
            return;
        }

        _instantiatedTiles = new GameObject[gridData.columns, gridData.rows];
        _instantiatedTileNames = new string[gridData.columns, gridData.rows]; // Initialize the tileNames array

        InstantiateTiles(gridData);
    }

    private void InstantiateTiles(GridSo gridData)
    {
        int tileOrder = 1;
        for (int row = gridData.rows - 1; row >= 0; row--)
        {
            for (int column = 0; column < gridData.columns; column++)
            {
                var tilePosition = gridData.Tiles[column, row].gridPosition;

                _instantiatedTiles[column, row] = _objectCreationHandler.Create(tilePrefab, tilePosition);
                _instantiatedTiles[column, row].transform.parent = transform;

                AssignTileName(tileOrder, column, row);

                tileOrder++;
            }
        }
    }

    private void AssignTileName(int tileOrder, int column, int row)
    {
        bool isNotLastTile = tileOrder < _instantiatedTiles.GetLength(0) * _instantiatedTiles.GetLength(1);
        _instantiatedTiles[column, row].name = isNotLastTile ? tileOrder.ToString() : "";
        _instantiatedTileNames[column, row] = _instantiatedTiles[column, row].name;
    }

    public void UpdateGrid(GridSo gridData)
    {
        if (!HaveTilesChanged(gridData))
        {
            return;
        }
        
        for (int row = gridData.rows - 1; row >= 0; row--)
        {
            for (int column = 0; column < gridData.columns; column++)
            {
                _instantiatedTiles[column, row].transform.position = gridData.Tiles[column, row].gridPosition;
            }
        }
    }

    private bool HaveTilesChanged(GridSo gridData)
    {
        for (int row = gridData.rows - 1; row >= 0; row--)
        {
            for (int column = 0; column < gridData.columns; column++)
            {
                if (gridData.Tiles[column, row].orderInTheGrid.ToString() != _instantiatedTileNames[column, row] || 
                    gridData.Tiles[column, row].gridPosition != _instantiatedTiles[column, row].transform.position)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
