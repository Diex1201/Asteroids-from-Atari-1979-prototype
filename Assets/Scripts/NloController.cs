using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NloController : MonoBehaviour
{
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        _rb.AddForce(transform.up * 0.3f);
        transform.rotation = new Quaternion(0, 0, -90, 90);
    }
}
