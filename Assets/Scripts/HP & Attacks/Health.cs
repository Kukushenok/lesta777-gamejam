using UnityEngine;
using UnityEngine.Events;

public abstract class Health: MonoBehaviour
{
    
    [SerializeField] protected float maxHealth;
    [SerializeField] public UnityEvent OnDeath;
    [SerializeField] public UnityEvent<float> OnValueChanged;
    [SerializeField] public float health;

    public abstract void TakeDamage(float damage);
    public abstract void Heal(float hp);
}
