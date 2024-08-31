using System;
using nPuzzle.Systems.ControlSystem.InputMethods;
using nPuzzle.Systems.GridSystem;
using nPuzzle.Systems.MovementSystem;
using Unity.VisualScripting;
using UnityEngine;

namespace nPuzzle.Systems.ControlSystem.ControlLogic
{
    [RequireComponent(typeof(MouseInput))]
    public class DragHandler : MonoBehaviour
    {
        [SerializeField] private GridSo gridData;
        [SerializeField] private float movementThreshold = 0.5f;

        private Vector3 _initialTilePosition;
        private MouseInput _inputHandler;
        private IMovement _movementController;

        private bool _canDrag = true; 
        private void Awake()
        {
            _inputHandler = GetComponent<MouseInput>();
            _movementController = new DefaultMovement(gridData);
        }

        private void Start()
        {
            _initialTilePosition = transform.position;
        }

        private void OnMouseDown()
        {
            if (gameObject.name.Equals(""))
            {
                return;
            }
            _canDrag = true;
        }

        private void OnMouseDrag()
        {
            if (!_canDrag) return;
            
            var currentMousePosition = _inputHandler.GetMouseWorldPosition();
            var dragDirection = currentMousePosition - _initialTilePosition;

            if (dragDirection.magnitude >= movementThreshold)
            {
                Vector2Int moveDirection = DetermineMoveDirection(dragDirection);
                MoveTile(moveDirection);
                _canDrag = false;
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