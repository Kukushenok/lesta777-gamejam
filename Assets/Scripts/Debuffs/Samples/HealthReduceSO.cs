using UnityEngine;

[CreateAssetMenu(fileName = "HealthReduceDebuff", menuName = "Scriptable Objects/Debuffs/Health Reduce")]
public class HealthReduceSO : DebuffSO
{
    [SerializeField] private float modifier;
    public override void ApplyDebuff(GameObject player)
    {
        // this is shitty af. I guess i'll go this way. 
        var x = player.GetComponent<Health>();
        x.maxHealth *= (1 - modifier);
        x.health = Mathf.Clamp(x.health, 0, x.maxHealth);
    }
}
