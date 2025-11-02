using UnityEngine;

public abstract class ValueDisplay<T>: MonoBehaviour
{
    public abstract T DisplayValue { get; set; }
}
