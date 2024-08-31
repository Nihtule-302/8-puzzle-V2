using UnityEngine;

namespace nPuzzle.GridSystem
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private GridSo gridInfo;
        public GridSo GridInfo => gridInfo;
        private IGridDrawer _gridDrawer;
        private IGridInitializer _gridInitializer;
    
        void Awake()
        {
            _gridDrawer = GetComponent<IGridDrawer>();
            _gridInitializer = GetComponent<IGridInitializer>();
            
            _gridInitializer.InitializeGrid(gridInfo);
            _gridDrawer.DrawGrid(gridInfo);
        }

        private void Update()
        {
            if (gridInfo.HasGridSizeChanged())
            {
                _gridInitializer.InitializeGrid(gridInfo);
            }
            _gridDrawer.UpdateGrid(gridInfo);
        }
    }
}
