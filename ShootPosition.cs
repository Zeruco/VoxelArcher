using UnityEngine;

public class ShootPosition : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    private readonly float _horizontalLeftBorder = -55;
    private readonly float _horizontalRightBorder = 100;
    private readonly float _verticalTopBorder = 100;
    private readonly float _verticalBottomBorder = -170;
    private readonly float _groundHeight = 190;

    public Vector3 GetShootDirection()
    {
        float shootRangeX = transform.GetComponent<Collider>().bounds.size.x / 2;
        float shootRangez = transform.GetComponent<Collider>().bounds.size.z / 2;

        Vector3 direction = new Vector3(transform.position.x - shootRangeX + Random.Range(-shootRangeX, shootRangeX),
            transform.position.y, transform.position.z + Random.Range(-shootRangez, shootRangez));

        return direction;
    }

    public void MoveShootTarget(float speed)
    {
        Vector2 moveInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        Vector2 moveVelocity = moveInput.normalized * speed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x - moveVelocity.x, _groundHeight, transform.position.z + -moveVelocity.y);
        transform.position = CheckBorders(transform.position);
    }

    private Vector3 CheckBorders(Vector3 finalPosition)
    {
        if (finalPosition.x > _horizontalRightBorder)
        {
            finalPosition.x = _horizontalRightBorder;
        }
        if (finalPosition.x < _horizontalLeftBorder)
        {
            finalPosition.x = _horizontalLeftBorder;
        }
        if (finalPosition.z > _verticalTopBorder)
        {
            finalPosition.z = _verticalTopBorder;
        }
        if (finalPosition.z < _verticalBottomBorder)
        {
            finalPosition.z = _verticalBottomBorder;
        }

        return finalPosition;
    }
}
