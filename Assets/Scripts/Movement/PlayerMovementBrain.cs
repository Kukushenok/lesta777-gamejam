using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBrain : MovementBrain
{
    [SerializeField] private InputActionAsset _asset;
    private InputAction _moveAction;
    public void Awake()
    {
        _moveAction = _asset.FindAction("Move");
    }
    public override Vector2 GetMoveVector()
    {
        var value = _moveAction.ReadValue<Vector2>();
        return value;
    }
}
