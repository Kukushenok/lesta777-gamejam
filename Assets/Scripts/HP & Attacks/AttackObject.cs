using System.Collections;
using UnityEngine;

public abstract class AttackObject : MonoBehaviour
{
    internal Vector2 direction;
    internal GameObject parent;
    internal float damage;
    internal float speed;
    internal float expirationTime;
    internal bool timerEnded = false;
    internal bool hasHitSomething;

    private void Awake()
    {
        parent = this.transform.parent.gameObject;
    }

    void Update()
    {

        expirationTime -= Time.deltaTime;

        if (expirationTime <= 0.0f)
        {
            timerEnded = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject != parent)
        {
            gameObject.GetComponent<Health>().TakeDamage(damage);
            hasHitSomething = true;
        }
    }

    public abstract void Attack(Vector2 direction, float damage, float speed, float time);

    internal abstract IEnumerator Move();
}
