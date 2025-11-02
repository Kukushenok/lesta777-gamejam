using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BasicCounterToggleable : MonoBehaviour, ICounterToggleable
{
    private Coroutine currentCoroutine;
    [SerializeField] private float indexSetDelay = 0.3f;
    [SerializeField] private float initDelay = 0.1f;
    private Image img;
    private void Awake()
    {
        img = GetComponent<Image>();
        img.color = Color.black;
    }
    public void SetActive(bool value, int delayIndex)
    {
        if(currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            currentCoroutine = null;
        }
        StartCoroutine(WaitAndSet(value, initDelay + delayIndex * indexSetDelay));
    }
    private IEnumerator WaitAndSet(bool value, float time)
    {
        yield return new WaitForSeconds(time);
        currentCoroutine = null;
        img.color = value ? Color.red : Color.black;
    }
}