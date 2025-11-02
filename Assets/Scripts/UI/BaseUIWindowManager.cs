using System.Collections;
using UnityEngine;

public class BaseUIWindowManager : MonoBehaviour
{
    [SerializeField] private Animator[] animatedWindows;
    [SerializeField] private float transitionCooldown;
    private bool transition = false;
    int idx = 0;
    private IEnumerator Start()
    {
        transition = true;
        animatedWindows[idx].SetBool("Open", true);
        yield return new WaitForSecondsRealtime(transitionCooldown);
        transition = false;
    }
    public void ChangeWindow(int index)
    {
        if (transition) return;
        StartCoroutine(DoTransition(index));
    }
    private IEnumerator DoTransition(int toIndex)
    {
        transition = true;
        animatedWindows[toIndex].SetBool("Open", true);
        animatedWindows[idx].SetBool("Open", false);
        yield return new WaitForSecondsRealtime(transitionCooldown);
        idx = toIndex;
        transition = false;
    }
}
