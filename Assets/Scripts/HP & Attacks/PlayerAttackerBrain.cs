using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackerBrain : AttackerBrain
{
    [field: SerializeField] public float AttackCooldown { get; set; }
    [SerializeField] private InputActionAsset _asset;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerShieldBehaviour shieldBehaviour;
    private Camera _camera;
    private InputAction _actionAttack;
    //private InputAction _actionShoot;
    private InputAction _actionPoint;
    private InputAction _blockAttack;
    private void Awake()
    {
        _attacker = GetComponent<Attacker>();
        if (availableAttacks.Count != _attacker.attackCount) throw new Exception("Not enough attack parameters");
        _camera = FindFirstObjectByType<Camera>();
        _actionAttack = _asset.FindAction("Attack");
        _actionPoint = _asset.FindAction("Point");
        _blockAttack = _asset.FindAction("Block");
        //_actionShoot = _asset.FindAction("RightClick");
    } 

    private IEnumerator Start()
    {
        while (true)
        {
            if(!GameController.IsGameplay)
            {
                yield return new WaitForEndOfFrame();
                continue;
            }
            if (_actionAttack.WasPerformedThisFrame())
            {
                _animator.SetTrigger("isAttacking");
                Attack(0, GetPointInWorld().normalized);
                yield return new WaitForSeconds(AttackCooldown);
            }
            // it is here because you can't attack and block the same time.
            else if (_blockAttack.WasPerformedThisFrame()) 
            {
                yield return shieldBehaviour.ApplyShield();
            }
            yield return new WaitForEndOfFrame();
        }
        //if (_actionShoot.WasPerformedThisFrame())
        //{
        //    Attack(1, GetPointInWorld().normalized);
        //}
    }

    private Vector3 GetPointInWorld()
    {
        var pointerPos = _actionPoint.ReadValue<Vector2>();
        Vector3 cameraDistance = transform.position - _camera.transform.position;
        Vector3 screenPoint = new Vector3(pointerPos.x, pointerPos.y, cameraDistance.z);
        var clickDirection = _camera.ScreenToWorldPoint(screenPoint) - transform.position;
        return clickDirection;
    }
}
