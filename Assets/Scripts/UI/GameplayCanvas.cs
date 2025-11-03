using UnityEngine;

public class GameplayCanvas : MonoBehaviour
{
    [SerializeField] private BaseUIWindowManager windowManager;
    [SerializeField] private int _gamplayIndex = 0;
    [SerializeField] private int _debuffPickIndex = 1;
    [SerializeField] private int _deathIndex = 2;
    [SerializeField] private int _hide = 3;
    public void ShowDeath()
    {
        windowManager.ChangeWindow(_deathIndex);
    }
    public void ShowGameplay()
    {
        windowManager.ChangeWindow(_gamplayIndex);
    }
    public void PickDebuff()
    {
        windowManager.ChangeWindow(_debuffPickIndex);
    }
}
