using UnityEngine;

[CreateAssetMenu(fileName = "DamageDebuff", menuName = "Scriptable Objects/Debuffs/Damage Reduce")]
public class DamageDebuffSO : DebuffSO
{
    [SerializeField] private float modifier;
    public override void ApplyDebuff(GameObject player)
    {
        if(player.TryGetComponent<IDamageDebuffable>(out var result))
        {
            result.DebuffDamage(modifier);
        }
        else
        {
            Debug.LogError("IDamageDebuffable not found in root of object. Please implement this interface on some component to do the trick", player);
        }
    }
}
