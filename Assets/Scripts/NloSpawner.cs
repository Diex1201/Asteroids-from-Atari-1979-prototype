using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NloSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _nloPrefab;
    void Start()
    {
        Invoke(nameof(SpawnNLO), Random.Range(20, 40));
    }

    void Update()
    {
        Invoke(nameof(StartCheckingStatus), 40);
    }
    public void SpawnNLO()
    {
        if (GameObject.FindGameObjectWithTag("NLO") == null)
        {
            Vector3 _spawnPointPos = new Vector3(-10, Random.Range(-2.5f, 2.5f), 0);
            GameObject _currentNLO = Instantiate(_nloPrefab, _spawnPointPos, transform.rotation);
        }
    }

    public void StartCheckingStatus()
    {
        if (GameObject.FindGameObjectWithTag("NLO") == null)
        {
            Invoke(nameof(SpawnNLO), Random.Range(20, 40));
        }
    }
}
