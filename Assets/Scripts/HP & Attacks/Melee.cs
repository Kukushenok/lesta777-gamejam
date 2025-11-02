using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Melee : AttackObject
{
    [SerializeField] float maximumAngle;

    public override void Attack(Vector2 dir, float dmg, float spd, float time)
    {
        direction = dir;
        var angleOfAttack = Vector3.Angle(new Vector3(1, 0, 0), direction);
        Debug.Log(angleOfAttack);
        Debug.Log(direction);

        if (direction.x > 0) angleOfAttack = Mathf.Min(angleOfAttack, 0+maximumAngle);
        else angleOfAttack = Mathf.Max(angleOfAttack,180-maximumAngle);

        if (direction.y < 0) angleOfAttack *= -1; 

        SpriteRenderer spriteRenderer = parent.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = parent.GetComponentInChildren<SpriteRenderer>();
        }
        var bounds = spriteRenderer.bounds.size/2f;
        var center = spriteRenderer.bounds.center;

        transform.position = center + new Vector3(direction.x * bounds.x, direction.y * bounds.y, 0*bounds.z);
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
