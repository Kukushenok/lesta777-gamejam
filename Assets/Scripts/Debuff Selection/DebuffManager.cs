using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
            var buttonObj = Instantiate(_debuffButtonPrefab, _canvas);
            var rect = buttonObj.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(0f, y);
            y += 150f;

            var debuff = list[i];
            var buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = debuff.Name;

            var button = buttonObj.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => { GetDebuffButtonValue(debuff); });
        }
    }

    private void GetDebuffButtonValue(DebuffSO debuff)
    {
        Debug.Log(debuff.Name);
    }
}
