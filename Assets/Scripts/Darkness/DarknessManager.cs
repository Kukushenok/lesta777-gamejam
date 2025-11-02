using UnityEngine;

public class DarknessManager : MonoBehaviour
{
    [SerializeField]
    private float _darknessLimit;

    private float _darkness;

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
        Debug.Log("darkness reached limit");
    }
}
