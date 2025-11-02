using UnityEngine;
using UnityEngine.Events;

public abstract class Health: MonoBehaviour
{
    
    [SerializeField] public float maxHealth;
    [SerializeField] public UnityEvent OnDeath;
    [SerializeField] public float health;

    public abstract void TakeDamage(float damage);
    public abstract void Heal(float hp);
}
