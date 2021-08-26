using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private BulletBehavior _bulletPrefab;
    [SerializeField] private AudioSource _shootSound;
    private Shooter _whoIsShoot;

    private float _timeBtwnShoot;
    [SerializeField] private float _startTimeBtwnShoot = 1;

    private void Awake()
    {
        if (this.gameObject.tag == "Player") _whoIsShoot = Shooter.Player;
        if (this.gameObject.tag == "NLO") _whoIsShoot = Shooter.NLO;
    }
   

    private void Update()
    {
        switch(_whoIsShoot)
        {
            case Shooter.Player:
                if (Input.GetMouseButtonDown(0))
                {
                    ShootGoOn();
                    _shootSound.Play();
                }
                break;

            case Shooter.NLO:
                {
                    if (_timeBtwnShoot <= 0)
                    {
                        ShootGoOn();
                       // _shootSound.Play();
                        _timeBtwnShoot = _startTimeBtwnShoot;
                    }
                    else _timeBtwnShoot -= Time.deltaTime;
                    break;
                }
        }

    }
    private enum Shooter
    {
        Player,
        NLO
    }

    private void ShootGoOn()
    {
        BulletBehavior _bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        _bullet.ShootController(transform.up);
    }
}
