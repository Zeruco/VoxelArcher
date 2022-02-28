using UnityEngine;

public class MoveState : EnemyState
{
    [SerializeField] private float _speed;

    private Vector3 _startPosition;
    private float _distanceToAttackTarget;
    private float _startTime;
    private float _movedTime;

    private void Start()
    {
        _startTime = Time.deltaTime;
        _startPosition = transform.position;
        _distanceToAttackTarget = Vector3.Distance(transform.position, Tower.transform.position);
    }

    private void Update()
    {
        _movedTime += Time.deltaTime;
        float distCovered = (_movedTime - _startTime) * _speed;
        float fracJourney = distCovered / _distanceToAttackTarget;

        transform.position = Vector3.Lerp(_startPosition, new Vector3(_startPosition.x, _startPosition.y, Tower.transform.position.z), fracJourney);
    }
}
