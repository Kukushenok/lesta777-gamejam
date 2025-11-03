using UnityEngine;

[CreateAssetMenu(fileName = "BlockEfficiencyDebuff", menuName = "Scriptable Objects/Debuffs/Block Efficiency Reduce")]
public class BlockEfficiencySO : DebuffSO
{
    [SerializeField] private float _modifier;

    public override void ApplyDebuff(GameObject player)
    {
        if (player.TryGetComponent<IBlockEfficiencyDebuffable>(out var result))
        {
            result.DebuffBlockEfficiency(_modifier);
        }
        else
        {
            Debug.LogError("IBlockEfficiencyDebuffable not found in root of object. Please implement this interface on some component to do the trick", player);
        }
    }
}
