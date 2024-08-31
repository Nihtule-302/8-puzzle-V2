
using System;
using UnityEngine;

public class MouseInput: MonoBehaviour
{
    private Vector3 position;

    private void Start()
    {
        position = transform.position;
    }

    public Vector3 GetMouseWorldPosition()
    {
        var mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
