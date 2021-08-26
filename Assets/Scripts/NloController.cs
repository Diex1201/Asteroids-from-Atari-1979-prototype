using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NloController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        _rb.AddForce(transform.up * 0.1f);
        transform.rotation = new Quaternion(0, 0, -90, 90);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.gameObject.tag = "Finish";
        FindObjectOfType<GameManager>().NLODestroyed();
        _anim.SetTrigger("Crashed");
        Destroy(gameObject, 1.1f);
    }
}
