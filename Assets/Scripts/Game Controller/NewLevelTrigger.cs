using UnityEngine;

public class NewLevelTrigger : MonoBehaviour
{
    [SerializeField] EnemyManager _enemyManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_enemyManager.allEnemiesDead)
        {
            GameController.Instance.Advance();
        }
    }
}
