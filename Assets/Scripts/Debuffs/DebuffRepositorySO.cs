using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DebuffSO", menuName = "Scriptable Objects/Debuffs/Repository")]
public class DebuffRepositorySO: ScriptableObject
{
    [SerializeField] private List<DebuffSO> debuffs;
    public DebuffFetcher GetFetcher() => new DebuffFetcher(debuffs);
}