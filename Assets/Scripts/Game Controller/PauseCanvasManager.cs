using Unity.VisualScripting;
using UnityEngine;

public class PauseCanvasManager : Singleton<PauseCanvasManager>
{
    [SerializeField] private GameObject _settingsWindow;

    public void Pause()
    {
        _settingsWindow.SetActive(true);
    }

    public void Resume()
    {
        _settingsWindow.SetActive(false);
    }
}
