using UnityEngine;
using UnityEngine.UI;

public class AddDarknessOnDestroy: MonoBehaviour
{
    [SerializeField] private float _addDarkness;
    private void OnDestroy()
    {
        DarknessManager.Instance.Darkness += _addDarkness;
    }
}
[RequireComponent(typeof(Button))]
public class AddDarknessButton: MonoBehaviour
{
    private Button btn;
    private void Awake()
    {
        btn.onClick.AddListener(() => DarknessManager.Instance.Darkness += 0.5f);
    }
}