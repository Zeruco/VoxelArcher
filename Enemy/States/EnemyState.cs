using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    [SerializeField] private EnemyTransition[] _transitions;

    protected Animator Animator { get; private set; }

    public Tower Tower { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Tower = FindObjectOfType<Tower>();
    }

    public void Enter(Rigidbody rigidbody, Animator animator)
    {
        Rigidbody = rigidbody;
        Animator = animator;

        if (enabled == false)
        {
            enabled = true;
        }

        foreach (var transition in _transitions)
        {
            transition.enabled = true;
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public EnemyState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }
}
