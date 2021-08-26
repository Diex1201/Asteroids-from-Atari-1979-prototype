using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPointNLORotation : MonoBehaviour
{
    private GameObject _target;

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(_target != null)
        {
            Vector3 difference = _target.transform.position - transform.position;
            float rotate = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotate -90);
        }
    }
}
