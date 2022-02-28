using UnityEngine;

public class PlayerArrow : Arrow
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            Destroy(gameObject);
        }
    }
}
