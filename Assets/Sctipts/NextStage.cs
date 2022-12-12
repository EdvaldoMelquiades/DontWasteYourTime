using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    public string nextStage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "Player") && (GameController.instanceGameController.itemCount == 3))
        {
            GameController.instanceGameController.itemCount = 0;
            SceneManager.LoadScene(nextStage);
        }
    }
}
