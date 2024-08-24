using nPuzzle.GridSystem;
using UnityEngine;

namespace nPuzzle.MovementSystem
{
    public class DefaultMovement: IMovement
    {
        public Vector2 Up => new(1, 0);
        public Vector2 Down => new(-1, 0);
        
        public Vector2 Right => new(0, 1);
        public Vector2 Left => new(0, -1);
        
        public Vector2Int EmptyTileIndex => GridState.EmptyTileIndex;
        
        public void Move(Vector2Int direction)
        {
            
        }
    }
}