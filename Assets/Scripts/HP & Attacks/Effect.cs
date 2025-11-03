using UnityEngine;

public class Effect : MonoBehaviour
{
    private Animator _animator;
    private CapsuleCollider2D _collider;
    private bool _isIdle;
    [SerializeField] float _cleanupTime;

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider2D>();
        _animator = GetComponent<Animator>();
        _isIdle = false;
        _collider.enabled = false;
    }

    private void Update()
    {
        _cleanupTime -= Time.deltaTime;

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") & !_isIdle)
        {
            _collider.enabled = true;
        }

        if ( _cleanupTime <= 0f)
        {
            _animator.SetTrigger("isDestroyed");
            Destroy(gameObject, 0.5f);
        }
    }
}
