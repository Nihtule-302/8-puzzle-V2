using UnityEngine;

namespace nPuzzle.GridSystem
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private GridSo gridInfo;
        private IGridDrawer _gridDrawer;
    
        void Start()
        {
            _gridDrawer = GetComponent<IGridDrawer>();
            _gridDrawer.DrawGrid(gridInfo);
        }

        private void Update()
        {
            _gridDrawer.UpdateGrid(gridInfo);
        }
    }
}
