using UnityEngine;

public class Bow : MonoBehaviour
{
    private readonly float _shootHeight = 150f;

    public void Shoot(Vector3 direction, Arrow arrow)
    {
        Vector3 middleCoordinate = (direction + transform.position) / 2;
        middleCoordinate.y += _shootHeight;
        arrow = Instantiate(arrow, transform.position, transform.rotation);
        arrow.SetPoints(transform.position, middleCoordinate, direction);
    }
}
