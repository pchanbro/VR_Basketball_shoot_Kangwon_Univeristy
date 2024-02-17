using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Goal : MonoBehaviour
{
    public Score scoreScript;
    public InArea inAreaScript;
    bool isPressed;

    void Start()
    {
        scoreScript = FindObjectOfType<Score>();
        inAreaScript = FindObjectOfType<InArea>();
        isPressed = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isPressed && inAreaScript.isPressed)
        {
            scoreScript.IncreaseScore();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPressed = false;
    }
}
