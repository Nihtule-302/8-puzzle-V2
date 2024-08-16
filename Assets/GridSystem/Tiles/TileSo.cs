using UnityEngine;

namespace nPuzzle.GridSystem
{
    [CreateAssetMenu(menuName = "TileInfo")]
    public class TileSo : ScriptableObject
    {

        [Header("Tile Properties")]
        public Color baseColor;
        public Color highlightColor = Color.red;
        
        [Range(0.3f, 1f)]
        [SerializeField] private float tileSize = 0.5f;
        public Vector3 TileSize => new(tileSize, tileSize, tileSize);
        
        
        [Header("Font Properties")]
        public float fontSize;
        public Color fontColor = Color.white;
        public Color highlightFontColor;
        
    }
}


