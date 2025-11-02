using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class AttackObject : MonoBehaviour
{
    [SerializeField] UnityEvent OnAttackExpired;
    protected Vector2 direction;
    protected GameObject parent;
    protected float damage;
    protected float speed;
    protected float expirationTime;
    protected bool timerEnded = false;
    protected bool hasHitSomething;

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
            AttackExpiration();
        }

    }

    protected void AttackExpiration()
    {
        OnAttackExpired?.Invoke();
        StopCoroutine(Move());
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;

        if (parent.tag!=gameObject.tag)
        {
            gameObject.GetComponent<Health>().TakeDamage(damage);
            hasHitSomething = true;
        }
    }

    public abstract void Attack(Vector2 direction, float damage, float speed, float time);

    internal abstract IEnumerator Move();
}
