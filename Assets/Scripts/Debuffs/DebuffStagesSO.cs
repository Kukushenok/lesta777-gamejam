using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DebuffStages", menuName = "Scriptable Objects/Debuffs/Debuff Stages")]
public class DebuffStagesSO : ScriptableObject
{
    [SerializeField] private List<DebuffSO> _debuffs;

    public DebuffSO GetDebuff() => _debuffs[0];

    public bool RemoveDebuff(DebuffSO debuff) => _debuffs.Remove(debuff);

    public bool IsEmpty() => _debuffs.Count == 0;
}
