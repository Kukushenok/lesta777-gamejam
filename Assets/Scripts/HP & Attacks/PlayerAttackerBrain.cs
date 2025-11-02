using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackerBrain : AttackerBrain
{
    [SerializeField] private InputActionAsset _asset;
    private InputAction _attackAction;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Attack(0, new Vector2 (1, 0));
        }
    }
}
