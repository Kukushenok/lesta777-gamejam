using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackerBrain : AttackerBrain
{
    [SerializeField] private InputActionAsset _asset;
    [SerializeField] private Animator _animator;
    private Camera _camera;
    private InputAction _actionAttack;
    //private InputAction _actionShoot;
    private InputAction _actionPoint;

    private void Awake()
    {
        _attacker = GetComponent<Attacker>();
        if (availableAttacks.Count != _attacker.attackCount) throw new Exception("Not enough attack parameters");
        _camera = FindFirstObjectByType<Camera>();
        _actionAttack = _asset.FindAction("Attack");
        _actionPoint = _asset.FindAction("Point");
        //_actionShoot = _asset.FindAction("RightClick");
    } 

    private void Update()
    {
        if (_actionAttack.WasPerformedThisFrame())
        {
            _animator.SetTrigger("isAttacking");
            Attack(0, GetPointInWorld().normalized);
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
