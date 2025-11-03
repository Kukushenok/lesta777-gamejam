using System.Collections.Generic;
using UnityEngine;

public class DebuffFetcher: IDebuff
{
    private List<DebuffStagesSO> _lastedDebuffs = new List<DebuffStagesSO>();
    private List<DebuffSO> _appliedDebuffs = new List<DebuffSO>();

    public DebuffFetcher(List<DebuffStagesSO> debuffs)
    {
        _lastedDebuffs = debuffs;
    }

    private DebuffFetcher(List<DebuffStagesSO> lasted, List<DebuffSO> applied)
    {
        _lastedDebuffs = lasted;
        _appliedDebuffs = applied;
    }

    public void ApplyDebuff(GameObject player)
    {
        foreach (var x in _appliedDebuffs)
        {
            x.ApplyDebuff(player);
        }
    }

    public List<DebuffSO> GetDebuffs(int n = 3)
    {
        List<DebuffStagesSO> copy = new List<DebuffStagesSO>(_lastedDebuffs);
        List<DebuffSO> result = new List<DebuffSO>();

        for (int i = 0; i < n && copy.Count > 0; i++)
        {
            int rnd = Random.Range(0, copy.Count);
            result.Add(copy[rnd].GetDebuff());
            copy.RemoveAt(rnd);
        }

        return result;
    }

    public void OnDebuffSelected(DebuffSO debuff)
    {
        foreach (var x in _lastedDebuffs)
        {
            if (x.RemoveDebuff(debuff))
            {
                _appliedDebuffs.Add(debuff);
                if (x.IsEmpty()) _lastedDebuffs.Remove(x);
                return;
            }
        }

        throw new System.Exception("No such debuff");
    }

    public DebuffFetcher Clone() => new DebuffFetcher(new List<DebuffStagesSO>(_lastedDebuffs), new List<DebuffSO>(_appliedDebuffs));
}
