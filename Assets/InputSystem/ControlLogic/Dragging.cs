using UnityEngine;

public class Dragging: MonoBehaviour, IControls
{
    [SerializeField] private GridSo gridInfo;
    
    
    
    public void Move(Vector2 direction)
    {
        throw new System.NotImplementedException();
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
