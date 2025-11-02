using System.Collections.Generic;
using UnityEngine;

public class DebuffFetcher: IDebuff
{
    private List<DebuffSO> _lastedDebuffs = new List<DebuffSO>();
    private List<DebuffSO> _appliedDebuffs = new List<DebuffSO>();
    public DebuffFetcher(List<DebuffSO> debuffs)
    {
        _lastedDebuffs = debuffs;
    } 
    private DebuffFetcher(List<DebuffSO> lasted, List<DebuffSO> applied)
    {
        _lastedDebuffs = lasted;
        _appliedDebuffs = applied;
    }
    public void ApplyDebuff(GameObject player)
    {
        foreach(var x  in _appliedDebuffs)
        {
            x.ApplyDebuff(player);
        }
    }
    public List<DebuffSO> GetDebuffs(int n = 3)
    {
        List<DebuffSO> copy = new List<DebuffSO>(_lastedDebuffs);
        List<DebuffSO> result = new List<DebuffSO>();
        for(int i = 0; i < n && copy.Count > 0; i++)
        {
            int rnd = Random.Range(0, copy.Count);
            result.Add(copy[rnd]);
            copy.RemoveAt(rnd);
        }
        return result;
    }
    public void OnDebuffSelected(DebuffSO debuff)
    {
        _lastedDebuffs.Remove(debuff); // todo maybe check if it is not in _lastedDebuffs
        _appliedDebuffs.Add(debuff);
    }
    public DebuffFetcher Clone() => new DebuffFetcher(new List<DebuffSO>(_lastedDebuffs), new List<DebuffSO>(_appliedDebuffs));
}
