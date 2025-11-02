using UnityEngine;

public class EnemyHealth : Health
{
    public override void Heal(float hp)
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
