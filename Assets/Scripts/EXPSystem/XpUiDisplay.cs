using UnityEngine;

public class XpUiDisplay : MonoBehaviour
{
    [SerializeField] private PlayerExperience xp;
    [SerializeField] private ValueDisplay<float> xpDisplay;

    private void Awake()
    {
        GetComponentInChildren<FloatBarDisplay>().SetMaxValue(xp.xpMax);
    }

    private void Update()
    {
        if (Mathf.Abs(xp.xp - xpDisplay.DisplayValue) > 1e-5)
        {
            xpDisplay.DisplayValue = xp.xp;
        }
    }
}
