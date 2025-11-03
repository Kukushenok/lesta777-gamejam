using UnityEngine;

public abstract class DebuffSO : ScriptableObject, IDebuff, IDebuffDescription
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; private set; }

    [field: SerializeField] public Sprite Sprite { get; private set; }

    public abstract void ApplyDebuff(GameObject player);
}
