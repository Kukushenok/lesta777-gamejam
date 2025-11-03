using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameControllerEventButton : MonoBehaviour
{
    private enum EventType { Pause, Resume, ToMenu, ToGameplay, Quit }
    [SerializeField] private EventType buttonType;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    public void OnButtonClicked()
    {
        switch (buttonType)
        {
            case EventType.Pause:
                GameController.Instance.DoPause();
                break;
            case EventType.Resume:
                GameController.Instance.Resume();
                break;
            case EventType.ToMenu:
                GameController.Instance.ToMenu();
                break;
            case EventType.ToGameplay:
                GameController.Instance.ToGameplay();
                break;
            case EventType.Quit:
                GameController.Instance.Quit();
                break;
            default:
                Debug.LogWarning($"Unknown button type: {buttonType}");
                break;
        }
    }

    private void OnDestroy()
    {
        // Clean up the listener
        if (button != null)
            button.onClick.RemoveListener(OnButtonClicked);
    }
}