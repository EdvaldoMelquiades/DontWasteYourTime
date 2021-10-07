using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    public float fallingTime;

    private TargetJoint2D tj2d;
    private BoxCollider2D bc2d;

    // Start is called before the first frame update
    void Start()
    {
        tj2d = GetComponent<TargetJoint2D>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("Falling", fallingTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }

    void Falling()
    {
        tj2d.enabled = false;
        bc2d.isTrigger = true;
    }
}
