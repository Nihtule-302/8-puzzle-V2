using System;
using nPuzzle.GridSystem;
using nPuzzle.MovementSystem;
using UnityEngine;

namespace nPuzzle.InputSystem.ControlLogic
{
    public class Dragging : MonoBehaviour, IControls
    {
        [SerializeField] private GridSo gridInfo;
        [SerializeField] private float movementThreshold = 0.5f;
        
        private Vector3 _originalTilePosition;
        private MouseInput _mouseInput;
        private IMovement _movementController;

        private void Start()
        {
            _mouseInput = GetComponent<MouseInput>();
            _originalTilePosition = transform.position;
            _movementController = new DefaultMovement();
        }

        private void OnMouseDrag()
        {
            var currentMousePosition = _mouseInput.GetMouseWorldPosition();
            var movementDirection = currentMousePosition - _originalTilePosition;

            if (movementDirection.magnitude >= movementThreshold)
            {
                var moveDirection = DetermineMoveDirection(movementDirection);
                Debug.Log(moveDirection.ToString());
                Move(moveDirection);
            }
        }

        private Vector2Int DetermineMoveDirection(Vector3 movementDirection)
        {
            if (Math.Abs(movementDirection.x) >= Math.Abs(movementDirection.y))
            {
                return movementDirection.x > 0 ? Vector2Int.right : Vector2Int.left;
            }
            else
            {
                return movementDirection.y > 0 ? Vector2Int.up : Vector2Int.down;
            }
        }

        public void Move(Vector2Int direction)
        {
            _movementController.Move(direction);
        }
    }
}