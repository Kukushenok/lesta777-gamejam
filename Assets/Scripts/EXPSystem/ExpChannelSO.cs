using System.Xml.XPath;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ExpChannelSO", menuName = "Scriptable Objects/ExpChannelSO")]
public class ExpChannelSO : ScriptableObject
{
    private UnityEvent<float> _xpAdditionEvent;

    public void AddListener(UnityAction<float> action)
    {
        _xpAdditionEvent.AddListener(action);
    }

    public void XpAdditionTrigger(float xp)
    {
        _xpAdditionEvent?.Invoke(xp);
    }
}
