using UnityEngine;

public class DefaultObjectCreation:IObjectCreation
{
    public GameObject Create(GameObject prefab, Vector3 position)
    {
        return Object.Instantiate(prefab, position, Quaternion.identity);
    }
}