using System.Collections.Generic;
using UnityEngine;

public class DebuffFetcher: IDebuff
{
    private List<DebuffSO> _appliedDebuffs = new();
    private List<DebuffStages> _lastedDebuffs = new();

    public DebuffFetcher(List<DebuffStagesSO> debuffs)
    {
        // is there any better way to do this
        foreach (var x in debuffs)
            _lastedDebuffs.Add(x.GetDebuffStages());
    }

    private DebuffFetcher(List<DebuffStages> lasted, List<DebuffSO> applied)
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
        List<DebuffStages> copy = new(_lastedDebuffs);
        List<DebuffSO> result = new();

        for (int i = 0; i < n && copy.Count > 0; i++)
        {
            int rnd = Random.Range(0, copy.Count);
            var debuffStage = copy[rnd];

            result.Add(debuffStage.GetDebuff());
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

    public DebuffFetcher Clone() => new DebuffFetcher(new List<DebuffStages>(_lastedDebuffs), new List<DebuffSO>(_appliedDebuffs));
}
