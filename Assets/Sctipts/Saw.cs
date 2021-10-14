using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float movingSpeed;
    public float movingTime;

    private bool movingRight = true;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        if(movingRight)
        {
            transform.Translate(Vector2.right * movingSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * movingSpeed * Time.deltaTime);
        }

        timer += Time.deltaTime;

        if(timer >= movingTime)
        {
            movingRight = !movingRight;
            timer = 0f;
        } 
    }
}
