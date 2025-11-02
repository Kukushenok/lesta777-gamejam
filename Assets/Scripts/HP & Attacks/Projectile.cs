using System.Collections;
using UnityEngine;

public class Projectile : AttackObject
{
    public override void Attack(Vector2 dir, float dmg, float spd, float time)
    {
        transform.position = parent.transform.position;
        direction = dir;
        damage = dmg;
        speed = spd;
        expirationTime = time;
        StartCoroutine(Move());
    }

    internal override IEnumerator Move()
    {
        Vector3 newPosition = direction * speed * Time.deltaTime;
        while (!hasHitSomething && !timerEnded)
        {
            yield return transform.position += newPosition;
        }
        Destroy(this.gameObject);
    }
}
