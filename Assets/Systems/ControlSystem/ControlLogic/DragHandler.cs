using System;
using nPuzzle.Systems.ControlSystem.InputMethods;
using nPuzzle.Systems.GridSystem;
using nPuzzle.Systems.MovementSystem;
using UnityEngine;

namespace nPuzzle.Systems.ControlSystem.ControlLogic
{
    [RequireComponent(typeof(MouseInput))]
    public class DragHandler : MonoBehaviour
    {
        [SerializeField] private GridSo gridData;
        [SerializeField] private float movementThreshold = 0.5f;

        private Vector3 _initialTilePosition;
        private IInputHandler _inputHandler;
        private IMovementController _movementController;

        private void Awake()
        {
            _inputHandler = GetComponent<MouseInput>();
            _movementController = new DefaultMovementController(gridData);
        }

        private void Start()
        {
            _initialTilePosition = transform.position;
        }

        private void OnMouseDrag()
        {
            Vector3 currentMousePosition = _inputHandler.GetMouseWorldPosition();
            Vector3 dragDirection = currentMousePosition - _initialTilePosition;

            if (dragDirection.magnitude >= movementThreshold)
            {
                Vector2Int moveDirection = DetermineMoveDirection(dragDirection);
                MoveTile(moveDirection);
            }
        }

        private Vector2Int DetermineMoveDirection(Vector3 dragDirection)
        {
            return Math.Abs(dragDirection.x) > Math.Abs(dragDirection.y)
                ? (dragDirection.x > 0 ? _movementController.Right : _movementController.Left)
                : (dragDirection.y > 0 ? _movementController.Up : _movementController.Down);
        }

        private void MoveTile(Vector2Int direction)
        {
            _movementController.Move(direction);
        }
    }
}