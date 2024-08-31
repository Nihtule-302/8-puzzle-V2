using UnityEngine;

namespace nPuzzle.MovementSystem
{
    public interface IMovement
    {
        Vector2 Up    { get; }
        Vector2 Down  { get; }
        
        Vector2 Right { get; }
        Vector2 Left  { get; }
        
        public void Move(Vector2 direction);
    }
}