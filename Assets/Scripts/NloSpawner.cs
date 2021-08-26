using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NloSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _nloPrefab;
    public bool _isAlive;
    void Start()
    {
        Invoke(nameof(SpawnNLO), Random.Range(20, 40));
    }

    void Update()
    {
     if(!_isAlive)
        {
            StartCoroutine(RespawnNlo());
            _isAlive = true;
        }
    }
    public void SpawnNLO()
    {
         Vector3 _spawnPointPos = new Vector3(-10, Random.Range(-2.5f, 2.5f), 0);
         GameObject _currentNLO = Instantiate(_nloPrefab, _spawnPointPos, transform.rotation);
        _isAlive = true;
    }

    private IEnumerator RespawnNlo()
    {
        yield return new WaitForSeconds(Random.Range(20, 40));
        SpawnNLO();
    }
}
