using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryAsteroidTransferController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.layer == LayerMask.NameToLayer("Default") && collision.gameObject.tag == "Asteroid")
        {
            collision.transform.position *= -0.9f;
        }

        if (this.gameObject.layer == LayerMask.NameToLayer("Boundary") && collision.gameObject.tag == "Player")
        {
            collision.transform.position = new Vector3(transform.position.x * -0.9f, transform.position.y * -0.9f, 0);
        }

    }

    
}
