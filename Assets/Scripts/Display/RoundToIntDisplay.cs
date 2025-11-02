using UnityEngine;

public class RoundToIntDisplay: ValueDisplay<float>
{
    [SerializeField] private ValueDisplay<int> roundedDisplay;

    public override float DisplayValue { get => roundedDisplay.DisplayValue; set => roundedDisplay.DisplayValue = Mathf.RoundToInt(value); }
}