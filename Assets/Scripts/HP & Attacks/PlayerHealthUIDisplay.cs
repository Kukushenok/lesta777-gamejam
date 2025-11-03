using UnityEngine;

public class PlayerHealthUIDisplay : MonoBehaviour
{
    [SerializeField] private ValueDisplay<float> healthDisplay;
    [SerializeField] private ValueDisplay<float> maxHealthDisplay;
    private float wasMaxHP;
    private Health hp;

    private void Awake()
    {
        hp = FindFirstObjectByType<PlayerHealth>();
        wasMaxHP = hp.maxHealth;
    }

    private void Update()
    {
        if (Mathf.Abs(hp.health - healthDisplay.DisplayValue) > 1e-5)
        {
            healthDisplay.DisplayValue = hp.health / wasMaxHP;
        } 
        if(Mathf.Abs(hp.maxHealth - healthDisplay.DisplayValue) > 1e-5)
        {
            maxHealthDisplay.DisplayValue = hp.maxHealth / wasMaxHP;
        }
    }
}