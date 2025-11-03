using System.Collections.Generic;

public class DebuffStages
{
    private List<DebuffSO> _debuffs;

    public DebuffStages(List<DebuffSO> debuffs)
    {
        _debuffs = debuffs;
    }

    public DebuffSO GetDebuff() => _debuffs[0];

    public bool RemoveDebuff(DebuffSO debuff) => _debuffs.Remove(debuff);

    public bool IsEmpty() => _debuffs.Count == 0;
}
