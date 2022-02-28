using UnityEngine;

public class MeleeAttackState : AttackState
{
    protected override void Attack()
    {
        Tower.GetDamage(Damage);
    }
}
