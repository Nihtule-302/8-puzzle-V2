using System;
using nPuzzle.GridSystem;
using UnityEngine;

namespace nPuzzle.InputSystem.ControlLogic
{
    public class Dragging : MonoBehaviour, IControls
    {
        [SerializeField] private GridSo gridInfo;
        [SerializeField] private float movementThreshold = 0.5f;
        private Vector3 _originalTilePosition;
        private MouseInput _mouseInput;

        private void Start()
        {
            _mouseInput = GetComponent<MouseInput>();
            _originalTilePosition = transform.position;
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

        private Vector2 DetermineMoveDirection(Vector3 movementDirection)
        {
            if (Math.Abs(movementDirection.x) >= Math.Abs(movementDirection.y))
            {
                return movementDirection.x > 0 ? Vector2.right : Vector2.left;
            }
            else
            {
                return movementDirection.y > 0 ? Vector2.up : Vector2.down;
            }
        }

        public void Move(Vector2 direction)
        {
        
        }
    }
}