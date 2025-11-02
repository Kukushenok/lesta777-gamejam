using UnityEngine;

public class DarknessMeterScript : MonoBehaviour
{
    [SerializeField] private ValueDisplay<float> darknessValue;
    private void Update()
    {
        if (DarknessManager.Instance == null) enabled = false;
        darknessValue.DisplayValue = DarknessManager.Instance.DarknessRatio;
    }
}
