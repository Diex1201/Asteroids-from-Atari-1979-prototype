using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float _speedMov = 500.0f;
    [SerializeField] private float _maxLifeTime = 3.0f;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void ShootController(Vector2 direction)
    {
        _rb.AddForce(direction * _speedMov);
        Destroy(gameObject, _maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
