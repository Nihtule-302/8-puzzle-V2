using System;
using Unity.VisualScripting;
using UnityEngine;

public class Swiping: MonoBehaviour, IControls
{
    [SerializeField] private GridSo gridInfo;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector2.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector2.right);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector2.up);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector2.down);
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
