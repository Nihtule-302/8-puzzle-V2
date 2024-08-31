using System;
using nPuzzle.Systems.GridSystem;
using UnityEngine;

namespace nPuzzle
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        private static GameSettings _instance;

        public static GameSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<GameSettings>("ScriptableObjects/Settings/GameSettings");
                    if (_instance == null)
                    {
                        Debug.LogError("Failed to load GameSettings. Make sure the asset is in the correct Resources folder.");
                    }
                }
                return _instance;
            }
        }

        [SerializeField] private GridSo defaultGrid;

        private void OnEnable()
        {
            if (defaultGrid == null)
            {
                defaultGrid = Resources.Load<GridSo>("ScriptableObjects/Grids/DefaultGrid");
            }
        }

        public static GridSo GetCurrentGrid()
        {
            if (Instance == null)
            {
                throw new InvalidOperationException("GameSettings instance is not initialized.");
            }
            return Instance.defaultGrid;
        }
    }
}