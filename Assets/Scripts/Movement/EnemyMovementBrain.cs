using UnityEngine;

public class EnemyMovementBrain : MovementBrain
{
    private enum State
    {
        Idle,
        Aggro,
        Attack
    }
    [SerializeField] private float _detectionRadius;
    [SerializeField] private float _detectionMemory;
    [SerializeField] private float _attackRadius;
    private State _currState = State.Idle;
    private Transform _target;
    private float _currentDetectionTime; 
    private Vector2 _currMoveVector;
    private EnemyAttackerBrain _attackerBrain;
    private void Awake()
    {
        _target = FindFirstObjectByType<PlayerMovementBrain>().transform;
        _attackerBrain = GetComponent<EnemyAttackerBrain>();
    }
    public void ForceDetect()
    {
        if(_currState == State.Idle)
        {
            _currState = State.Aggro;
            _currentDetectionTime = _detectionMemory;
        }
    }
    public override Vector2 GetMoveVector()
    {
        return _currMoveVector;
    }
    private void Update()
    {
        Vector2 delta = _target.transform.position - transform.position;
        if (_currState == State.Idle)
        {
            _currMoveVector = Vector2.zero;
            if(delta.magnitude < _detectionRadius)
            {
                _currState = State.Aggro;
            }
        } 
        else if(_currState == State.Aggro)
        {
            if (delta.magnitude > _detectionRadius)
            {
                if (_currentDetectionTime >= 0)
                {
                    _currentDetectionTime -= Time.deltaTime;
                }
                else
                {
                    _currState = State.Idle;
                }
            }
            else if (delta.magnitude < _attackRadius)
            {
                _currState = State.Attack;
            }
            else
            {
                _currentDetectionTime = _detectionMemory;
            }

            delta.y /= 0.7f; // yeah that should be from PerspectiveSettingsSO but I need to introduce another singleton TwT
            _currMoveVector = delta.normalized;
        }
        else
        {
            _currMoveVector = Vector2.zero;
            if (!_attackerBrain.isEnabled) _attackerBrain.Enable(0, _target.transform.position - transform.position);
            else _attackerBrain.UpdateDirection(_target.transform.position - transform.position);
            if (delta.magnitude > _attackRadius)
            {
                _attackerBrain.Disable();
                _currState = State.Aggro;
            }
        }
           
    }
}
