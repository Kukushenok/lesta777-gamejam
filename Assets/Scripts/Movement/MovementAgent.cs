using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class MovementAgent : MonoBehaviour
{
    [SerializeField] private MovementBrain _movementBrain;
    [SerializeField] private PerspectiveSettingsSO _perspectiveSettings;
    [SerializeField] private float _speed;
    [SerializeField] private float _damp = 10;
    private Rigidbody2D _rg;
    private Vector2 _targetVelocity;
    private void Awake()
    {
        _rg = GetComponent<Rigidbody2D>();
        _rg.gravityScale = 0;
    }
    private void Update()
    {
        Vector2 movement = _movementBrain.GetMoveVector();
        Vector2 delta = movement.normalized;
        delta.y *= _perspectiveSettings.IsometricRatio;
        _targetVelocity = delta * _speed;
    }
    private void FixedUpdate()
    {
        _rg.linearVelocity = Vector2.Lerp(_rg.linearVelocity, _targetVelocity, 1 - Mathf.Exp(-Time.fixedDeltaTime * _damp));
    }
}
