using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DebuffStages", menuName = "Scriptable Objects/Debuffs/Debuff Stages")]
public class DebuffStagesSO : ScriptableObject
{
    [SerializeField] private List<DebuffSO> _debuffs;

    public DebuffStages GetDebuffStages() => new DebuffStages(new List<DebuffSO>(_debuffs));
}
