using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Don't forget this for scene transitions

public class FinalScore : MonoBehaviour
{
    public Text finalScore;
    private float timer = 10f;


    void Start()
    {
        int num = Score.score;
        
        finalScore.text = "Final Score      " + num;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            timer = 0f;
            // Ÿ�̸Ӱ� 0�� �Ǹ� ���� ���� ó��
            EndGame();
        }
    }
    void EndGame()
    {
        // ���� ���� ó�� �ڵ� �ۼ�
        SceneManager.LoadScene("MAIN");
    }

}
