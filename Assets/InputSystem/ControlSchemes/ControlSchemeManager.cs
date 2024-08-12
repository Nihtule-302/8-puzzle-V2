using UnityEngine;

[CreateAssetMenu(menuName = "ControlSchemeManager", fileName = "ControlSchemeManager")]
public class ControlSchemeManager : ScriptableObject
{
    private static ControlSchemeManager _instance;

    [SerializeField] private ControlScheme currentControlScheme;

    private void OnEnable()
    {
        _instance = this;
    }

    public static string GetCurrentControlScheme()
    {
        if (_instance == null)
        {
            Debug.LogError("ControlSchemeManager instance is not assigned.");
            return null;
        }

        return _instance.currentControlScheme.name;
    }
}