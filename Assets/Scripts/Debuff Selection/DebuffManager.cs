using TMPro;
using UnityEngine;

public class DebuffManager : MonoBehaviour
{
    [SerializeField] private DebuffRepositorySO _debuffRepositorySO;

    [SerializeField] private GameObject _debuffButtonPrefab;

    [SerializeField] private Transform _canvas;

    private DebuffFetcher _debuffFetcher;

    private void Awake()
    {
        _debuffFetcher = _debuffRepositorySO.GetFetcher();
    }

    public void SetDebuffUI()
    {
        var list = _debuffFetcher.GetDebuffs();
        float y = 0;

        for (int i = 0; i < list.Count; i++)
        {
            var button = Instantiate(_debuffButtonPrefab, _canvas);
            var rect = button.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(0f, y);
            y += 150f;

            var buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = list[i].Name;
        }
    }
}
