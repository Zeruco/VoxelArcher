using UnityEngine;

public abstract class AttackState : EnemyState
{
    [SerializeField] private float _attacCooldown;
    [SerializeField] protected float Damage;

    private float _timeAfterAttack;

    private void Update()
    {
        _timeAfterAttack += Time.deltaTime;
        
        if (_timeAfterAttack >= _attacCooldown)
        {
            Attack();
            _timeAfterAttack = 0;
        }
    }

    protected abstract void Attack();
}
