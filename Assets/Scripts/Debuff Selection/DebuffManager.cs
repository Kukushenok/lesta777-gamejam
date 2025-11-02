using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DebuffManager : MonoBehaviour
{

    [SerializeField] private GameObject _debuffButtonPrefab;

    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject windowParent;
    [SerializeField] private float destroyTime;
    [SerializeField] private UnityEvent OnDebuffSelected;
    private bool destroying = false;

    //private void Awake()
    //{
    //    _debuffFetcher = _debuffRepositorySO.GetFetcher();
    //}

    public void SetDebuffUI(List<IDebuffDescription> list)
    {
        windowParent.SetActive(true);
        for (int i = 0; i < list.Count; i++)
        {
            var buttonObj = Instantiate(_debuffButtonPrefab, _parent);
            //var rect = buttonObj.GetComponent<RectTransform>();
            //rect.anchoredPosition = new Vector2(0f, y);
            //y += 150f;
            buttonObj.SetActive(true);
            var debuff = list[i];
            var buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            var img = buttonObj.GetComponentInChildren<Image>();
            img.sprite = list[i].Sprite;
            buttonText.text = debuff.Name;

            var button = buttonObj.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            int closure = i;
            button.onClick.AddListener(() => { SetDebuffButtonValue(closure); });
        }
    }

    private void SetDebuffButtonValue(int idx)
    {
        if (destroying) return;
        destroying = true;
        StartCoroutine(WaitAndQuit(idx));
    }
    private IEnumerator WaitAndQuit(int idx)
    {
        yield return new WaitForSecondsRealtime(destroyTime);
        GameController.Instance.ApplyPerk(idx);
        destroying = false;
    }
}
