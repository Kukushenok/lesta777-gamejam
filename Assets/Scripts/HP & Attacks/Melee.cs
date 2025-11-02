using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Melee : AttackObject
{
    float targetTime = 0.5f;
    bool timerEnded = false;

    public override void Attack(Vector2 dir, float dmg, float spd)
    {
        Vector3 direction = dir;
        transform.position = parent.transform.position + direction + parent.GetComponent<SpriteRenderer>().bounds.size/2;
        direction = dir;
        damage = dmg;
        speed = spd;
        StartCoroutine(Move());
    }

    void Update()
    {

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded = true;
        }

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
