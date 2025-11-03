using System.Collections;
using UnityEngine;

public class Projectile : AttackObject
{
    public override void Attack(Vector2 dir, float dmg, float spd, float time, Vector3 offset)
    {
        transform.position = parent.transform.position + offset;
        direction = dir;
        damage = dmg;
        speed = spd;
        expirationTime = time;
        StartCoroutine(Move());
    }

    internal override IEnumerator Move()
    {
        Vector3 newPosition = direction.normalized * speed * Time.deltaTime;
        while (!hasHitSomething && !timerEnded)
        {
            yield return transform.position += newPosition;
        }
        AttackExpiration();
    }
}
