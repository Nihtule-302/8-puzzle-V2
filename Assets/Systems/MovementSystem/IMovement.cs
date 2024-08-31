using UnityEngine;

namespace nPuzzle.Systems.MovementSystem
{
    public interface IMovement
    {
        Vector2Int Up    { get; }
        Vector2Int Down  { get; }
        
        Vector2Int Right { get; }
        Vector2Int Left  { get; }
        
        public void Move(Vector2Int direction);
    }
}