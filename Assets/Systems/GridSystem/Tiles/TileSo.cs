using UnityEngine;
using UnityEngine.Serialization;

namespace nPuzzle.Systems.GridSystem
{
    [CreateAssetMenu(menuName = "TileInfo")]
    public class TileSo : ScriptableObject
    {

        [Header("Tile Properties")]
        public GameObject tilePrefab;
        public Color baseColor;
        public Color highlightColor = Color.red;
        
        [Range(0.3f, 1f)]
        [SerializeField] private float tileSize = 0.5f;
        public Vector3 TileSize => new(tileSize, tileSize, tileSize);
        
        public string emptyTileString = string.Empty;
        
        
        [Header("Font Properties")]
        public float fontSize;
        public Color fontColor = Color.white;
        public Color highlightFontColor;
    }
}


