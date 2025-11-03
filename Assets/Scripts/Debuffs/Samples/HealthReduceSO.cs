using UnityEngine;

[CreateAssetMenu(fileName = "HealthReduceDebuff", menuName = "Scriptable Objects/Debuffs/Health Reduce")]
public class HealthReduceSO : DebuffSO
{
    [SerializeField] private float damage;
    public override void ApplyDebuff(GameObject player)
    {
        // this is shitty af. I guess i'll go this way. 
        player.GetComponent<Health>().maxHealth-=damage;
    }
}
