using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthContainer : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _getDamageCooldown;

    private float _currentHealth;
    private float _timeAfterGettingDamage;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_timeAfterGettingDamage >= _getDamageCooldown)
        {
            if (collision.collider.TryGetComponent(out PlayerArrow playerArrow))
            {
                _currentHealth -= playerArrow.Damage;
                _healthBar.value = _currentHealth / _maxHealth;
                _timeAfterGettingDamage = 0;

                if (_currentHealth <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void Update()
    {
        _timeAfterGettingDamage += Time.deltaTime;
    }
}
