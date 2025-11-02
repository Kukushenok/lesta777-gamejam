using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackerBrain : AttackerBrain
{
    [SerializeField] private InputActionAsset _asset;
    [SerializeField] private Camera _camera;

    private void Update()
    {
        if (_asset.FindAction("Attack").WasPerformedThisFrame())
        {
            var pointerPos = _asset.FindAction("Point").ReadValue<Vector2>();
            Vector3 cameraDistance = transform.position - _camera.transform.position;
            Vector3 screenPoint = new Vector3(pointerPos.x, pointerPos.y, cameraDistance.z);
            var clickDirection = _camera.ScreenToWorldPoint(screenPoint) - transform.position;
            Attack(0, clickDirection.normalized);
        }
    }
}
