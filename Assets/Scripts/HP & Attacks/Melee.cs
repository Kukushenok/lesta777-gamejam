using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Melee : AttackObject
{
    [SerializeField] float maximumAngle;

    public override void Attack(Vector2 dir, float dmg, float spd, float time, Vector3 offset)
    {
        direction = dir;
        var angleOfAttack = Vector3.Angle(new Vector3(1, 0, 0), direction);
        Debug.Log(angleOfAttack);
        Debug.Log(direction);

        if (direction.x > 0) angleOfAttack = Mathf.Min(angleOfAttack, 0+maximumAngle);
        else angleOfAttack = Mathf.Max(angleOfAttack,180-maximumAngle);

        if (direction.y < 0) angleOfAttack *= -1; 

        transform.position = parent.transform.position + new Vector3(direction.x * offset.x, direction.y * offset.y, 0*offset.z);
        transform.Rotate(0,0,angleOfAttack);
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
