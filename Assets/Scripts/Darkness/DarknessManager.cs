using UnityEngine;

public class DarknessManager : MonoBehaviour
{
    [SerializeField] private float _darknessLimit;

    private float _darkness;

    public static DarknessManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

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
