using UnityEngine;

public class PlayerHealthUIDisplay : MonoBehaviour
{
    [SerializeField] private ValueDisplay<float> healthDisplay;
    private Health hp;

    private void Awake()
    {
        hp = FindFirstObjectByType<PlayerHealth>();
    }

    private void Update()
    {
        if (Mathf.Abs(hp.health - healthDisplay.DisplayValue) > 1e-5)
        {
            healthDisplay.DisplayValue = hp.health / hp.maxHealth;
        }
    }
}