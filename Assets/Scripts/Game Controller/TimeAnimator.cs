using System.Collections;
using UnityEngine;

public class TimeAnimator
{
    private float _targetTimeScale;
    private float speed;
    private float dt;
    public TimeAnimator(float targetTimeScale)
    {
        _targetTimeScale = targetTimeScale;
    }
    public void SetTime(float timeScale, float inTime)
    {
        _targetTimeScale = timeScale;
        dt = inTime;
    }
    public IEnumerator Cycle()
    {
        while (true)
        {
            Time.timeScale = Mathf.SmoothDamp(Time.timeScale, _targetTimeScale, ref speed, dt, float.MaxValue, Time.unscaledDeltaTime);
            yield return null;
        }
    }
}
