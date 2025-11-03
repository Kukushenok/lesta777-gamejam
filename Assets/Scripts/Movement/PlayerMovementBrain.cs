using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBrain : MovementBrain
{
    public bool Freeze { get; set; } = false;
    [SerializeField] private InputActionAsset _asset;
    private InputAction _moveAction;
    public void Awake()
    {
        _moveAction = _asset.FindAction("Move");
    }
    public override Vector2 GetMoveVector()
    {
        if (Freeze) return Vector2.zero;
        var value = _moveAction.ReadValue<Vector2>();
        return value;
    }
}
