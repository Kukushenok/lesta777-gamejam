using System.Collections.Generic;
using UnityEngine;

public class CounterObjectsValueDisplay : ValueDisplay<int>
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _prefabTransform;
    private List<ICounterToggleable> objects;
    private int currentCount;
    private void Awake()
    {
        objects = new List<ICounterToggleable>();
    }

    public override int DisplayValue { get => currentCount; set => SetCurrentCount(value); }

    private void Allocate(int count)
    {
        for(int i = 0; i < count; i++)
        {
            var alloc = Instantiate(_prefab, _prefabTransform).GetComponent<ICounterToggleable>();
            objects.Add(alloc);
        }
    }
    private void SetCurrentCount(int val)
    {
        int allocateDelta = val - objects.Count;
        if(allocateDelta > 0)
        {
            Allocate(allocateDelta);
        }
        if(val < currentCount)
        {
            for(int i = 0; i < currentCount - val; i++)
            {
                objects[currentCount - 1 - i].SetActive(false, i);
            }
        } 
        else
        {
            for(int i = 0; i < val - currentCount; i++)
            {
                objects[currentCount + i].SetActive(true, i);
            }
        }
        currentCount = val;
    }
}