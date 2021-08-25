using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    
    [SerializeField] private int _spawnAmount;           //���������� �������� ������ �� ������
    [SerializeField] private float _spawnDistance = 15.0f;  //��������� �� ����� ������� ����� �����, ��� ������ ���������� 
    [SerializeField] private float _trajectoryVariance = 15.0f;  //������ ���������� �� ������ ���������� ������ � ����

    [SerializeField] private AsteroidController _asteroidPrefab;
    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Asteroid") == null)
        {
            _spawnAmount++;
            Spawn();
        }
    }

    private void Spawn()
    {
        for(int i = 0; i < _spawnAmount; i++)
        {
            Vector3 _spawnDir = Random.insideUnitCircle.normalized * _spawnDistance;
            Vector3 _spawnPoint = transform.position + _spawnDir;
            float _variance = Random.Range(-_trajectoryVariance, _trajectoryVariance);
            Quaternion _rotation = Quaternion.AngleAxis(_variance, Vector3.forward);

            AsteroidController asteroid = Instantiate(_asteroidPrefab, _spawnPoint, _rotation);
            asteroid._asteroidSize = Random.Range(asteroid._minSize, asteroid._maxSize);
            asteroid.SetTrajectory(_rotation * -_spawnDir);
        }
    }
}
