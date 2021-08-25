using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    public Animator anim;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "NLO")
        {
           _playerMovement._rb.velocity = Vector3.zero;
           _playerMovement._rb.angularVelocity = 0.0f;
            gameObject.SetActive(false);
            FindObjectOfType<GameManager>().PlayerDied();
        }
    }
}
