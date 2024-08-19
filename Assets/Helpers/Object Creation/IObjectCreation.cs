using UnityEngine;

public interface IObjectCreation
{
    GameObject Create(GameObject gameObject,Vector3 position);

    GameObject Create(GameObject tilePrefab, Vector3 tilePosition, Transform transform);
}