using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField]float debugHealth;

    private void Awake()
    {
        health = debugHealth;
    }

    public override void Heal(float hp)
    {
        health += hp;
        health = Mathf.Min(health, maxHealth);
    }

    public override void TakeDamage(float damage)
    {
        Debug.Log($"получил {damage} пиздов, осталось: {health}");
        health -= damage;
        if (health <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
