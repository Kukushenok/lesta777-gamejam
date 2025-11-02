using UnityEngine;

public class PlayerHealth : Health
{
    public override void Heal(float hp)
    {
        health += hp;
        health = Mathf.Min(health, maxHealth);
        OnValueChanged?.Invoke(health);
    }

    public override void TakeDamage(float damage)
    {
        //Debug.Log($"получил {damage} пиздов, осталось: {health}");
        health -= damage;
        OnValueChanged?.Invoke(health);
        if (health <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
