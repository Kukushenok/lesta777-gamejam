using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] float _xp;
    [SerializeField] ExpChannelSO _expChannel;

    private void Awake()
    {
        OnDeath.AddListener(delegate { _expChannel.XpAdditionTrigger(_xp); });
    }

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
            Destroy(gameObject);
        }
    }
}
