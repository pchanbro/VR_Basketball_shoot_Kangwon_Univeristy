using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public InArea inAreaScript;
    public static int score;

    void Start()
    {
        inAreaScript = FindObjectOfType<InArea>();
        score = 0;
    }

    public void IncreaseScore()
    {
        score++;
        Transform aaaa = inAreaScript.stage.GetComponent<Transform>();
        if (score == 1)
        {
            aaaa.position = new Vector3(1.65f, 0.0f, 1.88f);
        }
        else if (score == 2)
        {
            aaaa.position = new Vector3(5.16f, 0.0f, -4.96f);
        }
        else if (score == 3)
        {
            aaaa.position = new Vector3(1.95f, 0.0f, -3.89f);
        }
        else if (score == 4)
        {
            aaaa.position = new Vector3(4.83f, 0.0f, 2.66f);
        }
        else if (score == 5)
        {
            aaaa.position = new Vector3(4.83f, 0.0f, -8.04f);
        }
        else if (score == 6)
        {
            aaaa.position = new Vector3(0.31f, 0.0f, 3.25f);
        }
        else if (score == 7)
        {
            aaaa.position = new Vector3(0.31f, 0.0f, -5.76f);
        }
        else if (score == 8)
        {
            aaaa.position = new Vector3(5.06f, 0.0f, 5.44f);
        }
        else if (score == 9)
        {
            aaaa.position = new Vector3(-1.52f, 0.0f, -1.2f);
        }
        else if (score == 10)
        {
            aaaa.position = new Vector3(-4.49f, 0.0f, -1.2f);
        }
        else if (score == 11)
        {
            aaaa.position = new Vector3(-1.62f, 0.0f, 5.7f);
        }
        else if (score == 12)
        {
            aaaa.position = new Vector3(3.85f, 0.0f, -10.63f);
        }
        else if (score == 13)
        {
            aaaa.position = new Vector3(3.85f, 0.0f, 8.07f);
        }
        else if (score == 14)
        {
            aaaa.position = new Vector3(-2.36f, 0.0f, -7.31f);
        }
    }

    void Update()
    {
        scoreText.text = "Score      " + score.ToString();
    }
}