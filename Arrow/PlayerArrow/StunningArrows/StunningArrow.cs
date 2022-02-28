using UnityEngine;

public class StunningArrow : PlayerArrow
{
    [SerializeField] private float _stunTime;

    public float StunTime => _stunTime;
}
