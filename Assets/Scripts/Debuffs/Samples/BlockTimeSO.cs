using UnityEngine;

[CreateAssetMenu(fileName = "BlockTimeDebuff", menuName = "Scriptable Objects/Debuffs/Block Time Reduce")]
public class BlockTimeSO : DebuffSO
{
    [SerializeField] private float _modifier;

    public override void ApplyDebuff(GameObject player)
    {
        if (player.TryGetComponent<IBlockTimeDebuffable>(out var result))
        {
            result.DebuffBlockTime(_modifier);
        }
        else
        {
            Debug.LogError("IBlockTimeDebuffable not found in root of object. Please implement this interface on some component to do the trick", player);
        }
    }
}
