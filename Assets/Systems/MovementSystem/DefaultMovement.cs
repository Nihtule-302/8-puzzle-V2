using nPuzzle.Rules;
using nPuzzle.Systems.GridSystem;
using UnityEngine;

namespace nPuzzle.Systems.MovementSystem
{
    public class DefaultMovement: IMovement
    {
        public Vector2Int Up => new(1, 0);
        public Vector2Int Down => new(-1, 0);
        
        public Vector2Int Right => new(0, 1);
        public Vector2Int Left => new(0, -1);
        
        private Vector2Int _emptyTileIndex;

        private readonly GridSo _currentGrid;

        public DefaultMovement(GridSo currentGrid)
        {
            _currentGrid = currentGrid;
        }

        public void Move(Vector2Int direction)
        {
            var emptyTileIndex = _currentGrid.CurrentGridState.EmptyTileIndex;

            if (!MovementRules.CanMove(emptyTileIndex, direction))
            {
                StartInvalidMoveSequence();
                return;
            }
            
            var newTileIndex = emptyTileIndex + direction;
            SwitchTile(emptyTileIndex, newTileIndex);
        }

        private void SwitchTile(Vector2Int emptyTileIndex, Vector2Int newTileIndex)
        {
            
            var tempPosition = _currentGrid.CurrentGridState.Tiles[emptyTileIndex.x, emptyTileIndex.y].Position;
            _currentGrid.CurrentGridState.Tiles[emptyTileIndex.x, emptyTileIndex.y].Position = 
                _currentGrid.CurrentGridState.Tiles[newTileIndex.x, newTileIndex.y].Position;
            
            _currentGrid.CurrentGridState.Tiles[newTileIndex.x, newTileIndex.y].Position = tempPosition;
        }

        private void StartInvalidMoveSequence()
        {
        }
    }
}