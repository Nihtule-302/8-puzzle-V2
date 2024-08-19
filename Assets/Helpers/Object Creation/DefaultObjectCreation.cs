using UnityEngine;

public class DefaultObjectCreation:IObjectCreation
{
    public GameObject Create(GameObject prefab, Vector3 position)
    {
        return Object.Instantiate(prefab, position, Quaternion.identity);
    }

    public GameObject Create(GameObject tilePrefab, Vector3 tilePosition, Transform parent)
    {
        return Object.Instantiate(tilePrefab, tilePosition, Quaternion.identity, parent);
    }
}