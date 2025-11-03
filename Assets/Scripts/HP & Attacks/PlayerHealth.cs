using UnityEngine;

public class PlayerHealth : Health
{
    [HideInInspector] public float DamageModifier = 1;
    private void Awake()
    {
        OnDeath.AddListener(GameController.Instance.GameOver);
    }
    public override void Heal(float hp)
    {
        health += hp;
        health = Mathf.Min(health, maxHealth);
    }

    public override void TakeDamage(float damage)
    {
        //Debug.Log($"получил {damage} пиздов, осталось: {health}");
        health -= damage * DamageModifier;
        if (health <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
