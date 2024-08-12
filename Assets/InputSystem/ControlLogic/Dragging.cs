using System;
using UnityEngine;

public class Dragging: MonoBehaviour, IControls
{
    [SerializeField] private GridSo gridInfo;
    private Vector3 _orginalTilePosition;

    private void Start()
    {
        _orginalTilePosition = transform.position;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = transform.position.z;

        return mousePosition;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition();
        var movementDirection = GetMouseWorldPosition() - _orginalTilePosition;
        if (Math.Abs(movementDirection.x) >= Math.Abs(movementDirection.y) && movementDirection.x > 0)
        {
            Move(Vector2.right);
            return;
        }
        if (Math.Abs(movementDirection.x) >= Math.Abs(movementDirection.y) && movementDirection.x < 0)
        {
            Move(Vector2.left);
            return;
        }
        
        if (Math.Abs(movementDirection.x) <= Math.Abs(movementDirection.y) && movementDirection.y > 0)
        {
            Move(Vector2.up);
            return;
        }
        if (Math.Abs(movementDirection.x) <= Math.Abs(movementDirection.y) && movementDirection.y < 0)
        {
            Move(Vector2.down);
            return;
        }
    }

    public void Move(Vector2 direction)
    {
        
    }

    public void Enable()
    {
        this.enabled = true;
    }

    public void Disable()
    {
        this.enabled = false;
    }
}
