using nPuzzle.GridSystem;
using UnityEngine;

namespace nPuzzle
{
    public class WorldToGrid : ScriptableObject
    {
        // Use Lazy Initialization to avoid repeated resource loading
        

        public static Vector2Int ConvertToGridSpace(Vector3 worldPosition, GridSo gridInfo)
        {
            if (gridInfo == null)
            {
                Debug.LogError("GridInfo is not loaded. Ensure the ScriptableObject is in the Resources folder.");
                return Vector2Int.zero; // Return a default value or handle the error appropriately
            }

            // Adjust world position based on grid's center
            var gridPositionX = (int)((worldPosition.x + gridInfo.CenterOfTheGrid.x));
            var gridPositionY = (int)((worldPosition.y + gridInfo.CenterOfTheGrid.y));

            return new Vector2Int(gridPositionX, gridPositionY);
        }
    }
}