using UnityEngine;

public class DarknessManager : Singleton<DarknessManager>
{
    public float Darkness
    {
        get => _darkness;
    }
    public float DarknessRatio
    {
        get => Mathf.Repeat(_darkness, _darknessLevel) / _darknessLevel;
    }

    [SerializeField] private float _darknessLevel;
    private float lastDarknessSaved;
    float _darkness;


    private void DarknessLimit()
    {
        GameController.Instance.DarknessConsumed();
    }
    public void SaveDarkness()
    {
        lastDarknessSaved = _darkness;
    }
    public void AddDarkness(float value)
    {
        int currLevel = (int)(_darkness / _darknessLevel) + 1;
        _darkness += value;
        if (_darkness >= currLevel * _darknessLevel)
            DarknessLimit();
    }
    public void ResetDarkness(bool hardReset = false)
    {
        _darkness = hardReset ? 0 : lastDarknessSaved;
        lastDarknessSaved = _darkness;
    }
}
