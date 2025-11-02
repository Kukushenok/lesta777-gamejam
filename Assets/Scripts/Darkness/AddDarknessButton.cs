using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AddDarknessButton: MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => DarknessManager.Instance.AddDarkness(0.5f));
    }
}