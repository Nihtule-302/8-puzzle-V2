using nPuzzle.Systems.GridSystem;
using UnityEngine;

namespace nPuzzle.Rules
{
    public static class MovementRules
    {
        private static GridSo CurrentGrid => GameSettings.GetCurrentGrid();

        public static bool CanMove(Vector2 tileIndex, Vector2 direction)
        {
            var rows = CurrentGrid.rows;
            var columns = CurrentGrid.columns;
            
            var newTileIndex = tileIndex + direction;

            var isTileOutOfColumnRange = newTileIndex.x > columns - 1 || newTileIndex.x < 0;
            var isTileOutOfRowRange = newTileIndex.y > rows - 1 || newTileIndex.y < 0;
            var isTileOutOfGrid =  isTileOutOfColumnRange || isTileOutOfRowRange;

            if (isTileOutOfGrid)
            {
                return false;
            }
            
            return true;
        }

    }
}