using UnityEngine;

public class MoveTransition : EnemyTransition
{
    [SerializeField] private float _minAttackDistance;

    private StunnedTransition _stunnedTransition;
    public bool CanAttack { get; private set; } = false;

    private void Start()
    {
        _stunnedTransition = GetComponent<StunnedTransition>();
    }

    private void Update()
    {
        if (_stunnedTransition.StunTime <= 0)
        {
            if (Vector3.Distance(transform.position, TargetState.Tower.transform.position) > _minAttackDistance)
            {
                NeedTransit = true;
                CanAttack = false;
            }
            else
            {
                CanAttack = true;
            }
        }
    }
}
