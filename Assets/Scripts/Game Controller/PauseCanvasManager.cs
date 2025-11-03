using Unity.VisualScripting;
using UnityEngine;

public class PauseCanvasManager : Singleton<PauseCanvasManager>
{
    [SerializeField] private BaseUIWindowManager _settingsWindow;
    [SerializeField] private GameObject _toner;
    public void Pause()
    {
        _toner.SetActive(true);
        _settingsWindow.ChangeWindow(1);
    }

    public void Resume()
    {
        _toner.SetActive(false);
        _settingsWindow.ChangeWindow(0);
    }
}
