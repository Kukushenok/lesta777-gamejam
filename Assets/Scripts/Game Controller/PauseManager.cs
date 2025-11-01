using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsButton;

    [SerializeField] private GameObject _settingsWindow;

    public void Pause()
    {
        Time.timeScale = 0f;

        _settingsButton.SetActive(false);
        _settingsWindow.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;

        _settingsButton.SetActive(true);
        _settingsWindow.SetActive(false);
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
    }
}
