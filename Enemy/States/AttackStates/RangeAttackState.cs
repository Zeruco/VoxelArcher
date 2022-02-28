using UnityEngine;

[RequireComponent(typeof(Bow))]
public class RangeAttackState : AttackState
{
    [SerializeField] private Arrow _arrow;
    private Bow _bow;

    private void Start()
    {
        _bow = GetComponent<Bow>();
    }

    protected override void Attack()
    {
        _bow.Shoot(Tower.transform.position, _arrow);
    }
}
