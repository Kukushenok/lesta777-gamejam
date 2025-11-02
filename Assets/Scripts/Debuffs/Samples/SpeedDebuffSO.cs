using UnityEngine;

[CreateAssetMenu(fileName = "SpeedDebuff", menuName = "Scriptable Objects/Debuffs/Speed Reduce")]
public class SpeedDebuffSO : DebuffSO
{
    [SerializeField] private float modifier;
    public override void ApplyDebuff(GameObject player)
    {
        if(player.TryGetComponent(out ISpeedDebuffable d))
        {
            d.DebuffSpeed(modifier);
        }
        else
        {
            Debug.LogError("ISpeedDebuffable not found in root of object. Please implement this interface on some component to do the trick", player);
        }
    }
}
