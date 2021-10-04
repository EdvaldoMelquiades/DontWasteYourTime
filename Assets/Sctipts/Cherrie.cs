using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherrie : MonoBehaviour
{
    private SpriteRenderer sptRenderer;
    private CircleCollider2D crclCollider;

    public GameObject collected;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        sptRenderer = GetComponent<SpriteRenderer>();
        crclCollider = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sptRenderer.enabled = false;
            crclCollider.enabled = false;
            collected.SetActive(true);

            GameController.instance.totalScore += score;
            GameController.instance.UpdateScoreText();

            Destroy(gameObject, 0.25f);
        }
    }
}
