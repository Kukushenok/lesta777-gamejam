using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyAttackerBrain : AttackerBrain
{
    [SerializeField] float timeDelay;
    public bool isEnabled;
    bool timerEnded;
    float expirationTime;
    int _id;
    Vector2 _direction;

    public void Disable()
    {
        isEnabled = false;
        StopCoroutine(AutoAttack());
    }

    public void Enable(int id, Vector2 direction)
    {
        isEnabled = true;
        expirationTime = 0;
        _id = id;
        _direction = direction;
        StartCoroutine(AutoAttack());
    }

    public void UpdateDirection(Vector2 direction) => _direction = direction;

    void ResetTimer() => expirationTime = timeDelay;

    void Update()
    {
        expirationTime -= Time.deltaTime;

        if (expirationTime <= 0.0f)
        {
            timerEnded = true;
        }

    }

    private IEnumerator AutoAttack()
    {
        while (isEnabled)
        {
            if (timerEnded)
            {
                Attack(_id, _direction);
                timerEnded = false;
                ResetTimer();
                yield return null;
            }
            yield return null;
        }
    }
}
