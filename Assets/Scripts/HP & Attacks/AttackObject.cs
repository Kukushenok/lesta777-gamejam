using System.Collections;
using UnityEngine;

public abstract class AttackObject : MonoBehaviour
{
    internal Vector2 direction;
    internal GameObject parent;
    internal float damage;
    internal float speed;
    internal bool hasHitSomething;

    private void Awake()
    {
        parent = this.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject != parent)
        {
            gameObject.GetComponent<Health>().TakeDamage(damage);
            hasHitSomething = true;
        }
    }

    public abstract void Attack(Vector2 direction, float damage, float speed);

    internal abstract IEnumerator Move();
}
