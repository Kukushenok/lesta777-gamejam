using UnityEngine;

[CreateAssetMenu(fileName = "AttackSpeedDebuff", menuName = "Scriptable Objects/Debuffs/Attack Speed Reduce")]
public class AttackSpeedSO : DebuffSO
{
    [SerializeField] private float _modifier;

    public override void ApplyDebuff(GameObject player)
    {
        if (player.TryGetComponent<IAttackSpeedDebuffable>(out var result))
        {
            result.DebuffAttackSpeed(_modifier);
        }
        else
        {
            Debug.LogError("IAttackSpeedDebuffable not found in root of object. Please implement this interface on some component to do the trick", player);
        }
    }
}
