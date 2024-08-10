using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GridSo gridInfo;
    private IGridDrawer _gridDrawer;
    
    void Start()
    {
        _gridDrawer = GetComponent<IGridDrawer>();
        _gridDrawer.Draw(gridInfo);
    }

    private void Update()
    {
        _gridDrawer.Draw(gridInfo);
    }
}
