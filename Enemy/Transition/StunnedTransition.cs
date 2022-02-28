using UnityEngine;

public class StunnedTransition : EnemyTransition
{
    public float StunTime { get; private set; } = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out StunningArrow stunningArrow))
        {
            NeedTransit = true;
            StunTime = stunningArrow.StunTime;
        }
    }

    private void Update()
    {
        if (StunTime > 0)
        {
            StunTime -= Time.deltaTime;
        }
    }
}