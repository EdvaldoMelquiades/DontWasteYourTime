using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvlCheckpoint : MonoBehaviour
{
    public string stageName;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "Player") && GameController.instance.totalScore == 100)
        {
            SceneManager.LoadScene(stageName);
        }
    }
}
