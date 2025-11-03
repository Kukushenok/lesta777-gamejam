using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] float _xp;

    private void Awake()
    {
        OnDeath.AddListener(delegate { ExpChannelSO.XpAdditionTrigger(_xp); });
    }

    public void SetXp(float xp) => _xp = xp;

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
