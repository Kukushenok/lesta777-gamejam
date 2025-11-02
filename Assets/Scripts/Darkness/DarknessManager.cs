using UnityEngine;

public class DarknessManager : Singleton<DarknessManager>
{
    [SerializeField] private float _darknessLimit;
    float _darkness;
    public float Darkness
    {
        get => _darkness;
        set
        {
            _darkness = value;
            if (_darkness >= _darknessLimit)
                DarknessLimit();
        }
    }

    private void DarknessLimit()
    {
        GameController.Instance.DarknessConsumed();
        _darkness = 0;
    }
}
