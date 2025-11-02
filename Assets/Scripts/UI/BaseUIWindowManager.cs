using System.Collections;
using UnityEngine;

public class BaseUIWindowManager : MonoBehaviour
{
    [SerializeField] private Animator[] animatedWindows;
    [SerializeField] private float transitionCooldown;
    [SerializeField] private int startIndex = 0;
    private bool transition = false;
    int idx = 0;
    private IEnumerator Start()
    {
        if (startIndex >= 0)
        {
            transition = true;
            TrySetOpen(startIndex, true);
            yield return new WaitForSecondsRealtime(transitionCooldown);
            transition = false;
            idx = startIndex;
        }
    }

    public void ChangeWindow(int index)
    {
        if (transition) return;
        StartCoroutine(DoTransition(index));
    }
    private IEnumerator DoTransition(int toIndex)
    {
        transition = true;
        TrySetOpen(toIndex, true);
        TrySetOpen(idx, false);
        yield return new WaitForSecondsRealtime(transitionCooldown);
        idx = toIndex;
        transition = false;
    }
    private void TrySetOpen(int index, bool value)
    {
        if (animatedWindows[index] == null) return;
        else animatedWindows[index].SetBool("Open", value);
    }
}
