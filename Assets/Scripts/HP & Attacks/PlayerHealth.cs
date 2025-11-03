using UnityEngine;

public class PlayerHealth : Health
{
    public override void Heal(float hp)
    {
        health += hp;
        health = Mathf.Min(health, maxHealth);
    }

    public override void TakeDamage(float damage)
    {
        // предотвратить смерть в паузе/выборе чего то/т.п.
        if (GameController.Instance != null && GameController.Instance.State != GameState.Gameplay) return;
        //Debug.Log($"получил {damage} пиздов, осталось: {health}");
        health -= damage;
        if (health <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
