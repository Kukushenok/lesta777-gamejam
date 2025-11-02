using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attacker : MonoBehaviour
{
    [SerializeField] UnityEvent OnAttack;
    [SerializeField] List<GameObject> attackObjectPrefabs;

    public int attackCount { get =>  attackObjectPrefabs.Count; }

    public void Attack(int attackID, Vector2 direction, float damage, float speed, float time)
    {
        if (attackID + 1 <= attackObjectPrefabs.Count)
        {
            AttackObject attack;
            OnAttack?.Invoke();
            attack = Instantiate(attackObjectPrefabs[attackID], this.transform).GetComponent<AttackObject>();
            attack.Attack(direction, damage, speed, time);
        }
        else throw new Exception("Attack at this ID is not assigned");
    }
}

