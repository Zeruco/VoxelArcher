using UnityEngine;

public class AttackTranstion : EnemyTransition
{
    private Tower _tower;
    private MoveTransition _moveTransition;

    private void Start()
    {
        _tower = FindObjectOfType<Tower>();
        _moveTransition = GetComponent<MoveTransition>();
    }

    private void Update()
    {
        if (_moveTransition.CanAttack == true)
        {
            NeedTransit = true;
        }
    }
}
