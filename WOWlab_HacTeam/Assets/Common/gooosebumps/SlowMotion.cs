using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{

    public float slowDownFactor = 0.7F;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand")) // нужно ли
        {
            if (Time.timeScale == 1.0F)
            {
                Time.timeScale = slowDownFactor;
                Debug.Log("SlowMoStarted");
            }
            else
                Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
    }
}