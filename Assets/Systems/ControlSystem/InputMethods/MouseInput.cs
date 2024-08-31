using UnityEngine;

namespace nPuzzle.Systems.ControlSystem.InputMethods
{
    public class MouseInput: MonoBehaviour
    {
        private Vector3 _position;

        private void Start()
        {
            _position = transform.position;
        }

        public Vector3 GetMouseWorldPosition()
        {
            var mousePoint = Input.mousePosition;
            mousePoint.z = Camera.main.WorldToScreenPoint(_position).z;
            return Camera.main.ScreenToWorldPoint(mousePoint);
        }
    }
}
