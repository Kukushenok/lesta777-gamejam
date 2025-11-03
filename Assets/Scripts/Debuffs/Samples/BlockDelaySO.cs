using UnityEngine;

[CreateAssetMenu(fileName = "BlockDelayDebuff", menuName = "Scriptable Objects/Debuffs/Block Delay Reduce")]
public class BlockDelaySO : DebuffSO
{
    [SerializeField] private float _modifier;

    public override void ApplyDebuff(GameObject player)
    {
        if (player.TryGetComponent<IBlockDelayDebuffable>(out var result))
        {
            result.DebuffBlockDelay(_modifier);
        }
        else
        {
            Debug.LogError("IBlockDelayDebuffable not found in root of object. Please implement this interface on some component to do the trick", player);
        }
    }
}
