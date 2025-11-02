using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class DisplayDebugger: MonoBehaviour
{
    [SerializeField] private ValueDisplay<float> _floatDisplay;
    private void Awake()
    {
        GetComponent<Slider>().onValueChanged.AddListener((value) => _floatDisplay.DisplayValue = value);
    }
    
}