using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyStateMachine[] _enemyTypes;
    [SerializeField] private float _maxEnemyCount;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        InstantiateRandomEnemy();
        Invoke("Spawn", Random.Range(6, 10));
    }

    private void InstantiateRandomEnemy()
    {
        Instantiate(_enemyTypes[Random.Range(0, _enemyTypes.Length)], new Vector3(Random.Range(-90, 90), transform.position.y, transform.position.z), transform.rotation);
    }
}
