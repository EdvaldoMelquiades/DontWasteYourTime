using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherrie : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider2D;
    public GameObject collected;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            spriteRenderer.enabled = false;
            circleCollider2D.enabled = false;
            collected.SetActive(true);
            GameController.instanceGameController.itemCount++;
            Destroy(gameObject, 0.25f);
        }
    }
}
