using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DebuffManager : MonoBehaviour
{

    [SerializeField] private GameObject _debuffButtonPrefab;

    [SerializeField] private Transform _parent;
    [SerializeField] private GameplayCanvas _canvas;
    [SerializeField] private float destroyTime;
    private List<GameObject> choices = new List<GameObject>();
    private bool destroying = false;

    //private void Awake()
    //{
    //    _debuffFetcher = _debuffRepositorySO.GetFetcher();
    //}

    public void SetDebuffUI(List<IDebuffDescription> list)
    {
        foreach (var x in choices) Destroy(x);
        choices.Clear();
        _canvas.PickDebuff();
        for (int i = 0; i < list.Count; i++)
        {
            var buttonObj = Instantiate(_debuffButtonPrefab, _parent);
            //var rect = buttonObj.GetComponent<RectTransform>();
            //rect.anchoredPosition = new Vector2(0f, y);
            //y += 150f;
            buttonObj.SetActive(true);
            var debuff = list[i];
            var buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            // This is unbeliveably hacky PLEASE DO SOMETHING
            var img = buttonObj.transform.GetChild(0).GetComponent<Image>();
            img.sprite = list[i].Sprite;
            buttonText.text = debuff.Name;

            var button = buttonObj.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            int closure = i;
            button.onClick.AddListener(() => { SetDebuffButtonValue(closure); });
            choices.Add(buttonObj);
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
        _canvas.ShowGameplay();
        yield return new WaitForSecondsRealtime(destroyTime);
        GameController.Instance.ApplyPerk(idx);
        destroying = false;
    }
}
