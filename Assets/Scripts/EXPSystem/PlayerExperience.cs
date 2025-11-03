using UnityEngine;
using UnityEngine.Events;

public class PlayerExperience : MonoBehaviour
{
    [SerializeField] public float xp;
    [SerializeField] public float xpMax;
    UnityAction<float> _xpAddAction;

    private void Awake()
    {
        _xpAddAction = AddXP;
        ExpChannelSO.AddListener(_xpAddAction);
    }

    public void AddXP(float xpValue) 
    {
        xp += xpValue;
        Debug.Log($"Получил опыт: {xp}");
    }
}
