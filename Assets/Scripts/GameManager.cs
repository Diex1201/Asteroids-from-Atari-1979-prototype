using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerHealth _playerHealth;
    [SerializeField] private int _lives = 3;                        
    [SerializeField] private float _respawnTime = 3.0f;                  //время через которое корабль возродится
    [SerializeField] private float _respawnInvulnerabilityTime = 3.0f;  //время неуязвимости корабля
    public int _score = 0;

    [SerializeField] private Text _currentScoreText;
    [SerializeField] private Text _recordScoreText;
    [SerializeField] private Text _currentLivesAmount;

    [SerializeField] private AudioSource _explosionSound;
    [SerializeField] private AudioSource _loseSound;


    private void Update()
    {
        _currentScoreText.text = "Now : " + _score.ToString();
        _currentLivesAmount.text = _lives.ToString();
    }

    public void AsteroidDestroyed(AsteroidController asteroid)
    {
        _explosionSound.Play();
        if (asteroid._asteroidSize < 1.25f) _score += 100;
        else if(asteroid._asteroidSize < 1.85f && asteroid._asteroidSize >= 1.25f) _score += 50;
        else if(asteroid._asteroidSize >= 1.85f) _score += 20;
    }

    public void PlayerDied()
    {
        _explosionSound.Play();
        _lives--;
        if(_lives <= 0)
        {
            GameOver();
        }
        else Invoke(nameof(Respawn), _respawnTime);
    }

    private void Respawn()
    {
        _playerHealth.transform.position = Vector3.zero;
        _playerHealth.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        _playerHealth.gameObject.SetActive(true);

        Invoke(nameof(TurnOnCollisisons), _respawnInvulnerabilityTime);
        _playerHealth.anim.SetTrigger("Respawn");
    }

    private void TurnOnCollisisons()
    {
        _playerHealth.gameObject.layer = LayerMask.NameToLayer("Default");
    }

    private void GameOver()
    {
        _loseSound.Play();
        Time.timeScale = 0;
        _recordScoreText.text = "Recored : " + _score.ToString();
    }
}
