using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOnLoad : MonoBehaviour
{
    private static KeepOnLoad instanceCanvas;

    private void Awake()
    {
        if (instanceCanvas == null)
        {
            instanceCanvas = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}