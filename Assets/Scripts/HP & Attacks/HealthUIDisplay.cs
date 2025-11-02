using UnityEngine;

public class HealthUIDisplay : MonoBehaviour
{
    [SerializeField] private Health hp;
    [SerializeField] private ValueDisplay<float> healthDisplay;
    private void Update()
    {
        if(Mathf.Abs(hp.health - healthDisplay.DisplayValue) > 1e-5)
        {
            healthDisplay.DisplayValue = hp.health;
        }
    }
}
