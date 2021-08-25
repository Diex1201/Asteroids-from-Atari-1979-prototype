using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NloSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _nloSpawnPoints;
    public Transform _currentSpawnPoint;
    [SerializeField] private GameObject _nloPrefab;
    void Start()
    {
        Invoke(nameof(SpawnNLO), 2);
    }

   
    void Update()
    {
        
    }
    public void SpawnNLO()
    {
        int num = Random.Range(0, _nloSpawnPoints.Length - 1);
        _currentSpawnPoint = _nloSpawnPoints[num].transform;
        GameObject _currentNLO = Instantiate(_nloPrefab, _currentSpawnPoint.position, transform.rotation);
    }
}
