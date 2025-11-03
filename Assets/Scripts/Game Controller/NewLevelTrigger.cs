using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class NewLevelTrigger : MonoBehaviour
{
    [SerializeField] EnemyManager _enemyManager;
    [SerializeField] private UnityEvent OnCanAdvance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_enemyManager.allEnemiesDead)
        {
            GameController.Instance.Advance();
        }
    }
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => _enemyManager.allEnemiesDead);
        yield return new WaitForSeconds(1);
        OnCanAdvance?.Invoke();
    }
}
