using UnityEngine;
using UnityEngine.Events;

public abstract class Health: MonoBehaviour
{
    [SerializeField] protected UnityEvent OnDeath;
    [SerializeField] protected float maxHealth;
    protected float _health;

    public float health
    {
        get => _health;
        protected set => _health = value;
    }

    public abstract void TakeDamage(float damage);
    public abstract void Heal(float hp);
}
