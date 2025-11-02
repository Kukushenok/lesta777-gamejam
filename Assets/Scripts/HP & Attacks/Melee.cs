using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Melee : AttackObject
{

    public override void Attack(Vector2 dir, float dmg, float spd, float time)
    {
        Vector3 direction = dir;
        transform.position = parent.transform.position + direction + parent.GetComponent<SpriteRenderer>().bounds.size/2;
        direction = dir;
        damage = dmg;
        speed = spd;
        expirationTime = time;
        StartCoroutine(Move());
    }

    internal override IEnumerator Move()
    {
        while (!timerEnded)
        {
            yield return null;
        }
        Destroy(this.gameObject);
    }

}
