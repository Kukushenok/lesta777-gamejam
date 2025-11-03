using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Camera _camera;
    private Transform _playerTarget;
    private Vector2 _playerPos;
    private Vector3 _lastCameraPos;
    private int _spawnedEnemiesCount;
    private int _totalEnemiesCount;
    private int _deadEnemiesCount;
    private float _spawnTime;

    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _spawnCount;
    [SerializeField] private float _spawnScreenOffset;
    [SerializeField] private Transform _borderUpper;
    [SerializeField] private Transform _borderLower;
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private List<int> _enemyCount;

    private void Awake()
    {
        _spawnedEnemiesCount = 0;
        _totalEnemiesCount = _enemyCount.Sum();
        _camera = Camera.main;
        _playerTarget = FindFirstObjectByType<PlayerMovementBrain>().transform;
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
    }

    private void Update()
    {
        _playerPos = _playerTarget.position;
        var cameraPos = _camera.transform.position;
        if (cameraPos != _lastCameraPos)
        {
            _lastCameraPos = cameraPos;
        }

        _spawnTime -= Time.deltaTime;

        if (_spawnTime <= 0.0f)
        {
            SpawnEnemy(0, UnityEngine.Random.value <= 0.5f);
            _spawnTime = _spawnDelay;
        }
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
        }
    }

    private Vector3 GetPointInWorld(int screenPos)
    {
        Vector3 cameraDistance = _playerTarget.position - _camera.transform.position;
        return _camera.ScreenToWorldPoint(new Vector3(screenPos, 0, cameraDistance.z));        
    }
}
