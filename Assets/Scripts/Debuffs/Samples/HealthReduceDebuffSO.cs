using UnityEngine;

[CreateAssetMenu(fileName = "HealthReduceDebuff", menuName = "Scriptable Objects/Debuffs/Health Reduce")]
public class HealthReduceDebuffSO : DebuffSO
{
    [SerializeField] private float damage;
    public override void ApplyDebuff(GameObject player)
    {
        // this is shitty af. I guess i'll go this way. 
        player.GetComponent<Health>().TakeDamage(damage);
    }
}
