using System.Xml.XPath;
using UnityEngine;
using UnityEngine.Events;

public class ExpChannelSO 
{
    public static UnityEvent<float> _xpAdditionEvent = new UnityEvent<float>();

    public static void AddListener(UnityAction<float> action)
    {
        _xpAdditionEvent.AddListener(action);
    }

    public static void XpAdditionTrigger(float xp)
    {
        _xpAdditionEvent?.Invoke(xp);
    }
}
