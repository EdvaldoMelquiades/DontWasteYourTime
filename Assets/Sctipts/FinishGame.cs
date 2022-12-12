using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "Player") && (GameController.instanceGameController.itemCount == 3))
        {
            GameController.instanceGameController.itemCount = 0;
            GameController.instanceGameController.victoryPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
