using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private BulletBehavior _bulletPrefab;
    [SerializeField] private AudioSource _shootSound;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootGoOn();
            _shootSound.Play();
        }
    }

    private void ShootGoOn()
    {
        BulletBehavior _bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        _bullet.ShootController(transform.up);
    }
}
