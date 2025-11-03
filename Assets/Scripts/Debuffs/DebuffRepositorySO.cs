using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DebuffSO", menuName = "Scriptable Objects/Debuffs/Repository")]
public class DebuffRepositorySO: ScriptableObject
{
    [SerializeField] private List<DebuffStagesSO> _debuffs;

    public DebuffFetcher GetFetcher() => new DebuffFetcher(new List<DebuffStagesSO>(_debuffs));
}