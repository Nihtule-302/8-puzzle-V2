using UnityEngine;
using UnityEngine.UI;

namespace nPuzzle.GridSystem
{
    public class TileProperties : MonoBehaviour
    {
        private Image _image;
        [SerializeField] private TileSo tileProperties;

        private Color _cachedColor;
        private Vector3 _cachedTileSize;

        private void Awake()
        {
            _image = GetComponentInChildren<Image>();

            // Initial setup
            ApplyTileProperties();
        }

        private void Update()
        {
            // Update only if properties have changed
            if (_cachedColor != tileProperties.baseColor)
            {
                ApplyTileColor();
            }

            if (_cachedTileSize != tileProperties.TileSize)
            {
                ApplyTileSize();
            }
        }

        private void ApplyTileProperties()
        {
            ApplyTileColor();
            ApplyTileSize();
        }

        private void ApplyTileColor()
        {
            _cachedColor = tileProperties.baseColor;
            _image.color = _cachedColor;
        }

        private void ApplyTileSize()
        {
            _cachedTileSize = tileProperties.TileSize;
            transform.localScale = _cachedTileSize;
        }
    }
}