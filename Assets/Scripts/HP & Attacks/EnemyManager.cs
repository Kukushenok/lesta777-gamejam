using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    private Camera _camera;
    private Transform _playerTarget;
    private float _spawnTime;
    private bool _isSpawnTime;
    private bool _allEnemiesSpawned;
    private int _spawnedEnemies;

    [SerializeField] private float _spawnScreenOffset;
    [SerializeField] private Transform _borderUpper;
    [SerializeField] private Transform _borderLower;
    [SerializeField] private List<WaveConfig> _waves;
    [SerializeField] private UnityEvent AllEnemiesDead;
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private GameObject _effectPrefab;

    private void Awake()
    {
        _camera = Camera.main;
        _playerTarget = FindFirstObjectByType<PlayerMovementBrain>().transform;
        StartCoroutine(GoThroughWaves());
    }

    private void Update()
    {
        _spawnTime -= Time.deltaTime;

        if (_spawnTime <= 0.0f)
        {
            _isSpawnTime = true;
        }

        if (_allEnemiesSpawned&&_spawnedEnemies <= 0)
        {
            AllEnemiesDead?.Invoke();
        }
    }

    private IEnumerator GoThroughWaves()
    {
        foreach (var wave in _waves)
        {
            _spawnTime = wave.waveDelay;
            while (!_isSpawnTime) yield return null;
            for (int i = 0; i < wave.enemyCount; i++)
            {
                SpawnEnemy(wave.enemyID, wave.onRight);
                yield return new WaitForEndOfFrame();
            }
            _isSpawnTime=false;    
        }
        _allEnemiesSpawned = true;
        yield return null;
    }

    private void SpawnEnemy(int enemyID, bool onRight)
    {
        GameObject enemyPrefab = _enemyPrefabs[enemyID];
        if (enemyPrefab != null)
        {
            var enemyObject = Instantiate(enemyPrefab);
            Vector3 enemyPos;
            var y = UnityEngine.Random.Range(_borderLower.position.y, _borderUpper.position.y);
            if (onRight)
            {
                var x = GetPointInWorld(Screen.width).x + _spawnScreenOffset;
                enemyPos = new Vector3(x, y, 0);
            }
            else
            {
                var x = GetPointInWorld(0).x + _spawnScreenOffset;
                enemyPos = new Vector3(x, y, 0);
            }
            enemyObject.transform.position = enemyPos;
            enemyObject.GetComponent<Health>().OnDeath.AddListener(delegate {KillEnemy(enemyObject); });
            _spawnedEnemies++;
        }
    }

    private void KillEnemy(GameObject enemyObject)
    {
        var effect = Instantiate(_effectPrefab);
        effect.transform.position = enemyObject.transform.position;
        Destroy(enemyObject);
        _spawnedEnemies--;
    }

    private Vector3 GetPointInWorld(int screenPos)
    {
        Vector3 cameraDistance = _playerTarget.position - _camera.transform.position;
        return _camera.ScreenToWorldPoint(new Vector3(screenPos, 0, cameraDistance.z));        
    }
}
[Serializable]
public class WaveConfig
{
    public float waveDelay;
    public int enemyID;
    public int enemyCount;
    public bool onRight;
}
