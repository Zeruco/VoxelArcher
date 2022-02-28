using UnityEngine;

public class EnemyArrow : Arrow
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Tower tower))
        {
            Destroy(gameObject);
        }
    }
}
