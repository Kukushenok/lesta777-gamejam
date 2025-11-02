using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Melee : AttackObject
{

    public override void Attack(Vector2 dir, float dmg, float spd, float time)
    {
        Vector3 direction = dir;
        var angleOfAttack = Vector3.Angle(new Vector3(1, 0, 0), direction);
        SpriteRenderer spriteRenderer = parent.GetComponent<SpriteRenderer>();
        var bounds = spriteRenderer.bounds.size/2f;
        var center = spriteRenderer.bounds.center;
        transform.position = center + new Vector3(direction.x * bounds.x, direction.y * bounds.y, direction.z*bounds.z);
        transform.Rotate(0,0,angleOfAttack);
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
    }

}
