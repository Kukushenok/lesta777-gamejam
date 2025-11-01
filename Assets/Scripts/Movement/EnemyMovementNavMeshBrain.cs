using System.Collections;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovementNavMeshBrain : MovementBrain
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
    private NavMeshAgent _navMeshAgent;
    private State _currState = State.Idle;
    private Transform _target;
    private float _currentDetectionTime; 
    private Vector2 _currMoveVector;
    private NavMeshPath _path;
    private int _pathIdx = 0;
    private Coroutine pathfindCoroutine;
    private void Awake()
    {
        _target = FindFirstObjectByType<PlayerMovementBrain>().transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updatePosition = true;
        _navMeshAgent.updateUpAxis = false;
        _path = new NavMeshPath();
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

            Move();
        }
        else
        {
            _currMoveVector = Vector2.zero;
            if (delta.magnitude > _attackRadius)
            {
                _currState = State.Aggro;
            }
        }
           
    }
    private void Move()
    {
        if (pathfindCoroutine == null)
        {
            pathfindCoroutine = StartCoroutine(Pathfind());
        }
        else if (_currState != State.Aggro)
        {
            StopCoroutine(pathfindCoroutine);
            pathfindCoroutine = null;
        }
        if (_path.corners.Length > _pathIdx)
        {
            Vector2 delta = _path.corners[_pathIdx] - transform.position;
            _currMoveVector = delta.normalized;
            if (delta.magnitude < _navMeshAgent.stoppingDistance) _pathIdx++;
        } 
        else if(_pathIdx >= 0 && _pathIdx != int.MaxValue)
        {
            bool foundPath = _navMeshAgent.CalculatePath(_target.position, _path);
            if (foundPath) _pathIdx = 0;
            else _pathIdx = int.MaxValue; // prevents cycling in Update, waiting for Pathfind timer
        }
    }
    private IEnumerator Pathfind()
    {
        while (true)
        {
            bool foundPath = _navMeshAgent.CalculatePath(_target.position, _path);
            if(foundPath) _pathIdx = 0;
            yield return new WaitForSeconds(1);
        }
    }
}
