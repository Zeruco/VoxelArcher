using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Slider _healthPercent;

    private float _maxHealth;

    private void Start()
    {
        _maxHealth = _health;
    }

    public void GetDamage(float damage)
    {
        _health -= damage;
        _healthPercent.value = _health / _maxHealth;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out EnemyArrow enemyArrow))
        {
            _health -= enemyArrow.Damage;
        }
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene(0);
    }
}
