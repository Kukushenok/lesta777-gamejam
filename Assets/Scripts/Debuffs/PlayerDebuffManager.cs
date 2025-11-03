using UnityEngine;

public class PlayerDebuffManager : MonoBehaviour, IDamageDebuffable, IAttackSpeedDebuffable
{
    [SerializeField] private PlayerAttackerBrain attaker;

    public void DebuffAttackSpeed(float modifier)
    {
        attaker.AttackCooldown *= (1 + modifier);
    }

    public void DebuffDamage(float modifier)
    {
        attaker.AttackDamageModifier *= (1 - modifier);
    }

    private void Start()
    {
        GameController.Instance.SpawnDebuff.ApplyDebuff(gameObject);
    }
}
