using UnityEngine;

[CreateAssetMenu(fileName = "PerspectiveSettings", menuName = "Scriptable Objects/Perspective Settings")]
public class PerspectiveSettingsSO: ScriptableObject
{
    [field: SerializeField] public float IsometricRatio { get; private set; }
}
