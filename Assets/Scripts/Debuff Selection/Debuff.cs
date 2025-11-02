using UnityEngine;

[CreateAssetMenu(fileName = "Debuff", menuName = "Scriptable Objects/Debuffs/Debuff")]
public class Debuff : DebuffSO
{
    public override void ApplyDebuff(GameObject player)
    {
        Debug.Log($"Apply {Name}");
    }
}
