using TMPro;
using UnityEngine;

namespace nPuzzle.GridSystem
{
    public class FontProperties : MonoBehaviour
    {
        private TextMeshPro _text;
        private GridSo _gridInfo;
        [SerializeField] private TileSo tileProperties;

        private Color _cachedColor;
        private float _cachedFontSize;

        private void Start()
        {
            _gridInfo = Resources.Load<GridSo>("ScriptableObjects/Grids/Grid");
            _text = GetComponentInChildren<TextMeshPro>();

            // Initial setup
            ApplyFontProperties();
        }
        
        private void Update()
        {
            // Update only if properties have changed
            if (_cachedColor != tileProperties.fontColor)
            {
                ApplyFontColor();
            }

            if (!Mathf.Approximately(_cachedFontSize, tileProperties.fontSize))
            {
                ApplyFontSize();
            }
            //NameTheTiles();
        }

        private void ApplyFontSize()
        {
            _cachedFontSize = tileProperties.fontSize;
            _text.fontSize = _cachedFontSize;
        }

        private void ApplyFontColor()
        {
            _cachedColor = tileProperties.fontColor;
            _text.color = _cachedColor;
        }

        private void ApplyFontProperties()
        {
            ApplyFontSize();
            ApplyFontColor();
            NameTheTiles();
        }

        private void NameTheTiles()
        {
            var gridIndex = WorldToGrid.ConvertToGridSpace(transform.transform.position, _gridInfo);
            string tileName = _gridInfo.Tiles[gridIndex.x, gridIndex.y].orderInTheGrid;
            _text.text = tileName;
        }
    }
}
