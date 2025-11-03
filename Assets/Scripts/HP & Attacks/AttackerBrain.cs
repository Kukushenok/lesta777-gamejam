using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

[RequireComponent(typeof(Attacker))]
public abstract class AttackerBrain : MonoBehaviour
{
    [SerializeField] protected List<AttackParameters> availableAttacks;
    [SerializeField] protected Vector2 offset;
    protected Attacker _attacker;

    private void Awake()
    {
        _attacker = GetComponent<Attacker>();
        if (availableAttacks.Count != _attacker.attackCount) throw new Exception("Not enough attack parameters");
    }
    public void Attack(int id, Vector2 direction)
    {
        AttackParameters parameters = availableAttacks.Find(attack => attack.id == id);
        _attacker.Attack(id, direction, parameters.damage, parameters.speed, parameters.expirationTime, offset);
    }
}

[Serializable]
public struct AttackParameters
{
    public int id;
    public float damage;
    public float speed;
    public float expirationTime;
}