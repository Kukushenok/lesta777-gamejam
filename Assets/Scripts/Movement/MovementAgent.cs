using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
[RequireComponent(typeof(Rigidbody2D))]
public class MovementAgent : MonoBehaviour, ISpeedDebuffable
{
    [SerializeField] private MovementBrain _movementBrain;
    [SerializeField] private PerspectiveSettingsSO _perspectiveSettings;
    [SerializeField] private float _speed;
    [SerializeField] private float _damp = 10;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    private Rigidbody2D _rg;
    private Vector2 _targetVelocity;
    bool _facingLeft = true;
    private void Awake()
    {
        _rg = GetComponent<Rigidbody2D>();
        _rg.gravityScale = 0;
        _rg.freezeRotation = true;
        _rg.interpolation = RigidbodyInterpolation2D.Interpolate;
    }
    private void Update()
    {
        Vector2 movement = _movementBrain.GetMoveVector();
        if (movement != Vector2.zero)
        {
            if (movement.x < 0) _facingLeft = true;
            else _facingLeft = false;
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }

        _spriteRenderer.flipX = _facingLeft;

        Vector2 delta = movement.normalized;
        delta.y *= _perspectiveSettings.IsometricRatio;
        _targetVelocity = delta * _speed;
    }
    private void FixedUpdate()
    {
        _rg.linearVelocity = Vector2.Lerp(_rg.linearVelocity, _targetVelocity, 1 - Mathf.Exp(-Time.fixedDeltaTime * _damp));
    }

    public void DebuffSpeed(float modifier)
    {
        _speed = _speed * (1 - modifier);
    }
}
