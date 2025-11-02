using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebuffManager : MonoBehaviour
{

    [SerializeField] private GameObject _debuffButtonPrefab;

    [SerializeField] private Transform _parent;

    //private void Awake()
    //{
    //    _debuffFetcher = _debuffRepositorySO.GetFetcher();
    //}

    public void SetDebuffUI(List<IDebuffDescription> list)
    {
        float y = 0;

        for (int i = 0; i < list.Count; i++)
        {
            var buttonObj = Instantiate(_debuffButtonPrefab, _parent);
            //var rect = buttonObj.GetComponent<RectTransform>();
            //rect.anchoredPosition = new Vector2(0f, y);
            //y += 150f;

            var debuff = list[i];
            var buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = debuff.Name;

            var button = buttonObj.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            int closure = i;
            button.onClick.AddListener(() => { GetDebuffButtonValue(closure); });
        }
    }

    private void GetDebuffButtonValue(int idx)
    {
       
    }
}
