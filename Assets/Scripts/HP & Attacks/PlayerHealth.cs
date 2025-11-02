using UnityEngine;

public class PlayerHealth : Health
{
    public override float health => throw new System.NotImplementedException();

    public override bool TakeDamage(float damage)
    {
        Debug.Log("получил пиздов");
        return false;
    }
}
