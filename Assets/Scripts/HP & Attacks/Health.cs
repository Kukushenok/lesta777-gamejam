using UnityEngine;

public abstract class Health: MonoBehaviour
{
    public abstract float health { get; }

    public abstract bool TakeDamage(float damage);
}
