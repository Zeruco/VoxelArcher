using UnityEngine;

public abstract class Arrow : MonoBehaviour
{
    [SerializeField] private float _step;
    [SerializeField] private float _damage;

    private Vector3 _startPosition;
    private Vector3 _middlePosition;
    private Vector3 _targetPosition;
    private float _arrowPosition;

    public float Damage => _damage;

    private void Update()
    {
        _arrowPosition += _step * Time.deltaTime;

        transform.position = Bezier.GetPoint(_startPosition, _middlePosition, _middlePosition, _targetPosition, _arrowPosition);
        transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(_startPosition, _middlePosition, _middlePosition, _targetPosition, _arrowPosition));
    }

    protected abstract void OnCollisionEnter(Collision collision);

    public void SetPoints(Vector3 startPosition, Vector3 middlePosition, Vector3 targetPosition)
    {
        _startPosition = startPosition;
        _middlePosition = middlePosition;
        _targetPosition = targetPosition;
    }
}
