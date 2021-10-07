using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherrie : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D cc2d;

    public GameObject collected;
    
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cc2d = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            cc2d.enabled = false;
            collected.SetActive(true);

            GameController.instance.totalScore += score;
            GameController.instance.UpdateScoreText();

            Destroy(gameObject, 0.25f);
        }
    }
}
