using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPointsParent;
    [SerializeField] private float _delayBetweenSpawns;
    [SerializeField] private GameObject _enemy;

    private Transform[] _spawnPoints;
    

    private void Start()
    {
        _spawnPoints = new Transform[_spawnPointsParent.childCount];
        for(int i =0; i < _spawnPointsParent.childCount; i++)
        {
            _spawnPoints[i] = _spawnPointsParent.GetChild(i);
        }
        var spawnerJob = StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int spawnPoint = Random.Range(0, _spawnPointsParent.childCount);
            Instantiate(_enemy, _spawnPoints[spawnPoint].position, Quaternion.identity);
            yield return new WaitForSeconds(_delayBetweenSpawns);
        }
    }
}
