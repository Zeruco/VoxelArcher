using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private EnemyState _startState;

    private EnemyState _currentState;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _currentState = _startState;
        _currentState.Enter(_rigidbody, _animator);
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        EnemyState nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Transit(EnemyState nextState)
    {
        if(_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;
        
        if(_currentState != null)
        {
            _currentState.Enter(_rigidbody, _animator);
        }
    }
}
