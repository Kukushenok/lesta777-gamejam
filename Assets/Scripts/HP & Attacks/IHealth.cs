using UnityEngine;

public interface IHealth
{
    float health { get; }

    bool TakeDamage(float damage);
}
