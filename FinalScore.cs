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
            // 타이머가 0이 되면 게임 종료 처리
            EndGame();
        }
    }
    void EndGame()
    {
        // 게임 종료 처리 코드 작성
        SceneManager.LoadScene("MAIN");
    }

}
